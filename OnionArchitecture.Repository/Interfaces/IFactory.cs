using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionArchitecture.Repository.Interfaces
{

    /// <summary>
    /// Factory used to produce repositories 
    /// </summary>
    public interface IFactory
    {
        IUserRepository GetUserRepository();
    }
}
