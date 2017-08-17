using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Larkyo.Infrastructure.Domain
{
    public interface IApplicationUser
    {
        string Id { get; set; }
        string UserName { get; set; }
    }
}
