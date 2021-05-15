using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace bahrsDB.Models
{
    /// <summary>
    /// Estacionamento
    /// </summary>
    [Table("Parking")]
    public class Parking
    {
        /// <summary>
        /// id do estacionamento
        /// </summary>
        [Key]
        public int Id { get; set; }
        /// <summary>
        /// entrada
        /// </summary>
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        [Required]
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
        [Required]
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
        [DisplayName("Funcionário")]
        public Employee Funcionario { get; set; }
        /// <summary>
        /// valor do estacionamento
        /// </summary>
        [Required]
        public decimal Valor { get; set; }
        /// <summary>
        /// Id do veiculo
        /// </summary>
        [DisplayName("Veiculo")]
        [Required(ErrorMessage = "Informe o Veículo")]
        public int VeiculoId { get; set; }
        /// <summary>
        /// Id do veiculo
        /// </summary>
        [DisplayName("Funcionário")]
        [Required(ErrorMessage = "Informe o Funcionário")]
        public int? FuncionarioId { get; set; }
        /// <summary>
        /// Id da vaga
        /// </summary>
        [DisplayName("Vaga")]
        [Required(ErrorMessage = "Informe a Vaga")]
        public int VagaId { get; set; }
    }
}
