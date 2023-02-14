using System;
using System.Collections.Generic;
using System.Text;

namespace AppBuscaCep.Model
{
    public class Endereco
    {
        public int id_logradouro { get; set; }
        public int id_cidade { get; set; }
        public string tipo { get; set; }
        public string desc { get; set; }
        public string uf { get; set; }
        public string complemento { get; set; }
        public string desc_semnum { get; set; }
        public string desc_cidade { get; set; }
        public string cod_cidade_ibge { get; set; }
        public object rows { get; set; }
        public int CEP { get; set; }
        public string UF { get; set; }

    }
}
