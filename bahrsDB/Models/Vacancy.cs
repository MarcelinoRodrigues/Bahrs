using bahrsDB.Negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace bahrsDB.Models
{
    /// <summary>
    /// Entidade Vaga
    /// </summary>
    [Table("Vacancy")]
    public class Vacancy
    {
        /// <summary>
        /// Id da Vaga
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Nome da vaga
        /// </summary>
        [Required(ErrorMessage = "Informe o {0}")]
        public string Nome { get; set; }
    }
}
