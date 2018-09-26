using HamstarHelpers.Helpers.DebugHelpers;
using Terraria;
using Terraria.ModLoader;


namespace GameChanger.Commands {
	class ShowChangesCommand : ModCommand {
		public override string Command {
			get {
				return "gc-show-filters";
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
				return "Displays each change currently active for the world.";
			}
		}


		////////////////

		public override void Action( CommandCaller caller, string input, string[] args ) {
			var myworld = this.mod.GetModWorld<GameChangerWorld>();
			myworld.Logic.DataAccess.OutputChanges();
		}
	}
}
