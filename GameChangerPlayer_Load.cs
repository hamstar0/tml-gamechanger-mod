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
			this.FinishFiltersSync();
		}

		internal void OnConnectClient() {
			PacketProtocol.QuickRequestToServer<ModSettingsProtocol>();
			PacketProtocol.QuickRequestToServer<FiltersProtocol>();
		}

		internal void OnEnterWorldForServer() {
			this.IsModSettingsSynced = true;
			this.IsFiltersSynced = true;
		}


		////////////////

		internal void FinishModSettingsSync() {
			this.IsModSettingsSynced = true;
		}

		internal void FinishFiltersSync() {
			this.IsFiltersSynced = true;
		}

		////////////////

		public bool IsSynced() {
			return this.IsModSettingsSynced && this.IsFiltersSynced;
		}
	}
}
