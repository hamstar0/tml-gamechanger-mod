using System;


namespace GameChanger {
	public static partial class GameChangerAPI {
		internal static object Call( string call_type, params object[] args ) {
			string ent_name, changes;
			bool local_only;
			
			switch( call_type ) {
			case "GetModSettings":
				return GameChangerAPI.GetModSettings();
			case "SaveModSettingsChanges":
				GameChangerAPI.SaveModSettingsChanges();
				return null;

			case "ChangeCurrentWorld":
				return GameChangerAPI.ChangeCurrentWorld();
			case "RevertCurrentWorld":
				return GameChangerAPI.RevertCurrentWorld();

			case "SuppressAutoSavingOn":
				GameChangerAPI.SuppressAutoSavingOn();
				return null;
			case "SuppressAutoSavingOff":
				GameChangerAPI.SuppressAutoSavingOff();
				return null;
			
			////

			case "SetItemChange":
				if( args.Length < 3 ) { throw new Exception( "Insufficient parameters for API call " + call_type ); }

				ent_name = args[0] as string;
				if( ent_name == null ) { throw new Exception( "Invalid parameter ent_name for API call " + call_type ); }

				changes = args[1] as string;
				if( changes == null ) { throw new Exception( "Invalid parameter changes for API call " + call_type ); }

				if( !(args[2] is bool) ) { throw new Exception( "Invalid parameter local_only for API call " + call_type ); }
				local_only = (bool)args[2];

				GameChangerAPI.SetItemChange( ent_name, changes, local_only );
				return null;
			case "SetRecipeChange":
				if( args.Length < 3 ) { throw new Exception( "Insufficient parameters for API call " + call_type ); }

				ent_name = args[0] as string;
				if( ent_name == null ) { throw new Exception( "Invalid parameter ent_name for API call " + call_type ); }

				changes = args[1] as string;
				if( changes == null ) { throw new Exception( "Invalid parameter changes for API call " + call_type ); }

				if( !( args[2] is bool ) ) { throw new Exception( "Invalid parameter local_only for API call " + call_type ); }
				local_only = (bool)args[2];

				GameChangerAPI.SetRecipeChange( ent_name, changes, local_only );
				return null;
			case "SetNpcChange":
				if( args.Length < 3 ) { throw new Exception( "Insufficient parameters for API call " + call_type ); }

				ent_name = args[0] as string;
				if( ent_name == null ) { throw new Exception( "Invalid parameter ent_name for API call " + call_type ); }

				changes = args[1] as string;
				if( changes == null ) { throw new Exception( "Invalid parameter changes for API call " + call_type ); }

				if( !( args[2] is bool ) ) { throw new Exception( "Invalid parameter local_only for API call " + call_type ); }
				local_only = (bool)args[2];

				GameChangerAPI.SetNpcChange( ent_name, changes, local_only );
				return null;
			
			////

			case "UnsetItemChange":
				if( args.Length < 2 ) { throw new Exception( "Insufficient parameters for API call " + call_type ); }

				ent_name = args[0] as string;
				if( ent_name == null ) { throw new Exception( "Invalid parameter ent_name for API call " + call_type ); }

				if( !( args[1] is bool ) ) { throw new Exception( "Invalid parameter local_only for API call " + call_type ); }
				local_only = (bool)args[1];

				GameChangerAPI.UnsetItemChange( ent_name, local_only );
				return null;
			case "UnsetRecipeChange":
				if( args.Length < 2 ) { throw new Exception( "Insufficient parameters for API call " + call_type ); }

				ent_name = args[0] as string;
				if( ent_name == null ) { throw new Exception( "Invalid parameter ent_name for API call " + call_type ); }

				if( !( args[1] is bool ) ) { throw new Exception( "Invalid parameter local_only for API call " + call_type ); }
				local_only = (bool)args[1];

				GameChangerAPI.UnsetRecipeChange( ent_name, local_only );
				return null;
			case "UnsetNpcChange":
				if( args.Length < 2 ) { throw new Exception( "Insufficient parameters for API call " + call_type ); }

				ent_name = args[0] as string;
				if( ent_name == null ) { throw new Exception( "Invalid parameter ent_name for API call " + call_type ); }

				if( !( args[1] is bool ) ) { throw new Exception( "Invalid parameter local_only for API call " + call_type ); }
				local_only = (bool)args[1];

				GameChangerAPI.UnsetNpcChange( ent_name, local_only );
				return null;

			////

			case "ClearItemChanges":
				if( args.Length < 1 ) { throw new Exception( "Insufficient parameters for API call " + call_type ); }
				
				if( !( args[1] is bool ) ) { throw new Exception( "Invalid parameter local_only for API call " + call_type ); }
				local_only = (bool)args[1];

				GameChangerAPI.ClearItemChanges( local_only );
				return null;
			case "ClearRecipeChanges":
				if( args.Length < 1 ) { throw new Exception( "Insufficient parameters for API call " + call_type ); }

				if( !( args[1] is bool ) ) { throw new Exception( "Invalid parameter local_only for API call " + call_type ); }
				local_only = (bool)args[1];

				GameChangerAPI.ClearRecipeChanges( local_only );
				return null;
			case "ClearNpcChanges":
				if( args.Length < 1 ) { throw new Exception( "Insufficient parameters for API call " + call_type ); }

				if( !( args[1] is bool ) ) { throw new Exception( "Invalid parameter local_only for API call " + call_type ); }
				local_only = (bool)args[1];

				GameChangerAPI.ClearNpcChanges( local_only );
				return null;

			////

			case "SetCurrentChangesAsDefaults":
				GameChangerAPI.SetCurrentChangesAsDefaults();
				return null;
			case "ResetChangesFromDefaults":
				GameChangerAPI.ResetChangesFromDefaults();
				return null;
			}

			throw new Exception( "No such api call " + call_type );
		}
	}
}
