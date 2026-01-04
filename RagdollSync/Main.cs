using Exiled.API.Features;
using System;
using Exiled.CustomItems;

namespace RagdollSync
{
    public class Main : Plugin<Config>
    {
        public override string Name => "SyncRagdollMover";
        public override string Author => "A3indae";
        public override Version Version => new Version(1, 0, 0);
        public override Version RequiredExiledVersion => Exiled.Loader.Loader.Version;
        private HarmonyLib.Harmony harmony;

        private static Main singleton;

        public override void OnEnabled()
        {
            singleton = this;

            harmony = new HarmonyLib.Harmony(string.Format("com.{0}.A3indae-{1}", "SyncRagdollMover", DateTime.Now.Ticks));
            harmony.PatchAll();

            base.OnEnabled();
        }
        public override void OnDisabled()
        {
            singleton = null;

            if (harmony != null)
            {
                harmony.UnpatchAll(harmony.Id);
                harmony = null;
            }

            base.OnDisabled();
        }
        public static Main Instance => singleton;
    }
}
