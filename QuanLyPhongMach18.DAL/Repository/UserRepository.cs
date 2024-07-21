using QuanLyPhongMach18.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyPhongMach18.DAL.Repository
{
    public class UserRepository
    {
        private readonly ClinicManagement18Context _context;

        public UserRepository(ClinicManagement18Context context)
        {
            _context = context;
        }

        public User GetUser(string username, string password)
        {
            return _context.Users.SingleOrDefault(u => u.Username == username && u.Password == password);
        }
    }
}
