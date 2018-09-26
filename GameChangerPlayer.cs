using HamstarHelpers.Helpers.DebugHelpers;
using Terraria;
using Terraria.ModLoader;


namespace GameChanger {
	partial class GameChangerPlayer : ModPlayer {
		private bool IsModSettingsSynced = false;
		private bool IsFiltersSynced = false;


		////////////////

		public override bool CloneNewInstances { get { return false; } }
		
		public override void Initialize() { }

		public override void clientClone( ModPlayer client_clone ) {
			var clone = (GameChangerPlayer)client_clone;
			//clone.HasEnteredWorld = this.HasEnteredWorld;
		}


		////////////////

		public override void SyncPlayer( int to_who, int from_who, bool new_player ) {
			if( Main.netMode == 2 ) {
				if( to_who == -1 && from_who == this.player.whoAmI ) {
					this.OnEnterWorldForServer();
				}
			}
		}

		public override void OnEnterWorld( Player player ) {
			if( player.whoAmI != Main.myPlayer ) { return; }
			if( this.player.whoAmI != Main.myPlayer ) { return; }

			if( Main.netMode == 0 ) {
				this.OnConnectSingle();
			} else if( Main.netMode == 1 ) {
				this.OnConnectClient();
			}
		}
	}
}
