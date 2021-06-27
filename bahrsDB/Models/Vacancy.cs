using bahrsDB.Negocio;
using bahrsDB.Services.Enum;
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
        [RegularExpression(ExpressoesRegulares.vagasValidas,ErrorMessage = "A Vaga deve ter Duas letras ou uma Letra e um numero ou dois numeros(Letras Maiusculas)")]
        [Required(ErrorMessage = "Informe o {0}")]
        public string Nome { get; set; }

        /// <summary>
        /// Status do veiculo
        /// </summary>
        public Status Status { get; set; }
    }
}
