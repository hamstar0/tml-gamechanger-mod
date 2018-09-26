using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;


namespace GameChanger.Commands {
	class GameChangerOffCommand : ModCommand {
		public override string Command {
			get {
				return "gc-off";
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
				return "Deactivates Game Changer mod for the current world.";
			}
		}


		////////////////

		public override void Action( CommandCaller caller, string input, string[] args ) {
			var myworld = this.mod.GetModWorld<GameChangerWorld>();

			if( GameChangerAPI.RevertCurrentWorld() ) {
				caller.Reply( "Game Changer removed from current world.", Color.LimeGreen );
			} else {
				caller.Reply( "Game Changer already removed from current world.", Color.Yellow );
				return;
			}
		}
	}
}
