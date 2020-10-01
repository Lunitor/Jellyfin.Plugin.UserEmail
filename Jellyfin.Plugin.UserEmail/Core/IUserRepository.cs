using System.Collections.Generic;

namespace Jellyfin.Plugin.UserEmail.Core
{
    public interface IUserRepository
    {
        IEnumerable<User> GetAll();
        void SyncWithJellyfinUsers();
        void UpdateUserEmail(string username, string emailAddress);
    }
}