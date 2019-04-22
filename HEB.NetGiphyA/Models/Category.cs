using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace HEB.NetGiphyA.Models
{
    public class Category
    {
        public Category()
        {
            CategoryId = 0;
            Description = string.Empty;
        }
        public int CategoryId { get; set; }

        [Required]
        [Display(Name="Category Name")]
        [StringLength(50, ErrorMessage= "Do not enter more than 50 characters")]
        public string Name { get; set; }
       
        [Display(Name ="Category Description")]
        [StringLength(250, ErrorMessage = "Do not enter more than 250 characters")]
        public string Description { get; set; }
    }
}
