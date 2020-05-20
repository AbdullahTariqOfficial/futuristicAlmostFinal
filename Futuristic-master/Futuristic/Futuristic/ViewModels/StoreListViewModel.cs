using Futuristic.Models;
using Futuristic.Services;
using Futuristic.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Futuristic.ViewModels
{
    public class StoreListViewModel : BaseViewModel
    {
        public ObservableCollection<Store> stores { get; set; }
        public Command LoadItemsCommand { get; set; }
        public Command SelectionChanged { get; set; }
        private StoreService _storeService;

        public StoreListViewModel()
        {
            stores = new ObservableCollection<Store>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());
            
        }

        async Task ExecuteLoadItemsCommand()
        {
            IsBusy = true;

            try
            {
                var user = new User();
                _storeService = new StoreService();
                var userLocation = await user.CurrentLocation();
                var parameters = "latitude=" + userLocation.Latitude + "&longtitude=" + userLocation.Longitude + "&live=true";
                var asnycList = await _storeService.GetList(parameters);
                foreach (var item in asnycList)
                {
                    if (item.Distance > 0)
                        item.DistanceString = LocationMonanager.MetersToString(item.Distance);
                    stores.Add(item);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }
      

    }
}
