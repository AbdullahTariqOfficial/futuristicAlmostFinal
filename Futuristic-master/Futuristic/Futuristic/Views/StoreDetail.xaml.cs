using Futuristic.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Futuristic.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    
    public partial class StoreDetail : ContentPage
    {
        StoreDetailViewModel detailViewModel;
        public StoreDetail(StoreDetailViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = this.detailViewModel = viewModel;
        }

        void OnButtonClicked(object sender, EventArgs e)
        {
            (sender as Button).Text = "OK";
        }
    }
}