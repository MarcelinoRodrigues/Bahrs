using bahrsDB.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bahrsDB.Models
{
    public class SalesRecord
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public double Amount { get; set; }
        public SaleStatus Satus { get; set; }
        /// <summary>
        /// Associação com o Vendedor
        /// Uma venda pertence a um Vendedor
        /// </summary>
        public Seller Seller { get; set; }

        #region Construtores

        public SalesRecord() { }

        public SalesRecord(int id, DateTime date, double amount, SaleStatus satus, Seller seller)
        {
            Id = id;
            Date = date;
            Amount = amount;
            Satus = satus;
            Seller = seller;
        }

        #endregion
    }
}
