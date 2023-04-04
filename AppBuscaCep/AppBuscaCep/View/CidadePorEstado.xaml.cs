using AppBuscaCep.Model;
using AppBuscaCep.Service;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppBuscaCep.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CidadePorEstado : ContentPage
    {
        ObservableCollection<Cidade> lista_cidades =
            new ObservableCollection<Cidade>();

        public CidadePorEstado()
        {
            InitializeComponent();

            lst_cidades.ItemsSource = lista_cidades;
        }

        private async void pck_estado_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                carregando.IsRunning= true;

                Picker disparador = sender as Picker;

                string estado_selec = disparador.SelectedItem as string;

                List<Cidade> arr_cidades = await DataService.GetCidadeByEstado(estado_selec);

                lista_cidades.Clear();

                arr_cidades.ForEach(i => lista_cidades.Add(i));
            }
            catch (Exception ex)
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