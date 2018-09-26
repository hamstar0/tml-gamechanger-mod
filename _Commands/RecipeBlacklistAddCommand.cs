using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;


namespace GameChanger.Commands {
	class RecipeBlacklistAddCommand : ModCommand {
		public override string Command {
			get {
				return "nih-recipe-blacklist-add";
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
				return "/" + this.Command + " Excalibur";
			}
		}
		public override string Description {
			get {
				return "Adds a recipe to the blacklist (checked before whitelist).";
			}
		}


		////////////////

		public override void Action( CommandCaller caller, string input, string[] args ) {
			if( args.Length == 0 ) {
				caller.Reply( "No item name specified.", Color.Yellow );
				return;
			}

			var mymod = NihilismMod.Instance;
			var myworld = mymod.GetModWorld<NihilismWorld>();
			string ent_name = string.Join( " ", args );

			myworld.Logic.DataAccess.SetRecipeBlacklistEntry( ent_name );
			myworld.Logic.SyncDataChanges();

			caller.Reply( "Recipe for item " + ent_name + " added to blacklist.", Color.YellowGreen );
		}
	}
}
