using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace bahrsDB.Models
{
    /// <summary>
    /// Entidade Funcionario
    /// </summary>
    [Table("Employee")]
    public class Employee
    {
        /// <summary>
        /// id do funcionario
        /// </summary>
        [Key]
        public int Id { get; set; }
        /// <summary>
        /// nome do funcionario
        /// </summary>
        [Required(ErrorMessage = "Informe o Nome")]
        public string Nome { get; set; }
    }
}
