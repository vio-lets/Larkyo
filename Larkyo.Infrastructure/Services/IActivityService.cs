using Larkyo.Infrastructure.Domain;
using Larkyo.Infrastructure.Repositories; 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Larkyo.Infrastructure.Services
{
    public interface IActivityService
    {
        IList<IDestination> GetAllDestinations(); 
        
    }
}
