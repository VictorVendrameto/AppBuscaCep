using AppBuscaCep.Model;
using AppBuscaCep.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppBuscaCep.Service;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Collections.ObjectModel;

namespace AppBuscaCep.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BairrosPorCidade : ContentPage
    {
        ObservableCollection<Cidade> lista_cidades = 
            new ObservableCollection<Cidade>();    

        ObservableCollection<Bairro> lista_bairros =
            new ObservableCollection<Bairro>();

        public BairrosPorCidade()
        {
            InitializeComponent();

            pck_cidade.ItemsSource = lista_cidades;
            pck_bairro.ItemsSource = lista_bairros;
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            try
            {
                carregando.IsRunning = true;
                List<Bairro> arr_bairros= await DataService.GetBairrosByIdCidade(
                    txt_cidade.Text);

                lst_bairro.ItemsSource = arr_bairros;
            }
            catch (Exception ex)
            {
                await DisplayAlert("Ops", ex.Message, "OK");
            }
            finally
            {
                carregando.IsRunning = false;
            }
        }

        private async void pck_cidade_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Picker disparador = sender as Picker;

                Cidade cidade_selec = disparador.SelectedItem as Cidade;

                List<Bairro> arr_bairro = await DataService.GetBairrosByIdCidade(cidade_selec.id_cidade);

                lista_bairros.Clear();

                arr_bairro.ForEach(i => lista_bairros.Add(i));
            }
            catch(Exception ex)
            {
                await DisplayAlert("Ops", ex.Message, "OK");
            }
        }
    }
}