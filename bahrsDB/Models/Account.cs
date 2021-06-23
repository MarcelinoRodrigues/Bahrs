using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace bahrsDB.Models
{
    [Table("Account")]
    public class Account
    {
        [Key]
        public string Nome { get; set; }
        public string Senha { get; set; }
    }
}
