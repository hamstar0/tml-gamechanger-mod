using HamstarHelpers.Helpers.DebugHelpers;
using HamstarHelpers.Helpers.TmlHelpers;
using GameChanger.Data;
using System;


namespace GameChanger {
	public static partial class GameChangerAPI {
		public static GameChangerConfigData GetModSettings() {
			return GameChangerMod.Instance.Config;
		}

		public static void SaveModSettingsChanges() {
			GameChangerMod.Instance.ConfigJson.SaveFile();
		}


		////////////////

		public static bool ChangeCurrentWorld() {
			var myworld = GameChangerMod.Instance.GetModWorld<GameChangerWorld>();
			if( myworld.Logic.DataAccess.IsActive() ) {
				return false;
			}

			myworld.Logic.DataAccess.Activate();
			myworld.Logic.SyncDataChanges();

			return true;
		}

		public static bool RevertCurrentWorld() {
			var myworld = GameChangerMod.Instance.GetModWorld<GameChangerWorld>();
			if( !myworld.Logic.DataAccess.IsActive() ) {
				return false;
			}

			myworld.Logic.DataAccess.Deactivate();
			myworld.Logic.SyncDataChanges();

			return true;
		}

		////////////////

		public static void SuppressAutoSavingOn() {
			GameChangerMod.Instance.SuppressAutoSaving = true;
		}
		
		public static void SuppressAutoSavingOff() {
			GameChangerMod.Instance.SuppressAutoSaving = false;
		}


		////////////////

		public static void SetCurrentChangesAsDefaults() {
			if( !LoadHelpers.IsWorldLoaded() ) { throw new Exception( "World not loaded" ); }

			var mymod = GameChangerMod.Instance;
			var myworld = mymod.GetModWorld<GameChangerWorld>();

			myworld.Logic.DataAccess.SetCurrentChangesAsDefaults( mymod );
		}

		public static void ResetChangesFromDefaults() {
			if( !LoadHelpers.IsWorldLoaded() ) { throw new Exception( "World not loaded" ); }

			var mymod = GameChangerMod.Instance;
			var myworld = mymod.GetModWorld<GameChangerWorld>();

			myworld.Logic.DataAccess.ResetChangesFromDefaults( mymod );
		}
	}
}
