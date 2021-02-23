using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace bahrsDB.Models
{
    /// <summary>
    /// Estacionamento
    /// </summary>
    public class Parking
    {
        /// <summary>
        /// id do estacionamento
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// entrada
        /// </summary>
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime Entrada { get; set; }
        /// <summary>
        /// vagas do estacionamento
        /// </summary>
        public Vacancy Vaga { get; set; }
        /// <summary>
        /// vencimento da vaga do estacionamento
        /// </summary>
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime Vencimento { get; set; }
        /// <summary>
        /// veiculo do estacionamento
        /// Um estacionamento pode ter um veiculo
        /// </summary>
        public Vehicle Veiculo { get; set; }
        /// <summary>
        /// atendente do estacionamento
        /// um estacionamento pode ter um atendente
        /// </summary>
        public Employee Atendente { get; set; }
        /// <summary>
        /// valor do estacionamento
        /// </summary>
        public decimal Valor { get; set; }
        /// <summary>
        /// Id do veiculo
        /// </summary>
        [DisplayName("Veiculo")]
        public int VeiculoId { get; set; }
        /// <summary>
        /// Id do veiculo
        /// </summary>
        [DisplayName("Atendente")]
        public int? AtendenteId { get; set; }
        /// <summary>
        /// Id da vaga
        /// </summary>
        [DisplayName("Vaga")]
        public int VagaId { get; set; }
    }
}
