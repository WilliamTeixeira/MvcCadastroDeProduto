using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcCadastroDeProduto.Models
{
    public class Produto
    {
        public int Id { get; set; }
        public int Codigo { get; set; }
        public string Descricao { get; set; }
        public double Preco { get; set; }
    }
}