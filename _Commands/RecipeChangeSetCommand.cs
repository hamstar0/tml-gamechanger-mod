using HamstarHelpers.Helpers.ItemHelpers;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;


namespace GameChanger.Commands {
	class RecipeChangeAddCommand : ModCommand {
		public override string Command {
			get {
				return "gc-recipe-change";
			}
		}
		public override CommandType Type {
			get {
				if( Main.netMode == 0 && !Main.dedServ ) {
					return CommandType.World;
				} else {
					return CommandType.Console;
				}
			}
		}
		public override string Usage {
			get {
				return "/" + this.Command + " 86 3507 1809";
			}
		}
		public override string Description {
			get {
				return "Adds a recipe change." + "\n   Parameters: <item-of-recipe id> <ingredient item id 1> <ingredient item id 2> ...";
			}
		}


		////////////////

		public override void Action( CommandCaller caller, string input, string[] args ) {
			if( args.Length == 0 ) {
				caller.Reply( "No NPC name specified.", Color.Yellow );
				return;
			}
			if( args.Length == 1 ) {
				caller.Reply( "No changes specified.", Color.Yellow );
				return;
			}
			
			var mymod = GameChangerMod.Instance;
			var myworld = mymod.GetModWorld<GameChangerWorld>();

			int base_item_id = Int32.Parse( args[0] );
			IEnumerable<int> ingredient_item_ids = args[1].Split( ' ' ).Select( s => Int32.Parse(s) );

			string base_item_name = ItemIdentityHelpers.GetQualifiedName( base_item_id );
			string[] ingredients = ingredient_item_ids.Select( idx=>ItemIdentityHelpers.GetQualifiedName(idx) ).ToArray();

			myworld.Logic.DataAccess.SetRecipeChange( base_item_name, ingredients );
			myworld.Logic.SyncDataChanges();

			caller.Reply( "Recipe for " + base_item_name + " changed.", Color.YellowGreen );
		}
	}
}
