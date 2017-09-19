﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Larkyo.Infrastructure.Domain;

namespace Larkyo.Domain
{
    public class ApplicationUser : IdentityUser, IApplicationUser
    {
        public UserProfile UserProfile { get; set; }

    }
}
