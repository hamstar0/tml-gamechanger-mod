using HamstarHelpers.Helpers.DebugHelpers;
using HamstarHelpers.Helpers.ItemHelpers;
using HamstarHelpers.Helpers.NPCHelpers;
using HamstarHelpers.Services.EntityGroups;
using System.Collections.Generic;
using Terraria;


namespace GameChanger.Data {
	partial class GameChangerChangesAccess {
		internal ISet<string> GetItemChanges( Item item ) {
			string name = ItemIdentityHelpers.GetQualifiedName( item );
			ISet<string> changes = new HashSet<string>();

			if( this.Data.ItemChanges.ContainsKey( name ) ) {
				changes.UnionWith( this.Data.ItemChanges[ name ] );
			}
			
			if( !EntityGroups.GroupsPerItem.ContainsKey( item.type ) ) {
				return changes;
			}

			foreach( string grp_name in EntityGroups.GroupsPerItem[item.type] ) {
				if( this.Data.ItemChanges.ContainsKey( grp_name ) ) {
					changes.UnionWith( this.Data.ItemChanges[grp_name] );
				}
			}

			return changes;
		}

		private ISet<string> GetRecipeChanges( Item item ) {
			string name = ItemIdentityHelpers.GetQualifiedName( item );
			ISet<string> changes = new HashSet<string>();

			if( this.Data.RecipeChanges.ContainsKey( name ) ) {
				changes.UnionWith( this.Data.RecipeChanges[name] );
			}

			if( !EntityGroups.GroupsPerItem.ContainsKey( item.type ) ) {
				return changes;
			}

			foreach( string grp_name in EntityGroups.GroupsPerItem[item.type] ) {
				if( this.Data.RecipeChanges.ContainsKey( grp_name ) ) {
					changes.UnionWith( this.Data.RecipeChanges[grp_name] );
				}
			}

			return changes;
		}

		private ISet<string> IsNpcBlacklisted( NPC npc ) {
			string name = NPCIdentityHelpers.GetQualifiedName( npc );
			ISet<string> changes = new HashSet<string>();

			if( this.Data.NpcChanges.ContainsKey( name ) ) {
				changes.UnionWith( this.Data.NpcChanges[name] );
			}

			if( !EntityGroups.GroupsPerNPC.ContainsKey( npc.type ) ) {
				return changes;
			}

			foreach( string grp_name in EntityGroups.GroupsPerNPC[npc.type] ) {
				if( this.Data.NpcChanges.ContainsKey( grp_name ) ) {
					changes.UnionWith( this.Data.NpcChanges[grp_name] );
				}
			}

			return changes;
		}
	}
}
