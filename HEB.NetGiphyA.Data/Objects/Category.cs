using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HEB.NetGiphyA.Data.Objects
{
    public class Category
    {
        [Required]
        public int CategoryId { get; set; }

        [Required]
        public string UserEmail { get; set; }

        [MaxLength(50)]
        public string Name { get; set; }

        [MaxLength(250)]
        public string Description { get; set; }

    }
}
