using System;
using System.Collections.Generic;
using System.Text;

namespace AppBuscaCep.Model
{
    public class Logradouro
    {
        public int id_logradouro { get; set; }
        public int id_bairro { get; set; }
        public string nome { get; set; }
        public int CEP { get; set; }
    }
}
