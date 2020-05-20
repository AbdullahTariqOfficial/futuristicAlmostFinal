using Futuristic.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Futuristic.ViewModels
{

    public class StoreDetailViewModel: BaseViewModel
    {
        public Store SingleStore { get; set; }
        public StoreDetailViewModel(Store store = null)
        {
            Title = store?.Name;
            SingleStore = store;
        }

        
    }
}
