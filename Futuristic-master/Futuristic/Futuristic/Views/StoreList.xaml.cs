using Futuristic.Models;
using Futuristic.ViewModels;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Futuristic.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class StoreList : ContentPage
    {
       
        StoreListViewModel viewModel;
        public StoreList()
        {
            try
            {
                InitializeComponent();
               
                BindingContext = viewModel = new StoreListViewModel();
                collectionView.SelectionChanged += CollectionView_SelectionChanged;
            }
            catch(Exception ex)
            {
                ex = ex;
            }
        }

        async void CollectionView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                Store item = e.CurrentSelection.FirstOrDefault() as Store;
                if (item == null)
                    return;

                await Navigation.PushAsync(new StoreDetail(new StoreDetailViewModel(item)));

                // Manually deselect item.
                collectionView.SelectedItem = null;
            }
            catch (Exception ex)
            {
                ex = ex;
            }
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel.stores.Count == 0)
                viewModel.IsBusy = true;
        }
    }
}
