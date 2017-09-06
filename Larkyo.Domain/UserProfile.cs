using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Larkyo.Infrastructure.Domain;

namespace Larkyo.Domain
{
    public class UserProfile
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public Gender Gender { get; set; }
        public ApplicationUser User { get; set; }
    }
}
