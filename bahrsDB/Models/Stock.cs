using bahrsDB.Services.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bahrsDB.Models
{
    public class Stock
    {
        /// <summary>
        /// Id do estoque
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Nome do estoque
        /// </summary>
        public string Nome { get; set; }
        /// <summary>
        /// produto do estoque
        /// um estoque pode ter um produto
        /// </summary>
        public Product Products { get; set; }
        /// <summary>
        /// Id do produto
        /// </summary>
        public int ProductId { get; set; }
        /// <summary>
        /// Status do estoque
        /// </summary>
        public Status Status { get; set; }
    }
}
