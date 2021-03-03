using bahrsDB.Services.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bahrsDB.Models
{
    public class Stock
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public Product Products { get; set; }
        public int ProductId { get; set; }
        public Status Status { get; set; }
    }
}
