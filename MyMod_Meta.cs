using GameChanger.Data;
using HamstarHelpers.Components.Config;
using HamstarHelpers.Helpers.DebugHelpers;
using System;
using System.IO;
using Terraria;
using Terraria.ModLoader;


namespace GameChanger {
	partial class GameChangerMod : Mod {
		public static string GithubUserName { get { return "hamstar0"; } }
		public static string GithubProjectName { get { return "tml-gamechanger-mod"; } }



		////////////////

		public static string ConfigFileRelativePath {
			get { return JsonConfig.ConfigSubfolder + Path.DirectorySeparatorChar + GameChangerConfigData.ConfigFileName; }
		}

		public static void ReloadConfigFromFile() {
			if( Main.netMode != 0 ) {
				throw new Exception( "Cannot reload configs outside of single player." );
			}
			if( GameChangerMod.Instance != null ) {
				if( !GameChangerMod.Instance.ConfigJson.LoadFile() ) {
					GameChangerMod.Instance.ConfigJson.SaveFile();
				}
			}
		}

		public static void ResetConfigFromDefaults() {
			if( Main.netMode != 0 ) {
				throw new Exception( "Cannot reset to default configs outside of single player." );
			}

			var config_data = new GameChangerConfigData();
			config_data.SetDefaults();

			GameChangerMod.Instance.ConfigJson.SetData( config_data );
			GameChangerMod.Instance.ConfigJson.SaveFile();
		}
	}
}
