using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Larkyo.Domain;
using Larkyo.Infrastructure.Repositories;

namespace Larkyo.EF.Repositories
{
    public class UserProfileRepository : EfEntityRepository<UserProfile, LarkyoContext>
    {
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
    }
}
