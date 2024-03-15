using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace ApiAutenticationDotNet8.Repositories
{
    public interface IDbConnectionFactory : IDisposable
    {
        IDbConnection GetDbConnection();
    }
}