using VoidManager.MPModChecks;

namespace CraftableBRAINTurret
{
    public class VoidManagerPlugin : VoidManager.VoidPlugin
    {
        public override MultiplayerType MPType => MultiplayerType.All;

        public override string Author => "Dragon";

        public override string Description => "Makes B.R.A.I.N. Benediction Auto-Turret Mk1 craftable. Requires All clients to install.";
    }
}
