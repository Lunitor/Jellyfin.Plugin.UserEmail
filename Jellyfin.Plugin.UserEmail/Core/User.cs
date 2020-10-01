namespace Jellyfin.Plugin.UserEmail.Core
{
    internal class User
    {
        public string Username { get; set; }
        public string EmailAddress { get; set; }

        public User()
        { 
        }

        public User(string username, string emailAddress)
        {
            Username = username;
            EmailAddress = emailAddress;
        }
    }
}
