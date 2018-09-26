using GameChanger.Data;
using HamstarHelpers.Components.Config;
using Terraria.ModLoader;


namespace GameChanger {
	partial class GameChangerMod : Mod {
		public static GameChangerMod Instance;



		////////////////

		internal JsonConfig<GameChangerConfigData> ConfigJson;
		public GameChangerConfigData Config { get { return ConfigJson.Data; } }

		public bool SuppressAutoSaving { get; internal set; }



		////////////////

		public GameChangerMod() {
			this.SuppressAutoSaving = false;

			this.ConfigJson = new JsonConfig<GameChangerConfigData>( GameChangerConfigData.ConfigFileName,
					ConfigurationDataBase.RelativePath, new GameChangerConfigData() );
		}

		////////////////

		public override void Load() {
			GameChangerMod.Instance = this;

			this.LoadConfigs();
		}

		private void LoadConfigs() {
			if( !this.ConfigJson.LoadFile() ) {
				this.ConfigJson.SaveFile();
			}

			if( this.Config.UpdateToLatestVersion( this ) ) {
				ErrorLogger.Log( "Game Changer updated to " + this.Version.ToString() );
				this.ConfigJson.SaveFile();
			}
		}

		public override void Unload() {
			GameChangerMod.Instance = null;
		}
	}
}
