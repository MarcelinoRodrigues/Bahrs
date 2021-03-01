using System;
using System.ComponentModel.DataAnnotations;

namespace bahrsDB.Models
{
    public class Product
    {
        /// <summary>
        /// Id do produto
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Nome do Produto
        /// </summary>
        [Required(ErrorMessage = "{0} Requerido")]
        public string Nome { get; set; }
        /// <summary>
        /// Entrada do Produto
        /// </summary>
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime Entrada { get; set; }
        /// <summary>
        /// Saída do Produto
        /// </summary>
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime Saida { get; set; }
        /// <summary>
        /// Peso do Produto
        /// </summary>
        public int Peso { get; set; }
        /// <summary>
        /// Quantidade do Produto
        /// </summary>
        [Required(ErrorMessage = "{0} Requerido")]
        public int Quantidade { get; set; }
        /// <summary>
        /// Vencimento do Produto
        /// </summary>
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime Vencimento { get; set; }
        /// <summary>
        /// Descrição do Produto
        /// </summary>
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Tamanho da {0} deve ser entre {2} e {1}")]
        public string Descricao { get; set; }
    }
}
