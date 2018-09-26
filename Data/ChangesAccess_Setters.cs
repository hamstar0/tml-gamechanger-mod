namespace GameChanger.Data {
	partial class GameChangerChangesAccess {
		public void SetItemChange( string item_name, string[] changes ) {
			this.Data.ItemChanges[item_name] = changes;
		}

		public void SetRecipeChange( string item_name, string[] changes ) {
			this.Data.RecipeChanges[item_name] = changes;
		}

		public void SetNpcChange( string npc_name, string[] changes ) {
			this.Data.NpcChanges[npc_name] = changes;
		}


		////////////////

		public void UnsetItemChange( string item_name ) {
			this.Data.ItemChanges.Remove( item_name );
		}

		public void UnsetRecipeChange( string item_name ) {
			this.Data.RecipeChanges.Remove( item_name );
		}

		public void UnsetNpcChange( string npc_name ) {
			this.Data.NpcChanges.Remove( npc_name );
		}


		////////////////

		public void ClearItemChanges() {
			this.Data.ItemChanges.Clear();
		}

		public void ClearRecipeChanges() {
			this.Data.RecipeChanges.Clear();
		}

		public void ClearNpcChanges() {
			this.Data.NpcChanges.Clear();
		}


		////////////////

		public bool IsActive() {
			return this.Data.IsActive;
		}

		public void Activate() {
			this.Data.IsActive = true;
		}

		public void Deactivate() {
			this.Data.IsActive = false;
		}


		////////////////

		public void SetCurrentChangesAsDefaults( GameChangerMod mymod ) {
			this.Data.SetCurrentChangesAsDefaults( mymod );
		}

		public void ResetChangesFromDefaults( GameChangerMod mymod ) {
			this.Data.ResetChangesFromDefaults( mymod );
		}
	}
}
