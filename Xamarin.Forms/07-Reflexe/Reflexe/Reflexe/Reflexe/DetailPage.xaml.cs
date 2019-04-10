using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Reflexe
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DetailPage : ContentPage
    {
        public DetailPage(IData obj)
        {
            InitializeComponent();

            bOk.Text = AppResources.bOk;
            bZrusit.Text = AppResources.bZrusit;
            bSmazat.Text = AppResources.bSmazat;

            dForm.SetData(obj);
            Title = obj.Id == 0 ? "Nový" : obj.ToString();
            bSmazat.IsVisible = obj.Id > 0;
        }

        private async void BOk_Clicked(object sender, EventArgs e)
        {
            var obj = dForm.GetData();
            if (obj.Id == 0)
                await DbUtils.DB.InsertAsync(obj);
            else 
                await DbUtils.DB.UpdateAsync(obj);
            await Navigation.PopAsync();
        }

        private void BZrusit_Clicked(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }

        private async void BSmazat_Clicked(object sender, EventArgs e)
        {
            if (await DisplayAlert("Smazat", "Skutečně si přejete vymazat tento záznam?", "Vymazat", "Zrušit"))
            {
                if (await DbUtils.Vymazat(dForm.GetData()))
                    await Navigation.PopAsync();
                else
                    await DisplayAlert("Smazat", "Záznam se nepodařilo vymazat, protože se na něj odkazují záznamy jiných tabulek", "OK");
            }
        }
    }
}