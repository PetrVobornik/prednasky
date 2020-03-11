using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace OvladaciPrvky
{
    public partial class App : Application
    {
        public App()
        {
            Device.SetFlags(new string[] { 
                "MediaElement_Experimental", 
                "SwipeView_Experimental", 
                "CarouselView_Experimental",  
                "IndicatorView_Experimental",
            });

            InitializeComponent();

            MainPage = new MainPage();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
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
