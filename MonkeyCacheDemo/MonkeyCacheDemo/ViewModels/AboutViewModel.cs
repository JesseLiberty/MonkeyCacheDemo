using System.Windows.Input;
using MonkeyCache.FileStore;
using MonkeyCacheDemo.Models;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace MonkeyCacheDemo.ViewModels
{
    public class AboutViewModel : BaseViewModel
    {
        public AboutViewModel()
        {
            Title = "About";
            OpenWebCommand = new Command(async () => await Browser.OpenAsync("https://aka.ms/xamain-quickstart"));
            UpdateFromCacheCommand = new Command(() => UpdateFromBarrel());

        }

        public void UpdateFromBarrel()
        {
            if (!Barrel.Current.IsExpired(key: "FirstItem"))
            {
                FromCache = Barrel.Current.Get<Item>(key: "FirstItem");
            }

        }

        private Item _fromCache;
        public Item FromCache
        {
            get => _fromCache;
            set => SetProperty(ref _fromCache, value);
        }


        public ICommand UpdateFromCacheCommand { get; }
        public ICommand OpenWebCommand { get; }
    }
}