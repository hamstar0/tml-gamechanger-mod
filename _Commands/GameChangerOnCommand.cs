using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;


namespace GameChanger.Commands {
	class GameChangerOnCommand : ModCommand {
		public override string Command {
			get {
				return "gc-on";
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
				return "/" + this.Command;
			}
		}
		public override string Description {
			get {
				return "Activates Game Changer mod for the current world. Use /help and the arrow keys to see a list of commands to adjust available items, npcs, and recipes.";
			}
		}


		////////////////

		public override void Action( CommandCaller caller, string input, string[] args ) {
			var myworld = this.mod.GetModWorld<GameChangerWorld>();

			if( GameChangerAPI.ChangeCurrentWorld() ) {
				caller.Reply( "Game Changer applied to current world. Type /gc-off to revert.", Color.LimeGreen );
			}  else {
				caller.Reply( "Game Changer already applied to current world.", Color.Yellow );
			}
		}
	}
}
