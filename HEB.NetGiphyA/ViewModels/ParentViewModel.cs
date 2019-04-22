using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HEB.NetGiphyA.ViewModels
{
    public class ParentViewModel
    {
        public ParentViewModel()
        {
            IsError = false;
            Message = string.Empty;
        }

        public string Message { get; set; }
        public bool IsError { get; set; }
    }
}
