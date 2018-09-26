using HamstarHelpers.Helpers.DebugHelpers;
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
			bool replaces = changes.All( s => s[0] == '+' || s[0] == '-' || s[0] == '*' || s[0] == '/' );

			if( replaces ) {
				foreach( string change in changes ) {
					string real_change = change.Substring( 1 );

				}
			}
		}
	}
}
