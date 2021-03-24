using bahrsDB.Services.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bahrsDB.Models
{
    public class License
    {
        public int Id { get; set; }
        public User User { get; set; }
        public int UserId { get; set; }
        public Pagina Pagina { get; set; }
        public char OK { get; set; }
    }
}
