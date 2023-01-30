using NetCoreAPIMySQL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetcoreAPIMySQL.Data.Repositories
{
    public interface IUsersRepository
    {

        Task<Users> GetUsers(string User, string Password);


    }
}
