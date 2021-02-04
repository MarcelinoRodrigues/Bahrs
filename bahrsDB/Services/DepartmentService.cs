using bahrsDB.Data;
using bahrsDB.Models;
using System.Collections.Generic;
using System.Linq;

namespace bahrsDB.Services
{
    public class DepartmentService
    {
        private readonly bahrsDBContext _context;

        public DepartmentService(bahrsDBContext context)
        {
            _context = context;
        }

        public List<Department> FindAll()
        {
            return _context.Department.OrderBy(x => x.Name).ToList();
        }
    }
}
