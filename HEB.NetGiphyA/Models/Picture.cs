using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HEB.NetGiphyA.Models
{
    public class Picture
    {
        public string Name { get; set; }
        public string FileName { get; set; }
        public string SourceUrl { get; set; }
        public int Height { get; set; }
        public int Width { get; set; }
        public int Size { get; set; }
        public Category Category { get; set; }
    }
}
