namespace MIBI.Utilities
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Collections.Generic;
    using MIBI.Data.Entities;
    using MIBI.Services.Interfaces;

    public class UserManager
    {
        private IAccountService service;

        public UserManager(IAccountService service)
        {
            this.service = service;
        }

        public User CurrentUser(string token)
        {
            return this.service.RetrieveCurrentUser(token);
        }
    }
}
