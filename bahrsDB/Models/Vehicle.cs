using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bahrsDB.Models
{
    public class Vehicle
    {
        /// <summary>
        /// id do veiculo
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Nome do Veiculo
        /// </summary>
        public string Nome { get; set; }
        /// <summary>
        /// placa do veiculo
        /// </summary>
        public string Placa { get; set; }
    }
}
