using HEB.NetGiphyA.ViewModels;
using System.ComponentModel.DataAnnotations;

namespace HEB.NetGiphyA.Models
{
    public class Picture : ParentViewModel
    {
        public Picture()
        {
            PictureId = CategoryId = Height = Width = 0;             
        }

        public int PictureId { get; set; }

        [Required]
        [Display(Name = "Picture Name")]
        [StringLength(50, ErrorMessage = "Do not enter more than 50 characters")]
        public string Name { get; set; }

        [Display(Name = "Picture Description")]
        [StringLength(250, ErrorMessage = "Do not enter more than 250 characters")]
        public string Description { get; set; }

        public string FileName { get; set; }

        public string SourceUrl { get; set; }

        public int Height { get; set; }

        public int Width { get; set; }        

        [Display(Name = "Category")]
        public int CategoryId { get; set; }
    }
}
