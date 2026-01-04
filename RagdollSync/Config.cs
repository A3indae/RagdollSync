using Exiled;
using Exiled.API.Interfaces;

namespace RagdollSync
{
    public class Config : IConfig
    {
        public bool IsEnabled { get; set; } = true;
        public bool Debug { get; set; } = true;
    }
}
