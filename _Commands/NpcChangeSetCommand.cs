using HamstarHelpers.Helpers.NPCHelpers;
using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ModLoader;


namespace GameChanger.Commands {
	class NpcChangeSetCommand : ModCommand {
		public override string Command {
			get {
				return "gc-npc-change";
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
				return "/" + this.Command + " 86 +damage=1";
			}
		}
		public override string Description {
			get {
				return "Adds an NPC change." + "\n   Parameters: <npc id> <changes>";
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

			int ent_id = Int32.Parse( args[0] );
			string ent_name = NPCIdentityHelpers.GetQualifiedName( ent_id );
			string changes = args[1];

			myworld.Logic.DataAccess.SetNpcChange( ent_name, changes );
			myworld.Logic.SyncDataChanges();

			caller.Reply( "NPC " + ent_name + " changed.", Color.YellowGreen );
		}
	}
}
