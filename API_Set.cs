using HamstarHelpers.Helpers.DebugHelpers;
using HamstarHelpers.Helpers.TmlHelpers;
using System;


namespace GameChanger {
	public static partial class GameChangerAPI {
		public static void SetItemChange( string item_name, string[] changes, bool local_only ) {
			if( !LoadHelpers.IsWorldLoaded() ) { throw new Exception("World not loaded"); }
			
			var myworld = GameChangerMod.Instance.GetModWorld<GameChangerWorld>();
			myworld.Logic.DataAccess.SetItemChange( item_name, changes );

			if( !local_only ) { myworld.Logic.SyncDataChanges(); }
		}

		public static void SetRecipeChange( string item_name, string[] changes, bool local_only ) {
			if( !LoadHelpers.IsWorldLoaded() ) { throw new Exception( "World not loaded" ); }

			var myworld = GameChangerMod.Instance.GetModWorld<GameChangerWorld>();
			myworld.Logic.DataAccess.SetRecipeChange( item_name, changes );

			if( !local_only ) { myworld.Logic.SyncDataChanges(); }
		}

		public static void SetNpcChange( string npc_name, string[] changes, bool local_only ) {
			if( !LoadHelpers.IsWorldLoaded() ) { throw new Exception( "World not loaded" ); }

			var myworld = GameChangerMod.Instance.GetModWorld<GameChangerWorld>();
			myworld.Logic.DataAccess.SetNpcChange( npc_name, changes );

			if( !local_only ) { myworld.Logic.SyncDataChanges(); }
		}


		////////////////

		public static void UnsetItemChange( string item_name, bool local_only ) {
			if( !LoadHelpers.IsWorldLoaded() ) { throw new Exception( "World not loaded" ); }

			var myworld = GameChangerMod.Instance.GetModWorld<GameChangerWorld>();
			myworld.Logic.DataAccess.UnsetItemChange( item_name );

			if( !local_only ) { myworld.Logic.SyncDataChanges(); }
		}

		public static void UnsetRecipeChange( string item_name, bool local_only ) {
			if( !LoadHelpers.IsWorldLoaded() ) { throw new Exception( "World not loaded" ); }

			var myworld = GameChangerMod.Instance.GetModWorld<GameChangerWorld>();
			myworld.Logic.DataAccess.UnsetRecipeChange( item_name );

			if( !local_only ) { myworld.Logic.SyncDataChanges(); }
		}

		public static void UnsetNpcChange( string npc_name, bool local_only ) {
			if( !LoadHelpers.IsWorldLoaded() ) { throw new Exception( "World not loaded" ); }

			var myworld = GameChangerMod.Instance.GetModWorld<GameChangerWorld>();
			myworld.Logic.DataAccess.UnsetNpcChange( npc_name );

			if( !local_only ) { myworld.Logic.SyncDataChanges(); }
		}
	}
}
