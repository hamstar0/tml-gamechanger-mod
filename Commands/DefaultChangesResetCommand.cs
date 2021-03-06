﻿using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;


namespace GameChanger.Commands {
	class DefaultChangesResetCommand : ModCommand {
		public override string Command {
			get {
				return "gc-defaults-reset";
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
				return "Sets default config's changes to override the current world's.";
			}
		}


		////////////////

		public override void Action( CommandCaller caller, string input, string[] args ) {
			GameChangerAPI.ResetChangesFromDefaults();

			caller.Reply( "Current world's changes reset to defaults.", Color.YellowGreen );
		}
	}
}
