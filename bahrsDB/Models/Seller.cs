using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace bahrsDB.Models
{
    /// <summary>
    /// Vendedor
    /// </summary>
    public class Seller
    {
        #region Construtores
        public Seller() { }

        public Seller(int id, string name, string email, DateTime birthDate, double baseSalary, Department department)
        {
            Id = id;
            Name = name;
            Email = email;
            BirthDate = birthDate;
            BaseSalary = baseSalary;
            Department = department;
        }
        #endregion

        #region Propriedade

        /// <summary>
        /// Id do vendedor
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Nome do vendedor
        /// </summary>
        [DisplayName("Nome")]
        [Required(ErrorMessage = "{0} Requerido")]
        [StringLength(60, MinimumLength = 3, ErrorMessage = "Tamanho do {0} deve ser entre {2} e {1}")]
        public string Name { get; set; }
        /// <summary>
        /// Email do vendedor
        /// </summary>
        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "{0} Requerido")]
        [EmailAddress(ErrorMessage = "Email invalido")]
        public string Email { get; set; }
        /// <summary>
        /// Aniversario do vendedor
        /// </summary>
        [DisplayName("Aniversário")]
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "{0} Requerido")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime BirthDate { get; set; }
        /// <summary>
        /// Salário do vendedor
        /// </summary>
        [DisplayName("Salário Base")]
        [Range(100.0,50000.0,ErrorMessage = "{0} Deve ser entre {1} e {2}")]
        [Required(ErrorMessage = "{0} Requerido")]
        [DisplayFormat(DataFormatString ="{0:F2}")]
        public double BaseSalary { get; set; }
        /// <summary>
        /// Associação com o Departamento
        /// Um Vendedor pode ter um departamento
        /// </summary>
        [DisplayName("Departamento")]
        public Department Department { get; set; }
        /// <summary>
        /// Id do departamento
        /// </summary>
        [DisplayName("Departamento")]
        public int DepartmentId { get; set; }
        /// <summary>
        /// Associação com o recorde do vendedor
        /// Um Vendedor pode ter um ou mais Vendas
        /// </summary>
        public ICollection<SalesRecord> Sales { get; set; } = new List<SalesRecord>();

        #endregion

        #region Propriedades Implementadas

        public void AddSales(SalesRecord sr)
        {
            Sales.Add(sr);
        }
        public void RemoveSales(SalesRecord sr)
        {
            Sales.Remove(sr);
        }
        public double TotalSales(DateTime initial,DateTime final)
        {
            return Sales.Where(sr => sr.Date >= initial && sr.Date <= final)
                .Sum(sr => sr.Amount);
        }
        #endregion
    }
}
