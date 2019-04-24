using System.Collections.Generic;

namespace HEB.NetGiphyA.ViewModels
{
    public class MyGifsViewModel : ParentViewModel
    {
        public MyGifsViewModel()
        {
            ListOfCategorizedPictures = new List<CategoryPicturesViewModel>();
        }

        public List<CategoryPicturesViewModel> ListOfCategorizedPictures { get; set; }
    }
}
