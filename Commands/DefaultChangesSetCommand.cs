﻿using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;


namespace GameChanger.Commands {
	class DefaultChangesSetCommand : ModCommand {
		public override string Command {
			get {
				return "gc-defaults-set";
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
				return "Set current changes as the initial defaults for every world.";
			}
		}


		////////////////

		public override void Action( CommandCaller caller, string input, string[] args ) {
			GameChangerAPI.SetCurrentChangesAsDefaults();

			caller.Reply( "Current world's changes as the new defaults.", Color.YellowGreen );
		}
	}
}
