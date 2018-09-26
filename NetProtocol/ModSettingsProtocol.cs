using HamstarHelpers.Components.Network;
using HamstarHelpers.Components.Network.Data;
using GameChanger.Data;
using Terraria;


namespace GameChanger.NetProtocol {
	class ModSettingsProtocol : PacketProtocol {
		public GameChangerConfigData Settings;



		////////////////

		private ModSettingsProtocol( PacketProtocolDataConstructorLock ctor_lock ) { }

		protected override void SetServerDefaults( int to_who ) {
			this.Settings = GameChangerMod.Instance.Config;
		}

		////////////////

		protected override void ReceiveWithClient() {
			var mymod = GameChangerMod.Instance;
			var myplayer = Main.LocalPlayer.GetModPlayer<GameChangerPlayer>();

			mymod.ConfigJson.SetData( this.Settings );

			myplayer.FinishModSettingsSync();
		}
	}
}
