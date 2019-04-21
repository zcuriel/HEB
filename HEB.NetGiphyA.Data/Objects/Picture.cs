using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HEB.NetGiphy.Data.Objects
{
    public class Picture
    {
        [Required]
        public int PictureId { get; set; }

        [Required]
        public string UserEmail { get; set; }

        public Category Category { get; set; }

        [MaxLength(50)]
        public string Name { get; set; }

        [MaxLength(250)]
        public string Description { get; set; }

        [MaxLength(250)]
        public string FileName { get; set; }

        [MaxLength(500)]
        public string SourceUrl { get; set; }

        public int Height { get; set; }

        public int Width { get; set; }

        public byte[] Image { get; set; }
    }
}
