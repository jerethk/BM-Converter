using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BM_Converter.Types
{
    public sealed class PaletteOptions
    {
        // Include colours 1-23
        public bool IncludeFullbrights { get; set; }

        // Include colours 24-31
        public bool IncludeHudColours { get; set; }

        // Exclude colours 208-255
        public bool CommonColoursOnly { get; set; }

        // User defined colours to exclude
        public List<int> ColoursToExclude { get; set; }
    }
}
