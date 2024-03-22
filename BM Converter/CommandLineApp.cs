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

            if (args.Any(a => a.ToLower() == "-makebm"))
            {
                var pal = this.GetPal(currentDirectory, args);
                this.CreateBMs(allPngs, pal, currentDirectory);
                return;
            }

            if (args.Any(a => a.ToLower() == "-makeraw"))
            {
                this.CreateRaws(allPngs, currentDirectory);
            }
        }

        private void CreateBMs(string[] pngPaths, DFPal pal, string currentDirectory)
        {
            var outputPath = $"{currentDirectory}\\BmOutput";
            Directory.CreateDirectory(outputPath);
            var logFile = $"{currentDirectory}\\log_{DateTime.UtcNow.Ticks}.txt";

            using (var logWriter = new StreamWriter(logFile))
            {
                var successCount = 0;
                
                foreach (var pngPath in pngPaths)
                {
                    var filename = Path.GetFileNameWithoutExtension(pngPath);
                    var split = filename.Split('_');

                    string outputFilename;
                    string options;

                    // Final portion of filename following underscore contains the options
                    if (split.Length > 1)
                    {
                        var underscorePos = filename.LastIndexOf('_');
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

                    var BM = MiscFunctions.BuildBM(false, pal, source, transparency, "alpha0", 0, useFullbrights, universalColours, compressed);
                    var destination = $"{outputPath}\\{outputFilename}.bm";
                    var succeeds = BM.SaveToFile(destination);

                    if (succeeds)
                    {
                        successCount++;
                    }
                    else
                    {
                        logWriter.WriteLine($"Failed to create {destination}");
                    }
                }

                logWriter.WriteLine($"Successfully created {successCount} BMs");
            }
        }

        private void CreateRaws(string[] pngPaths, string currentDirectory)
        {
            var outputPath = $"{currentDirectory}\\RawOutput";
            Directory.CreateDirectory(outputPath);
            var logFile = $"{currentDirectory}\\log_{DateTime.UtcNow.Ticks}.txt";

            using (var logWriter = new StreamWriter(logFile))
            {
                var successCount = 0;

                foreach (var pngPath in pngPaths)
                {
                    var source = new Bitmap(Image.FromFile(pngPath));
                    var filename = Path.GetFileNameWithoutExtension(pngPath);
                    var destination = $"{outputPath}\\{filename}.raw";

                    var succeeds = MiscFunctions.WriteRawFile(destination, source);

                    if (succeeds)
                    {
                        successCount++;
                    }
                    else
                    {
                        logWriter.WriteLine($"Failed to create {destination}");
                    }
                }

                logWriter.WriteLine($"Successfully created {successCount} RAWs");
            }
        }

        private IEnumerable<string> GetAllPngFilePaths(string currentDirectory)
        {
            
            var allFiles = Directory.EnumerateFiles(currentDirectory);
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
