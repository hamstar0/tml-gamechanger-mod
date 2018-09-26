using Terraria;
using Terraria.ModLoader;


namespace GameChanger {
	class GameChangerNPC : GlobalNPC {
		private bool IsAltered = false;
		
		////////////////

		public override bool InstancePerEntity => true;



		////////////////
		
		public override GlobalNPC Clone() {
			var clone = (GameChangerNPC)base.Clone();
			clone.IsAltered = this.IsAltered;
			return clone;
		}


		////////////////

		public override bool PreAI( NPC npc ) {
			var mymod = GameChangerMod.Instance;
			var myworld = mymod.GetModWorld<GameChangerWorld>();

			if( myworld.Logic.AreNpcChangesEnabled(mymod) ) {
				if( !this.IsAltered ) {
					this.IsAltered = true;

					if( myworld.Logic.DataAccess.GetNpcChanges(npc).Count > 0 ) {
						myworld.Logic.ApplyNpcChanges(npc);
					}
				}
			}

			return base.PreAI( npc );
		}
	}
}
