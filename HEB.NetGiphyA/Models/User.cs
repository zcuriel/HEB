using HEB.NetGiphyA.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HEB.NetGiphyA.Models
{
    public class User : ParentViewModel
    {
        public User()
        {
            UserId = 0;
        }

        [Required]
        public int UserId { get; set; }

        [Required]
        [Display(Name = "Email")]
        [StringLength(100, ErrorMessage = "Do not enter more than 100 characters")]
        public string UserEmail { get; set; }

        [Required]
        [StringLength(250, ErrorMessage = "Do not enter more than 250 characters")]
        public string Name { get; set; }
    }
}
