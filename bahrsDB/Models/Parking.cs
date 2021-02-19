using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bahrsDB.Models
{
    public class Parking
    {
        /// <summary>
        /// id do estacionamento
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// valor do estacionamento
        /// </summary>
        public decimal Valor { get; set; }
        /// <summary>
        /// entrada
        /// </summary>
        public DateTime Entrada { get; set; }
        /// <summary>
        /// vagas do estacionamento
        /// </summary>
        public string Vaga { get; set; }
        /// <summary>
        /// vencimento da vaga do estacionamento
        /// </summary>
        public DateTime Vencimento { get; set; }
        /// <summary>
        /// veiculo do estacionamento
        /// </summary>
        public Vehicle Veiculo { get; set; }
        /// <summary>
        /// atendente do estacionamento
        /// </summary>
        public Employee Atendente { get; set; }
    }
}
