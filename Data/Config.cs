using HamstarHelpers.Components.Config;
using System;
using System.Collections.Generic;


namespace GameChanger.Data {
	public class GameChangerConfigData : ConfigurationDataBase {
		public readonly static string ConfigFileName = "Game Changer Config.json";


		
		////////////////

		public string VersionSinceUpdate = new Version(0,0,0,0).ToString();

		public bool DebugModeInfo = false;

		public IDictionary<string, string> DefaultItemChanges = new Dictionary<string, string> { };
		public IDictionary<string, string> DefaultRecipeChanges = new Dictionary<string, string> { };
		public IDictionary<string, string> DefaultNpcChanges = new Dictionary<string, string> { };

		public bool EnableItemChanges = false;
		public bool EnableRecipeChanges = false;
		public bool EnableNpcChanges = false;



		////////////////
		
		public void SetDefaults() {
			this.DefaultItemChanges.Clear();
			this.DefaultRecipeChanges.Clear();
			this.DefaultNpcChanges.Clear();

			this.DefaultItemChanges["Any Equipment"] = "+damage=1";
			this.DefaultRecipeChanges["Any Equipment"] = "+Dirt Block";
			this.DefaultNpcChanges["Any Hostile NPC"] = "-lifeMax=1";
		}


		internal bool UpdateToLatestVersion( GameChangerMod mymod ) {
			var new_config = new GameChangerConfigData();
			var vers_since = this.VersionSinceUpdate != "" ?
				new Version( this.VersionSinceUpdate ) :
				new Version();

			if( vers_since >= mymod.Version ) {
				return false;
			}

			if( vers_since < new Version( 1, 0, 0, 0 ) ) {
				this.SetDefaults();
			}

			this.VersionSinceUpdate = mymod.Version.ToString();

			return true;
		}
	}
}
