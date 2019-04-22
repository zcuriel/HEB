using HEB.NetGiphyA.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace HEB.NetGiphyA.ViewModels
{
    public class SearchResultViewModel : ParentViewModel
    {
        public SearchResultViewModel()
        {
            Pictures = new List<Picture>();
        }

        public List<Picture> Pictures { get; set; }
    }
}
