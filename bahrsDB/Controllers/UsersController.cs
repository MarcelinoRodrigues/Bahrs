using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using bahrsDB.Data;
using bahrsDB.Models;
using bahrsDB.Data.Base;

namespace bahrsDB.Controllers
{
    public class UsersController : BaseController<User>
    {

        public UsersController(bahrsDBContext context) : base(context)
        {
        }

        private bool UserExists(int id)
        {
            return _context.User.Any(e => e.Id == id);
        }
    }
}
