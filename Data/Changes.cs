using HamstarHelpers.Components.Config;
using System.Collections.Generic;


namespace GameChanger.Data {
	class GameChangerChangesData : ConfigurationDataBase {
		public bool IsActive = false;

		public IDictionary<string, string> ItemChanges = new Dictionary<string, string> { };
		public IDictionary<string, string> RecipeChanges = new Dictionary<string, string> { };
		public IDictionary<string, string> NpcChanges = new Dictionary<string, string> { };



		////////////////

		public GameChangerChangesData() {
			this.ResetChangesFromDefaults( GameChangerMod.Instance );
		}


		////////////////
		
		public void SetCurrentChangesAsDefaults( GameChangerMod mymod ) {
			mymod.Config.DefaultItemChanges = this.ItemChanges;
			mymod.Config.DefaultRecipeChanges = this.RecipeChanges;
			mymod.Config.DefaultNpcChanges = this.NpcChanges;

			if( !mymod.SuppressAutoSaving ) {
				mymod.ConfigJson.SaveFile();
			}
		}

		public void ResetChangesFromDefaults( GameChangerMod mymod ) {
			this.ItemChanges = mymod.Config.DefaultItemChanges;
			this.RecipeChanges = mymod.Config.DefaultRecipeChanges;
			this.NpcChanges = mymod.Config.DefaultNpcChanges;
		}
	}
}
