using Jellyfin.Plugin.UserEmail.Entity;
using MediaBrowser.Model.Plugins;
using System;

namespace Jellyfin.Plugin.UserEmail.Configuration
{

    public class PluginConfiguration : BasePluginConfiguration
    {
        public User[] UserEmails { get; set; }

        public PluginConfiguration()
        {
            UserEmails = Array.Empty<User>();
        }
    }
}
