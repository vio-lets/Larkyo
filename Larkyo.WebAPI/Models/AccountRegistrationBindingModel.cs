using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Larkyo.WebAPI.Models
{
    public class AccountRegistrationBindingModel
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string ConfirmedPassword { get; set; }
    }
}