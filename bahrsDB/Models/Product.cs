using bahrsDB.Services.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bahrsDB.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public DateTime Entrada { get; set; }
        public DateTime Saida { get; set; }
        public int Peso { get; set; }
        public int Quantidade { get; set; }
        public DateTime Vencimento { get; set; }
        public string Descricao { get; set; }
    }
}
