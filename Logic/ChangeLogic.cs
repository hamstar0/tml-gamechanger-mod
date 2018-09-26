﻿using HamstarHelpers.Helpers.DebugHelpers;
using System;


namespace GameChanger.Logic {
	partial class ChangeLogic {
		// TODO: Transfer to Mod Helpers
		public static object ParseAsObject( Type parse_type, string raw_value, out bool success ) {
			object value = null;
			success = true;

			switch( Type.GetTypeCode( parse_type ) ) {
			case TypeCode.String:
				value = raw_value;
				break;
			case TypeCode.Single:
				Single single_value;
				success = Single.TryParse( raw_value, out single_value );
				value = single_value;
				break;
			case TypeCode.UInt64:
				UInt64 uint64_value;
				success = UInt64.TryParse( raw_value, out uint64_value );
				value = uint64_value;
				break;
			case TypeCode.Int64:
				Int64 int64_value;
				success = Int64.TryParse( raw_value, out int64_value );
				value = int64_value;
				break;
			case TypeCode.UInt32:
				UInt32 uint32_value;
				success = UInt32.TryParse( raw_value, out uint32_value );
				value = uint32_value;
				break;
			case TypeCode.Int32:
				Int32 int32_value;
				success = Int32.TryParse( raw_value, out int32_value );
				value = int32_value;
				break;
			case TypeCode.UInt16:
				UInt16 uint16_value;
				success = UInt16.TryParse( raw_value, out uint16_value );
				value = uint16_value;
				break;
			case TypeCode.Int16:
				Int16 int16_value;
				success = Int16.TryParse( raw_value, out int16_value );
				value = int16_value;
				break;
			case TypeCode.Double:
				Double double_value;
				success = Double.TryParse( raw_value, out double_value );
				value = double_value;
				break;
			case TypeCode.Char:
				Char char_value;
				success = Char.TryParse( raw_value, out char_value );
				value = char_value;
				break;
			case TypeCode.SByte:
				SByte sbyte_value;
				success = SByte.TryParse( raw_value, out sbyte_value );
				value = sbyte_value;
				break;
			case TypeCode.Byte:
				Byte byte_value;
				success = Byte.TryParse( raw_value, out byte_value );
				value = byte_value;
				break;
			case TypeCode.Boolean:
				Boolean bool_value;
				success = Boolean.TryParse( raw_value, out bool_value );
				value = bool_value;
				break;
			case TypeCode.Decimal:
				Decimal decimal_value;
				success = Decimal.TryParse( raw_value, out decimal_value );
				value = decimal_value;
				break;
			case TypeCode.Object:
				value = raw_value;
				break;
			default:
				success = false;
				value = null;
				break;
			}

			return value;
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
