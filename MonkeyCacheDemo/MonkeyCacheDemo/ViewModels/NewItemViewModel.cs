using System;
using MonkeyCache.FileStore;
using MonkeyCacheDemo.Models;
using Xamarin.Forms;

namespace MonkeyCacheDemo.ViewModels
{
    public class NewItemViewModel : BaseViewModel
    {
        private string text;
        private string description;

        public NewItemViewModel()
        {
            SaveCommand = new Command(OnSave, ValidateSave);
            CancelCommand = new Command(OnCancel);
            PropertyChanged +=
                (_, __) => SaveCommand.ChangeCanExecute();
        }

        private bool ValidateSave()
        {
            return !String.IsNullOrWhiteSpace(text)
                && !String.IsNullOrWhiteSpace(description);
        }

        public string Text
        {
            get => text;
            set => SetProperty(ref text, value);
        }

        public string Description
        {
            get => description;
            set => SetProperty(ref description, value);
        }

        public Command SaveCommand { get; }
        public Command CancelCommand { get; }

        private async void OnCancel()
        {
            await Shell.Current.GoToAsync("..");
        }

        private async void OnSave()
        {
            Item newItem = new Item()
            {
                Id = Guid.NewGuid().ToString(),
                Text = Text,
                Description = Description
            };

            // This will expire in an hour but not be deleted until we call
            // EmptyAll, EmptyExpired or Empty(key) 
            Barrel.Current.Add("FirstItem", newItem, expireIn: TimeSpan.FromHours(1));

            await DataStore.AddItemAsync(newItem);
            await Shell.Current.GoToAsync("..");
        }
    }
}
