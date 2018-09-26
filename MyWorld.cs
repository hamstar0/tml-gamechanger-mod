using HamstarHelpers.Helpers.DebugHelpers;
using GameChanger.Logic;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;


namespace GameChanger {
	class GameChangerWorld : ModWorld {
		public WorldLogic Logic;



		////////////////

		public override void Initialize() {
			var mymod = (GameChangerMod)this.mod;

			this.Logic = new WorldLogic( mymod );
			
			if( mymod.Config.DebugModeInfo ) {
				LogHelpers.Log( "Game Changer - World initialized." );
			}
		}

		public override void Load( TagCompound tag ) {
			var mymod = (GameChangerMod)this.mod;
			this.Logic.LoadWorldData( mymod );
		}

		public override TagCompound Save() {
			var mymod = (GameChangerMod)this.mod;
			if( !mymod.SuppressAutoSaving ) {
				this.Logic.SaveWorldData( mymod );
			}
			return new TagCompound();
		}
	}
}
