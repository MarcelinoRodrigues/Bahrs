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
        #region Construtores

        public bahrsDBContext (DbContextOptions<bahrsDBContext> options)
            : base(options)
        {
        }

        #endregion

        #region Propriedades

        /// <summary>
        /// Conexão com a entidade Department
        /// </summary>
        public DbSet<Department> Department { get; set; }
        /// <summary>
        /// Conexao com a entidade Seller
        /// </summary>
        public DbSet<Seller> Seller { get; set; }
        /// <summary>
        /// Conexao com a entidade Vehicle
        /// </summary>
        public DbSet<Vehicle> Vehicle { get; set; }

        /// <summary>
        /// Conexao com a entidade Employee
        /// </summary>
        public DbSet<Employee> Employee { get; set; }

        /// <summary>
        /// Conexao com a entidade Vacancy
        /// </summary>
        public DbSet<Vacancy> Vacancy { get; set; }

        /// <summary>
        /// Conexao com a entidade Parking
        /// </summary>
        public DbSet<Parking> Parking { get; set; }

        #endregion
    }
}
