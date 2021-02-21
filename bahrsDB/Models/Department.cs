using System;
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
        #region Construtores

        public Department() { }

        public Department(int id, string name)
        {
            Id = id;
            Name = name;
        }

        #endregion

        #region Propriedades

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

        #endregion

        #region Metodos implementados

        public void AddSeller(Seller seller)
        {
            Sellers.Add(seller);
        }

        #endregion

    }
}
