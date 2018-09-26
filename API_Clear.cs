using HamstarHelpers.Helpers.DebugHelpers;
using HamstarHelpers.Helpers.TmlHelpers;
using System;


namespace GameChanger {
	public static partial class GameChangerAPI {
		public static void ClearItemChanges( bool local_only ) {
			if( !LoadHelpers.IsWorldLoaded() ) { throw new Exception( "World not loaded" ); }

			var myworld = GameChangerMod.Instance.GetModWorld<GameChangerWorld>();
			myworld.Logic.DataAccess.ClearItemChanges();

			if( !local_only ) { myworld.Logic.SyncDataChanges(); }
		}
		
		public static void ClearRecipeChanges( bool local_only ) {
			if( !LoadHelpers.IsWorldLoaded() ) { throw new Exception( "World not loaded" ); }

			var myworld = GameChangerMod.Instance.GetModWorld<GameChangerWorld>();
			myworld.Logic.DataAccess.ClearRecipeChanges();

			if( !local_only ) { myworld.Logic.SyncDataChanges(); }
		}

		public static void ClearNpcChanges( bool local_only ) {
			if( !LoadHelpers.IsWorldLoaded() ) { throw new Exception( "World not loaded" ); }

			var myworld = GameChangerMod.Instance.GetModWorld<GameChangerWorld>();
			myworld.Logic.DataAccess.ClearNpcChanges();

			if( !local_only ) { myworld.Logic.SyncDataChanges(); }
		}
	}
}
