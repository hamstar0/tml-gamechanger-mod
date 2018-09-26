using HamstarHelpers.Components.Network;
using HamstarHelpers.Components.Network.Data;
using GameChanger.Data;
using System;
using Terraria;


namespace GameChanger.NetProtocol {
	class ChangesProtocol : PacketProtocol {
		public GameChangerChangesData Filters;



		////////////////

		private ChangesProtocol( PacketProtocolDataConstructorLock ctor_lock ) { }
		
		////////////////

		private void SetMyDefaults() {
			var myworld = GameChangerMod.Instance.GetModWorld<GameChangerWorld>();
			if( myworld.Logic.DataAccess == null ) { throw new Exception( "No filters to send" ); }

			myworld.Logic.DataAccess.Give( ref this.Filters );
		}

		protected override void SetClientDefaults() {
			this.SetMyDefaults();
		}
		protected override void SetServerDefaults( int to_who ) {
			this.SetMyDefaults();
		}


		////////////////

		private void ReceiveOnAny() {
			var mymod = GameChangerMod.Instance;
			var myworld = mymod.GetModWorld<GameChangerWorld>();

			myworld.Logic.DataAccess.Take( this.Filters );
		}

		////////////////

		protected override void ReceiveWithServer( int from_who ) {
			this.ReceiveOnAny();
		}

		protected override void ReceiveWithClient() {
			this.ReceiveOnAny();

			var mymod = GameChangerMod.Instance;
			var myworld = mymod.GetModWorld<GameChangerWorld>();
			var myplayer = Main.LocalPlayer.GetModPlayer<GameChangerPlayer>();

			myworld.Logic.PostChangesLoad( mymod );

			myplayer.FinishChangesSync();
		}
	}
}
