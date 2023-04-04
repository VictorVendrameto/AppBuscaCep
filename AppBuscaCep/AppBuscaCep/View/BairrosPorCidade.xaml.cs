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
            lst_bairro.ItemsSource = lista_bairros;
        }

        private async void pck_estado_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Picker disparador = sender as Picker;

                string estado_selec = disparador.SelectedItem as string;

                List<Cidade> arr_cidades= await DataService.GetCidadeByEstado(estado_selec);

                lista_cidades.Clear();

                arr_cidades.ForEach(i => lista_cidades.Add(i));
            }
            catch (Exception ex)
            {
                await DisplayAlert("Ops", ex.Message, "OK");
            }
            
        }

        private async void pck_cidade_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                carregando.IsRunning = true;

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
            finally
            {
                carregando.IsRunning = false;
            }
        }
    }
}