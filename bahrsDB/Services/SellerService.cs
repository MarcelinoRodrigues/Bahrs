using bahrsDB.Data;
using bahrsDB.Models;
using System.Collections.Generic;
using System.Linq;

namespace bahrsDB.Services
{
    public class SellerService
    {
        private readonly bahrsDBContext _context;

        public SellerService(bahrsDBContext context)
        {
            _context = context;
        }

        public List<Seller> FindAll()
        {
            return _context.Seller.ToList();
        }

        public void Insert(Seller obj)
        {
            _context.Add(obj);
            _context.SaveChanges();
        }
    }
}
