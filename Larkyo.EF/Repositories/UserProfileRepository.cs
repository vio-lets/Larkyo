using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RefactorThis.GraphDiff;
using Larkyo.Domain;
using Larkyo.Infrastructure.Repositories;
using System.Linq.Expressions;

namespace Larkyo.EF.Repositories
{
    public class UserProfileRepository : EfEntityRepository<UserProfile, LarkyoContext>, IUserProfileRepository<UserProfile>
    {
        public UserProfile Get(string id)
        {
            UserProfile profile = null;

            using (LarkyoContext context = new LarkyoContext())
            {
                profile = context.Set<UserProfile>().Include(up => up.User).SingleOrDefault(up => up.Id == id);
            }

            return profile;
        }
        public override void Add(UserProfile entity)
        {
            using (LarkyoContext context = new LarkyoContext())
            {
                context.Set<UserProfile>().Add(entity);

                if (entity.User != null)
                {
                    if (entity.User.Id != null)
                    {
                        context.Entry(entity.User).State = System.Data.Entity.EntityState.Modified;
                    }
                }

                context.SaveChanges();
            }
        }

        public void UpdateWithoutRelatedEntities(UserProfile userProfile)
        {
            using (LarkyoContext context = new LarkyoContext())
            {
                context.UpdateGraph(userProfile);
                context.SaveChanges();
            }
        }
    }
}
