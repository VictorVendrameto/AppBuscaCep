using AppBuscaCep.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Runtime.InteropServices.ComTypes;

namespace AppBuscaCep.Service
{
    public class DataService
    {

        //https://cep.metoda.com.br/endereco/by-cep?cep=17210580
        //https://cep.metoda.com.br/logradouro/by-bairro?id_cidade=4874&bairro=Jardim América
        //https://cep.metoda.com.br/cep/by-logradouro?logradouro=Rua
        //https://cep.metoda.com.br/cidade/by-uf?uf=SP
        //https://cep.metoda.com.br/bairro/by-cidade?id=4874


        //ENDEREÇO PELO CEP
        public static async Task<Endereco> GetEnderecoByCep(string cep)
        {
            Endereco end;

            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync("https://cep.metoda.com.br/endereco/by-cep?cep=" + cep);

                if (response.IsSuccessStatusCode)
                {
                    string json = response.Content.ReadAsStringAsync().Result;

                    end = JsonConvert.DeserializeObject<Endereco>(json);
                }
                else
                    throw new Exception(response.RequestMessage.Content.ToString());
            }
            return end;
        }

        //LOGRADOURO
        public static async Task<List<Logradouro>> GetLogradouroByBairroAndIdCidade(string bairro, string id_cidade )
        {

            List<Logradouro> arr_log = new List<Logradouro>();
            using (HttpClient client = new HttpClient())
            {

                HttpResponseMessage response = await client.GetAsync("https://cep.metoda.com.br/logradouro/by-bairro?id_cidade=" + id_cidade +"&bairro=" + bairro );
                if (response.IsSuccessStatusCode)
                {
                    string json = response.Content.ReadAsStringAsync().Result;

                    arr_log = JsonConvert.DeserializeObject<List<Logradouro>>(json);
                }
                else
                    throw new Exception(response.RequestMessage.Content.ToString());
            }
            return arr_log;
        }

        //CIDADE POR ESTADO
        public static async Task<List<Cidade>> GetCidadeByEstado(string uf)
        {
            List<Cidade> arr_cidades = new List<Cidade>();
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync("https://cep.metoda.com.br/cidade/by-uf?uf=" + uf);
                if (response.IsSuccessStatusCode)
                {
                    string json = response.Content.ReadAsStringAsync().Result;
                    arr_cidades = JsonConvert.DeserializeObject<List<Cidade>>(json);
                }
                else
                    throw new Exception(response.RequestMessage.Content.ToString());
            }
            return arr_cidades;
        }
        //BAIRRO PELO ID CIDADE

        public static async Task<List<Bairro>> GetBairrosByIdCidade(string cidade)
        {
            List<Bairro> arr_bairros = new List<Bairro>();
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync("https://cep.metoda.com.br/bairro/by-cidade?id=" + arr_bairros);
                if (response.IsSuccessStatusCode)
                {
                    string json = response.Content.ReadAsStringAsync().Result;
                    arr_bairros = JsonConvert.DeserializeObject<List<Bairro>>(json);
                }
                else
                    throw new Exception(response.RequestMessage.Content.ToString());
            }
            return arr_bairros;
        }

        //CEP POR LOGRADOURO
        public static async Task<List<Cep>> GetCepByLogradouro(string logradouro)
        {
            List<Cep> arr_cep = new List<Cep>();
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync("https://cep.metoda.com.br/cep/by-logradouro?logradouro=" + logradouro);
                if (response.IsSuccessStatusCode)
                {
                    string json = response.Content.ReadAsStringAsync().Result;
                    arr_cep = JsonConvert.DeserializeObject<List<Cep>>(json);
                }
                else
                    throw new Exception(response.RequestMessage.Content.ToString());
            }
            return arr_cep;
        }
    }    
}
