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
        TUserProfile Get(string id);
        void UpdateWithoutRelatedEntities(TUserProfile userProfile);
    }
}
