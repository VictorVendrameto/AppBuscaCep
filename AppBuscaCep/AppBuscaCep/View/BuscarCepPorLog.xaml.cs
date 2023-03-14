using AppBuscaCep.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppBuscaCep.Service;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppBuscaCep.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BuscarCepPorLog : ContentPage
    {
        public BuscarCepPorLog()
        {
            InitializeComponent();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            try
            {
                carregando.IsRunning= true;
                List<Cep> arr_ceps = await DataService.GetCepByLogradouro(
                    txt_log.Text);

                lst_cep.ItemsSource= arr_ceps;
            }
            catch  (Exception ex)
            {
                await DisplayAlert("Ops", ex.Message, "OK");
            }
            finally
            {
                carregando.IsRunning= false;
            }
        }
    }
}