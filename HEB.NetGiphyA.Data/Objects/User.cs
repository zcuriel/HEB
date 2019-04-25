using System.ComponentModel.DataAnnotations;

namespace HEB.NetGiphyA.Data.Objects
{
    public class User
    {
        [Required]
        public int UserId { get; set; }

        [Required, MaxLength(100)]
        public string UserEmail { get; set; }

        [MaxLength(250)]
        public string Name { get; set; }

    }
}
