using HamstarHelpers.Helpers.DebugHelpers;
using HamstarHelpers.Helpers.ItemHelpers;
using System.Collections.Generic;
using System.Linq;
using Terraria;


namespace GameChanger.Logic {
	partial class WorldLogic {
		public void ApplyItemChanges( Item item ) {
			ISet<string> changes = this.DataAccess.GetItemChanges( item );

			foreach( string change in changes ) {
				ChangeLogic.ApplyChange( item.GetType(), item, item.Name, change );
			}
		}


		public void ApplyNpcChanges( NPC npc ) {
			ISet<string> changes = this.DataAccess.GetNpcChanges( npc );

			foreach( string change in changes ) {
				ChangeLogic.ApplyChange( npc.GetType(), npc, npc.TypeName, change );
			}
		}


		public void ApplyRecipeChanges( Item item ) {
			ISet<string> changes = this.DataAccess.GetRecipeChanges( item );
			IList<Recipe> recipes = ChangeLogic.GetRecipesOfItem( item.type );
			
			foreach( string change in changes ) {
				if( change[0] != '+' || change[0] != '-' ) {
					LogHelpers.Log( "GameChanger.WorldLogic.ApplyRecipeChanges - Invalid recipe ("+item.Name+") ingredient change item " + change );
					continue;
				}

				string ingredient_item_name = change.Substring( 1 );
				if( !ItemIdentityHelpers.NamesToIds.ContainsKey(ingredient_item_name) ) {
					//LogHelpers.Log( "GameChanger.WorldLogic.ApplyRecipeChanges - Invalid recipe ("+item.Name+") ingredient item "+ingredient_item_name );
					continue;
				}

				int ingredient_item_type = ItemIdentityHelpers.NamesToIds[ ingredient_item_name ];
				Item ingredient_item = new Item();
				ingredient_item.SetDefaults( ingredient_item_type, true );

				IList<Item> ingredients;

				foreach( Recipe recipe in recipes ) {
					ingredients = recipe.requiredItem.ToList();

					if( change[0] == '+' ) {
						ingredients.Add( ingredient_item );
					} else {
						ingredients = ingredients.Where( i => i.type != ingredient_item_type ).ToList();
					}

					recipe.requiredItem = ingredients.ToArray();
				}
			}
		}
	}
}
