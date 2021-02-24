using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace bahrsDB.Models
{
    /// <summary>
    /// Entidade Veiculo
    /// </summary>
    [Table("Vehicle")]
    public class Vehicle
    {
        /// <summary>
        /// id do veiculo
        /// </summary>
        [Key]
        public int Id { get; set; }
        /// <summary>
        /// Nome do Veiculo
        /// </summary>
        [Required(ErrorMessage = "Informe o Nome")]
        public string Nome { get; set; }
        /// <summary>
        /// placa do veiculo
        /// </summary>
        [Required(ErrorMessage = "Informe a Placa")]
        public string Placa { get; set; }
    }
}
