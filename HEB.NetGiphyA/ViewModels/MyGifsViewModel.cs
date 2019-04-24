using HEB.NetGiphyA.Models;
using System.Collections.Generic;

namespace HEB.NetGiphyA.ViewModels
{
    public class MyGifsViewModel : ParentViewModel
    {
        public MyGifsViewModel()
        {
            ListOfCategorizedPictures = new List<CategoryPicturesModel>();
        }

        public List<CategoryPicturesModel> ListOfCategorizedPictures { get; set; }
    }
}
