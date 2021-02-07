﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace bahrsDB.Models
{
    [Table("Department")]
    public class Department
    {
        /// <summary>
        /// Id do departamento
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Nome do departamento
        /// </summary>
        [DisplayName("Nome")]
        public string Name { get; set; }
        /// <summary>
        /// Associação com Vendedores
        /// Um departamento pode ter vários vendedores
        /// </summary>
        public ICollection<Seller> Sellers { get; set; } = new List<Seller>();

        #region Construtores

        public Department() { }

        public Department(int id, string name)
        {
            Id = id;
            Name = name;
        }

        #endregion

        public void AddSeller(Seller seller)
        {
            Sellers.Add(seller);
        }

        public double TotalSales(DateTime initial,DateTime final)
        {
            return Sellers.Sum(seller => seller.TotalSales(initial, final));
        }
    }
}
