using HamstarHelpers.Helpers.ItemHelpers;
using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ModLoader;


namespace GameChanger.Commands {
	class ItemChangeSetCommand : ModCommand {
		public override string Command {
			get {
				return "gc-item-change";
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
				return "/" + this.Command + " 368 +damage=1";
			}
		}
		public override string Description {
			get {
				return "Adds an item change." + "\n   Parameters: <item id> <changes>";
			}
		}


		////////////////

		public override void Action( CommandCaller caller, string input, string[] args ) {
			if( args.Length == 0 ) {
				caller.Reply( "No item name specified.", Color.Yellow );
				return;
			}
			if( args.Length == 1 ) {
				caller.Reply( "No changes specified.", Color.Yellow );
				return;
			}

			var mymod = GameChangerMod.Instance;
			var myworld = mymod.GetModWorld<GameChangerWorld>();

			int ent_id = Int32.Parse( args[0] );
			string ent_name = ItemIdentityHelpers.GetQualifiedName( ent_id );
			string changes = args[1];

			myworld.Logic.DataAccess.SetItemChange( ent_name, changes );
			myworld.Logic.SyncDataChanges();

			caller.Reply( "Item " + ent_name + " changed.", Color.YellowGreen );
		}
	}
}
