using HEB.NetGiphyA.Models;
using System.Collections.Generic;

namespace HEB.NetGiphyA.ViewModels
{
    public class PictureViewModel : ParentViewModel
    {
        public PictureViewModel()
        {
            Pictures = new List<Picture>();
        }

        public List<Picture> Pictures { get; set; }
    }
}
