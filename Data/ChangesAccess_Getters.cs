﻿using HamstarHelpers.Helpers.DebugHelpers;
using HamstarHelpers.Helpers.ItemHelpers;
using HamstarHelpers.Helpers.NPCHelpers;
using HamstarHelpers.Services.EntityGroups;
using Terraria;


namespace GameChanger.Data {
	partial class GameChangerChangesAccess {
		internal bool IsItemChanged( Item item ) {
			string name = ItemIdentityHelpers.GetQualifiedName( item );

			if( this.Data.ItemChanges.ContainsKey( name ) ) {
				return true;
			}
			
			if( !EntityGroups.GroupsPerItem.ContainsKey( item.type ) ) {
				return false;
			}

			foreach( string grp_name in EntityGroups.GroupsPerItem[item.type] ) {
				if( this.Data.ItemChanges.ContainsKey( grp_name ) ) {
					return true;
				}
			}

			return false;
		}

		private bool IsRecipeChanged( Item item ) {
			string name = ItemIdentityHelpers.GetQualifiedName( item );

			if( this.Data.RecipeChanges.ContainsKey( name ) ) {
				return true;
			}

			if( !EntityGroups.GroupsPerItem.ContainsKey( item.type ) ) {
				return false;
			}

			foreach( string grp_name in EntityGroups.GroupsPerItem[item.type] ) {
				if( this.Data.RecipeChanges.ContainsKey( grp_name ) ) {
					return true;
				}
			}

			return false;
		}

		private bool IsNpcBlacklisted( NPC npc ) {
			string name = NPCIdentityHelpers.GetQualifiedName( npc );

			if( this.Data.NpcChanges.ContainsKey( name ) ) {
				return true;
			}

			if( !EntityGroups.GroupsPerNPC.ContainsKey( npc.type ) ) {
				return false;
			}

			foreach( string grp_name in EntityGroups.GroupsPerNPC[npc.type] ) {
				if( this.Data.NpcChanges.ContainsKey( grp_name ) ) {
					return true;
				}
			}

			return false;
		}
	}
}