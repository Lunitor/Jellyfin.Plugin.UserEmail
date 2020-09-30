using System;
using System.Collections.Generic;

namespace Jellyfin.Plugin.UserEmail.Core
{
    internal class UserRepository
    {
        public IEnumerable<User> GetAll()
        {
            throw new NotImplementedException();
        }

        public void UpdateUserEmail(string userName, string emailAddress)
        {
            throw new NotImplementedException();
        }
    }
}
