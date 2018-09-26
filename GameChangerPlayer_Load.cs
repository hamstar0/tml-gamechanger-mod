using GameChanger.NetProtocol;
using HamstarHelpers.Components.Network;
using HamstarHelpers.Helpers.DebugHelpers;
using Terraria.ModLoader;


namespace GameChanger {
	partial class GameChangerPlayer : ModPlayer {
		internal void OnConnectSingle() {
			var mymod = (GameChangerMod)this.mod;
			var myworld = this.mod.GetModWorld<GameChangerWorld>();

			if( !mymod.SuppressAutoSaving ) {
				if( !mymod.ConfigJson.LoadFile() ) {
					mymod.ConfigJson.SaveFile();
					LogHelpers.Log( "Game Changer config " + mymod.Version.ToString() + " created (ModPlayer.OnEnterWorld())." );
				}
			}

			myworld.Logic.PostChangesLoad( mymod );

			this.FinishModSettingsSync();
			this.FinishChangesSync();
		}

		internal void OnConnectClient() {
			PacketProtocol.QuickRequestToServer<ModSettingsProtocol>();
			PacketProtocol.QuickRequestToServer<ChangesProtocol>();
		}

		internal void OnEnterWorldForServer() {
			this.IsModSettingsSynced = true;
			this.IsChangesSynced = true;
		}


		////////////////

		internal void FinishModSettingsSync() {
			this.IsModSettingsSynced = true;
		}

		internal void FinishChangesSync() {
			this.IsChangesSynced = true;
		}

		////////////////

		public bool IsSynced() {
			return this.IsModSettingsSynced && this.IsChangesSynced;
		}
	}
}
