using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using bahrsDB.Models;

namespace bahrsDB.Data
{
    public class bahrsDBContext : DbContext
    {
        public bahrsDBContext (DbContextOptions<bahrsDBContext> options)
            : base(options)
        {
        }
        /// <summary>
        /// Conexão com a entidade Department
        /// </summary>
        public DbSet<Department> Department { get; set; }
        /// <summary>
        /// Conexao com a entidade Seller
        /// </summary>
        public DbSet<Seller> Seller { get; set; }
        /// <summary>
        /// Conexao com a entidade SalesRecord
        /// </summary>
        public DbSet<SalesRecord> SalesRecord { get; set; }
    }
}
