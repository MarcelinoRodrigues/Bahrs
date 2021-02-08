using bahrsDB.Data;
using bahrsDB.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bahrsDB.Services
{
    public class DepartmentService
    {
        private readonly bahrsDBContext _context;

        public DepartmentService(bahrsDBContext context)
        {
            _context = context;
        }

        public async Task<List<Department>> FindAllAsync()
        {
            return await _context.Department.OrderBy(x => x.Name).ToListAsync();
        }
    }
}
