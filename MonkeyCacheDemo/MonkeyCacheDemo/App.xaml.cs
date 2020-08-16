using MonkeyCache.FileStore;
using MonkeyCacheDemo.Services;
using Xamarin.Forms;

namespace MonkeyCacheDemo
{
    public partial class App : Application
    {

        public App()
        {
            Barrel.ApplicationId = "MonkeyCacheDemo";
            InitializeComponent();

            DependencyService.Register<MockDataStore>();
            MainPage = new AppShell();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
