using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HEB.NetGiphy.Data.Objects
{
    public class Picture
    {        
        [ForeignKey("Category")]
        public int PictureId { get; set; }
        [MaxLength(50)]
        public string Name { get; set; }
        [MaxLength(50)]
        public string FileName { get; set; }
        [MaxLength(250)]
        public string SourceUrl { get; set; }
        public int Size { get; set; }
        public int Height { get; set; }
        public int Width { get; set; }
        public byte[] Image { get; set; }

        public virtual Category Category { get; set; }
    }
}
