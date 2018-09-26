using HamstarHelpers.Helpers.DebugHelpers;
using HamstarHelpers.Helpers.MiscHelpers;
using HamstarHelpers.Helpers.WorldHelpers;
using Terraria;


namespace GameChanger.Data {
	partial class GameChangerChangesAccess {
		private GameChangerChangesData Data;


		////////////////

		public GameChangerChangesAccess() {
			this.Data = new GameChangerChangesData();
		}


		////////////////

		private string GetDataFileName() {
			return WorldHelpers.GetUniqueIdWithSeed() + " Changes";
		}

		public void Load( GameChangerMod mymod ) {
			bool success;
			var filters = DataFileHelpers.LoadJson<GameChangerChangesData>( mymod, this.GetDataFileName(), out success );

			if( success ) {
				this.Data = filters;
			}
		}

		public void Save( GameChangerMod mymod ) {
			DataFileHelpers.SaveAsJson<GameChangerChangesData>( mymod, this.GetDataFileName(), this.Data );
		}


		////////////////

		internal void Give( ref GameChangerChangesData data ) {
			data = this.Data;
		}

		internal void Take( GameChangerChangesData data ) {
			this.Data = data;
		}


		////////////////

		public void OutputChanges() {
			Main.NewText( "Is changed: " + this.Data.IsActive );
			Main.NewText( "Items: " + this.Data.ItemChanges.Count );
			Main.NewText( "Recipes: " + this.Data.RecipeChanges.Count );
			Main.NewText( "NPCs: " + this.Data.NpcChanges.Count );

			LogHelpers.Log( "Is changed: " + this.Data.IsActive );
			LogHelpers.Log( "Items: " + string.Join( ", ", this.Data.ItemChanges.Keys ) );
			LogHelpers.Log( "Recipes: " + string.Join( ", ", this.Data.RecipeChanges.Keys ) );
			LogHelpers.Log( "NPCs: " + string.Join( ", ", this.Data.NpcChanges.Keys ) );
		}
	}
}
