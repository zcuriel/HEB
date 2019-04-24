using System.Collections.Generic;

namespace HEB.NetGiphyA.Models
{
    public class PictureModel
    {
        public PictureModel()
        {
            Pictures = new List<Picture>();
        }

        public List<Picture> Pictures { get; set; }
    }
}
