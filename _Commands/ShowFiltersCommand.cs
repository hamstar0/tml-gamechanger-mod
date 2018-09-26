using HamstarHelpers.Helpers.DebugHelpers;
using Terraria;
using Terraria.ModLoader;


namespace GameChanger.Commands {
	class ShowFiltersCommand : ModCommand {
		public override string Command {
			get {
				return "nih-show-filters";
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
				return "Displays each filter currently active or the world.";
			}
		}


		////////////////

		public override void Action( CommandCaller caller, string input, string[] args ) {
			var myworld = this.mod.GetModWorld<NihilismWorld>();
			myworld.Logic.DataAccess.OutputFilters();
		}
	}
}
