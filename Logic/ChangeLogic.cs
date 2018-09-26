using HamstarHelpers.Helpers.DebugHelpers;
using System;


namespace GameChanger.Logic {
	partial class ChangeLogic {
		// TODO: Transfer to Mod Helpers
		public static object ParseAsObject( Type parse_type, string raw_value, out bool success ) {
			success = true;

			switch( Type.GetTypeCode( parse_type ) ) {
			case TypeCode.String:
				return raw_value;
			case TypeCode.Single:
				Single single_value;
				success = Single.TryParse( raw_value, out single_value );
				return single_value;
			case TypeCode.UInt64:
				UInt64 uint64_value;
				success = UInt64.TryParse( raw_value, out uint64_value );
				return uint64_value;
			case TypeCode.Int64:
				Int64 int64_value;
				success = Int64.TryParse( raw_value, out int64_value );
				return int64_value;
			case TypeCode.UInt32:
				UInt32 uint32_value;
				success = UInt32.TryParse( raw_value, out uint32_value );
				return uint32_value;
			case TypeCode.Int32:
				Int32 int32_value;
				success = Int32.TryParse( raw_value, out int32_value );
				return int32_value;
			case TypeCode.UInt16:
				UInt16 uint16_value;
				success = UInt16.TryParse( raw_value, out uint16_value );
				return uint16_value;
			case TypeCode.Int16:
				Int16 int16_value;
				success = Int16.TryParse( raw_value, out int16_value );
				return int16_value;
			case TypeCode.Double:
				Double double_value;
				success = Double.TryParse( raw_value, out double_value );
				return double_value;
			case TypeCode.Char:
				Char char_value;
				success = Char.TryParse( raw_value, out char_value );
				return char_value;
			case TypeCode.SByte:
				SByte sbyte_value;
				success = SByte.TryParse( raw_value, out sbyte_value );
				return sbyte_value;
			case TypeCode.Byte:
				Byte byte_value;
				success = Byte.TryParse( raw_value, out byte_value );
				return byte_value;
			case TypeCode.Boolean:
				Boolean bool_value;
				success = Boolean.TryParse( raw_value, out bool_value );
				return bool_value;
			case TypeCode.Decimal:
				Decimal decimal_value;
				success = Decimal.TryParse( raw_value, out decimal_value );
				return decimal_value;
			case TypeCode.Object:
				return raw_value;
			default:
				success = false;
				return null;
			}
		}


		public static object Add( object l_val, object r_val ) {
			switch( Type.GetTypeCode( l_val.GetType() ) ) {
			case TypeCode.String:
			case TypeCode.Single:
			case TypeCode.UInt64:
			case TypeCode.Int64:
			case TypeCode.UInt32:
			case TypeCode.Int32:
			case TypeCode.UInt16:
			case TypeCode.Int16:
			case TypeCode.Double:
			case TypeCode.Decimal:
			case TypeCode.SByte:
			case TypeCode.Byte:
				return (dynamic)l_val + (dynamic)r_val;
			default:
				return l_val ?? r_val;
			}
		}

		public static object Sub( object l_val, object r_val ) {
			switch( Type.GetTypeCode( l_val.GetType() ) ) {
			//case TypeCode.String:
			case TypeCode.Single:
			case TypeCode.UInt64:
			case TypeCode.Int64:
			case TypeCode.UInt32:
			case TypeCode.Int32:
			case TypeCode.UInt16:
			case TypeCode.Int16:
			case TypeCode.Double:
			case TypeCode.Decimal:
			case TypeCode.SByte:
			case TypeCode.Byte:
				return (dynamic)l_val - (dynamic)r_val;
			default:
				return l_val ?? r_val;
			}
		}

		public static object Mul( object l_val, object r_val ) {
			switch( Type.GetTypeCode( l_val.GetType() ) ) {
			//case TypeCode.String:
			case TypeCode.Single:
			case TypeCode.UInt64:
			case TypeCode.Int64:
			case TypeCode.UInt32:
			case TypeCode.Int32:
			case TypeCode.UInt16:
			case TypeCode.Int16:
			case TypeCode.Double:
			case TypeCode.Decimal:
			case TypeCode.SByte:
			case TypeCode.Byte:
				return (dynamic)l_val * (dynamic)r_val;
			default:
				return l_val ?? r_val;
			}
		}

		public static object Div( object l_val, object r_val ) {
			switch( Type.GetTypeCode( l_val.GetType() ) ) {
			//case TypeCode.String:
			case TypeCode.Single:
			case TypeCode.UInt64:
			case TypeCode.Int64:
			case TypeCode.UInt32:
			case TypeCode.Int32:
			case TypeCode.UInt16:
			case TypeCode.Int16:
			case TypeCode.Double:
			case TypeCode.Decimal:
			case TypeCode.SByte:
			case TypeCode.Byte:
				return (dynamic)l_val / (dynamic)r_val;
			default:
				return l_val ?? r_val;
			}
		}
	}
}
