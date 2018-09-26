using HamstarHelpers.Helpers.DebugHelpers;
using Microsoft.Xna.Framework;
using System;
using System.Reflection;
using Terraria;


namespace GameChanger.Logic {
	partial class ChangeLogic {
		public static void ApplyChange( Type ent_type, Entity ent, string ent_name, string change ) {
			string[] segs = change.Split( '=' );
			if( segs.Length != 2 ) {
				string msg = "Invalid change for " + ent_name + ": " + change;
				Main.NewText( msg, Color.Red );
				LogHelpers.Log( msg );
				return;
			}

			string field_name = segs[0];
			string raw_value = segs[1];

			char op = segs[0][0];
			switch( op ) {
			case '-':
			case '+':
			case '*':
			case '/':
				field_name = field_name.Substring( 1 );
				break;
			default:
				op = '_';
				break;
			}
			
			FieldInfo field = ent_type.GetField( field_name );
			if( field == null ) {
				string msg = "Invalid field for (" + ent_name + "): " + field_name;
				Main.NewText( msg, Color.Red );
				LogHelpers.Log( msg );
				return;
			}

			bool _;
			object value = ChangeLogic.ParseAsObject( field.FieldType, raw_value, out _ );

			if( value != null ) {
				switch( op ) {
				case '-':
					field.SetValue( ent, ChangeLogic.Sub(field.GetValue(ent), value) );
					break;
				case '+':
					field.SetValue( ent, ChangeLogic.Add(field.GetValue( ent ), value) );
					break;
				case '*':
					field.SetValue( ent, ChangeLogic.Mul(field.GetValue( ent ), value) );
					break;
				case '/':
					field.SetValue( ent, ChangeLogic.Div(field.GetValue( ent ), value) );
					break;
				default:
					field.SetValue( ent, value );
					break;
				}
			}
		}
	}
}
