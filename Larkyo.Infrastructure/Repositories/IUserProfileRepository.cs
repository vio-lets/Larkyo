using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Larkyo.Infrastructure.Repositories
{
    public interface IUserProfileRepository<TUserProfile> : IRepository<TUserProfile>
        where TUserProfile : class
    {
        void UpdateWithoutRelatedEntities(TUserProfile userProfile);
    }
}
