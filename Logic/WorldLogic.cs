using HamstarHelpers.Components.Network;
using HamstarHelpers.Helpers.DebugHelpers;
using HamstarHelpers.Services.Messages;
using HamstarHelpers.Services.Promises;
using GameChanger.Data;
using GameChanger.NetProtocol;
using Terraria;


namespace GameChanger.Logic {
	partial class WorldLogic {
		internal readonly static object MyValidatorKey;
		public readonly static PromiseValidator LoadAllValidator;


		////////////////

		static WorldLogic() {
			WorldLogic.MyValidatorKey = new object();
			WorldLogic.LoadAllValidator = new PromiseValidator( WorldLogic.MyValidatorKey );
		}


		////////////////
		public GameChangerChangesAccess DataAccess { get; private set; }


		////////////////

		public WorldLogic( GameChangerMod mymod ) {
			this.DataAccess = new GameChangerChangesAccess();
		}


		////////////////
		
		public void LoadWorldData( GameChangerMod mymod ) {
			this.DataAccess.Load( mymod );
		}

		public void SaveWorldData( GameChangerMod mymod ) {
			this.DataAccess.Save( mymod );
		}
		

		////////////////

		internal void PostChangesLoad( GameChangerMod mymod ) {
			Promises.AddWorldLoadOncePromise( () => {
				if( Main.netMode == 2 ) { return; }

				var myworld = mymod.GetModWorld<GameChangerWorld>();

				if( !myworld.Logic.DataAccess.IsActive() ) {
					string msg;
					if( Main.netMode == 0 ) {
						msg = "Enter the /gcon command to active Game Changer changes for this world. Enter /help for a list of other commands.";
					} else {
						msg = "Enter gcon in the server's command console to activate Game Changer changes restrictions for this world. Enter help for a list of other commands.";
					}

					InboxMessages.SetMessage( "GameChangerInit", msg, false );
				}

				Promises.TriggerValidatedPromise( WorldLogic.LoadAllValidator, WorldLogic.MyValidatorKey );
				Promises.AddWorldUnloadOncePromise( () => {
					Promises.ClearValidatedPromise( WorldLogic.LoadAllValidator, WorldLogic.MyValidatorKey );
				} );
			} );
		}


		////////////////

		public void SyncDataChanges() {
			var mymod = GameChangerMod.Instance;

			if( Main.netMode == 1 ) {
				PacketProtocol.QuickSyncToServerAndClients<ChangesProtocol>();
			} else if( Main.netMode == 2 ) {
				if( !mymod.SuppressAutoSaving ) {
					this.SaveWorldData( GameChangerMod.Instance );
				}
				PacketProtocol.QuickSendToClient<ChangesProtocol>( -1, -1 );
			}
		}


		////////////////
		
		public bool AreItemChangesEnabled( GameChangerMod mymod ) {
			return this.DataAccess.IsActive() && mymod.Config.EnableItemChanges;
		}

		public bool AreRecipesChangesEnabled( GameChangerMod mymod ) {
			return this.DataAccess.IsActive() && mymod.Config.EnableRecipeChanges;
		}

		public bool AreNpcsChangesEnabled( GameChangerMod mymod ) {
			return this.DataAccess.IsActive() && mymod.Config.EnableNpcChanges;
		}
	}
}
