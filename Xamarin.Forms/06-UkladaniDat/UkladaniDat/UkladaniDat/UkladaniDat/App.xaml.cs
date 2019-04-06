using SQLite;
using System;
using System.IO;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace UkladaniDat
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MainPage());
        }

        public static SQLiteAsyncConnection DbKnihy { get; private set; }

        protected override async void OnStart()
        {
            // Handle when your app starts
            DbKnihy = new SQLiteAsyncConnection(Path.Combine(FileSystem.AppDataDirectory, "knihy.db"));
            await DbKnihy.CreateTableAsync<Kniha>();
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
