
using DataAccessLayer.Data;
using DataAccessLayer.Entities;
using Repositories.Interface;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Repositories
{
    public class LogRepository : GenericRepository<Log>, ILog
    {
        public LogRepository(ApplicationDbContext context) : base(context)
        {

        }

    }
}
