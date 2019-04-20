using System.ComponentModel.DataAnnotations;

namespace HEB.NetGiphy.Data.Objects
{
    public class Category
    {
        [Required]
        public int CategoryId { get; set; }
        [MaxLength(50)]
        public string Name { get; set; }

        public virtual Picture Picture { get; set; }
    }
}
