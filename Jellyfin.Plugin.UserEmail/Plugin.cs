using Jellyfin.Plugin.UserEmail.Configuration;
using MediaBrowser.Common.Configuration;
using MediaBrowser.Common.Plugins;
using MediaBrowser.Model.Plugins;
using MediaBrowser.Model.Serialization;
using System;
using System.Collections.Generic;

namespace Jellyfin.Plugin.UserEmail
{
    public class Plugin : BasePlugin<PluginConfiguration>, IHasWebPages
    {
        public override string Name => "UserEmail";
        
        public override Guid Id => Guid.Parse("a1dc3c99-3e1d-4469-b7f0-b3147d9e9675");

        public Plugin(IApplicationPaths applicationPaths, IXmlSerializer xmlSerializer): base(applicationPaths, xmlSerializer)
        {
            Instance = this;
        }

        public static Plugin Instance { get; private set; }

        public IEnumerable<PluginPageInfo> GetPages()
        {
            return new[]
            {
                new PluginPageInfo
                {
                    Name = this.Name,
                    EmbeddedResourcePath = string.Format("{0}.Configuration.configPage.html", GetType().Namespace)
                }
            };
        }
    }
}
