using BM_Converter.Types;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;

namespace BM_Converter
{
    internal class CommandLineApp
    {
        public void RunApp(string[] args)
        {
            var currentDirectory = Directory.GetCurrentDirectory();
            var allPngs = this.GetAllPngFilePaths(currentDirectory).ToArray();
            var invalidPathChars = Path.GetInvalidFileNameChars().Where(c => c != '/' && c != '\\' && c != ':');

            string outputPath = null;
            var outPathArg = args.FirstOrDefault(a => a.ToLower().Substring(0, 5) == "-out:");
            if (!string.IsNullOrEmpty(outPathArg))
            {
                var path = outPathArg.Substring(5);
                var isPathValid = path.Length > 0 && !path.Any(c => invalidPathChars.Contains(c));
                outputPath = isPathValid ? path : null;
            }

            if (args.Any(a => a.ToLower() == "-makebm"))
            {
                var pal = this.GetPal(currentDirectory, args);
                this.CreateBMs(allPngs, pal, currentDirectory, outputPath);
                return;
            }

            if (args.Any(a => a.ToLower() == "-makeraw"))
            {
                this.CreateRaws(allPngs, currentDirectory, outputPath);
            }
        }

        private void CreateBMs(string[] pngPaths, DFPal pal, string currentDirectory, string outputPath)
        {
            outputPath ??= $"{currentDirectory}\\BmOutput";
            try
            {
                Directory.CreateDirectory(outputPath);
            }
            catch
            {
                Console.WriteLine("Unable to create output directory.");
                return;
            }
            
            var logFile = $"{currentDirectory}\\log_{DateTime.UtcNow.Ticks}.txt";
            using (var logWriter = new StreamWriter(logFile))
            {
                var successCount = 0;
                
                foreach (var pngPath in pngPaths)
                {
                    var filename = Path.GetFileNameWithoutExtension(pngPath);
                    var split = filename.Split("__");

                    string outputFilename;
                    string options;

                    // Final portion of filename following double-underscore contains the options
                    if (split.Length > 1)
                    {
                        var underscorePos = filename.LastIndexOf("__");
                        outputFilename = filename.Substring(0, underscorePos);
                        options = split.Last().ToLower();
                    }
                    else
                    {
                        outputFilename = filename;
                        options = "";
                    }

                    // Process options
                    var useFullbrights = options.Contains('f');
                    var universalColours = options.Contains('u');
                    var transparency = options.Contains('w')
                        ? 'w'
                        : options.Contains('t')
                            ? 't'
                            : 'o';
                    var compressed = options.Contains('c');

                    var source = new List<Bitmap>()
                    {
                        new Bitmap(Image.FromFile(pngPath))
                    };

                    var palOptions = new PaletteOptions()
                    {
                        IncludeFullbrights = useFullbrights,
                        CommonColoursOnly = universalColours,
                    };

                    var BM = MiscFunctions.BuildBM(false, pal, source, transparency, TransparentColour.Alpha0, 0, palOptions, compressed);
                    var destination = $"{outputPath}\\{outputFilename}.bm";
                    var succeeds = BM.SaveToFile(destination);

                    if (succeeds)
                    {
                        successCount++;
                        var paramsString = $"{(transparency == 't' ? "transparent" : transparency == 'w' ? "weapon" : "")} {(useFullbrights ? "fullBrights" : "")} {(universalColours ? "universalColours" : "")} {(compressed ? "compressed" : "")}".Trim();
                        logWriter.WriteLine($"Created {outputFilename}.BM \t {(string.IsNullOrWhiteSpace(paramsString) ? "" : ": ")} {paramsString}");
                    }
                    else
                    {
                        logWriter.WriteLine($"Failed to create {destination}");
                    }
                }

                logWriter.WriteLine($"\nSuccessfully created {successCount} BMs \nat path {outputPath}");
            }
        }

        private void CreateRaws(string[] pngPaths, string currentDirectory, string outputPath)
        {
            outputPath ??= $"{currentDirectory}\\RawOutput";
            try
            {
                Directory.CreateDirectory(outputPath);
            }
            catch
            {
                Console.WriteLine("Unable to create output directory.");
                return;
            }

            var logFile = $"{currentDirectory}\\log_{DateTime.UtcNow.Ticks}.txt";
            using (var logWriter = new StreamWriter(logFile))
            {
                var successCount = 0;

                foreach (var pngPath in pngPaths)
                {
                    var source = new Bitmap(Image.FromFile(pngPath));
                    var filename = Path.GetFileNameWithoutExtension(pngPath);
                    var split = filename.Split("__");
                    string outputFilename;

                    // Remove anything after double-underscore for consistency with BMs
                    if (split.Length > 1)
                    {
                        var underscorePos = filename.LastIndexOf("__");
                        outputFilename = filename.Substring(0, underscorePos);
                    }
                    else
                    {
                        outputFilename = filename;
                    }

                    var destination = $"{outputPath}\\{outputFilename}.raw";
                    var succeeds = MiscFunctions.WriteRawFile(destination, new List<Bitmap>(){ source });

                    if (succeeds)
                    {
                        successCount++;
                        logWriter.WriteLine($"Created {outputFilename}.RAW");
                    }
                    else
                    {
                        logWriter.WriteLine($"Failed to create {destination}");
                    }
                }

                logWriter.WriteLine($"\nSuccessfully created {successCount} RAWs \nat path {outputPath}");
            }
        }

        private IEnumerable<string> GetAllPngFilePaths(string currentDirectory)
        {
            
            var allFiles = Directory.EnumerateFiles(currentDirectory).ToList();
            return allFiles.Where(f => Path.GetExtension(f).ToLower() == ".png");
        }

        private DFPal GetPal(string currentDirectory, string[] args)
        {
            var pal = new DFPal();

            // Get PAL file from arguments
            var palFilename = args.FirstOrDefault(a => a.ToLower().Contains(".pal"));
            if (palFilename != default)
            {
                var palPath = Path.Combine(currentDirectory, palFilename);
                if (File.Exists(palPath))
                {
                    var succeeds = pal.LoadfromFile(palPath);
                    return succeeds ? pal : new DFPal();
                }
            }

            return pal;
        }
    }
}
