

/**
	Copyright (c) blueback
	Released under the MIT License
	@brief オブジェクト化。
*/


/** BlueBack.JsonItem.ConvertJsonItemToObject
*/
namespace BlueBack.JsonItem.ConvertJsonItemToObject
{
	/** オブジェクト化。

		ValueType.SignedNumber
		ValueType.UnsignedNumber
		ValueType.FloatingNumber
		ValueType.DecimalNumber
		ValueType.BoolData

	*/
	public static class FromNumber
	{
		/** Convert
		*/
		public static void Convert(ref System.Object a_to_refobject,System.Type a_to_type,JsonItem a_from_jsonitem)
		{
			#pragma warning disable 0162
			switch(a_to_type.FullName){
			case "System." + nameof(System.Char):
				{
					a_to_refobject = a_from_jsonitem.CastToChar();
					return;
				}break;
			case "System." + nameof(System.SByte):
				{
					a_to_refobject = a_from_jsonitem.CastToSbyte();
					return;
				}break;
			case "System." + nameof(System.Byte):
				{
					a_to_refobject = a_from_jsonitem.CastToByte();
					return;
				}break;
			case "System." + nameof(System.Int16):
				{
					a_to_refobject = a_from_jsonitem.CastToInt16();
					return;
				}break;
			case "System." + nameof(System.UInt16):
				{
					a_to_refobject = a_from_jsonitem.CastToUint16();
					return;
				}break;
			case "System." + nameof(System.Int32):
				{
					a_to_refobject = a_from_jsonitem.CastToInt32();
					return;
				}break;
			case "System." + nameof(System.UInt32):
				{
					a_to_refobject = a_from_jsonitem.CastToUint32();
					return;
				}break;
			case "System." + nameof(System.Int64):
				{
					a_to_refobject = a_from_jsonitem.CastToInt64();
					return;
				}break;
			case "System." + nameof(System.UInt64):
				{
					a_to_refobject = a_from_jsonitem.CastToUint64();
					return;
				}break;
			case "System." + nameof(System.Single):
				{
					a_to_refobject = a_from_jsonitem.CastToSingle();
					return;
				}break;
			case "System." + nameof(System.Double):
				{
					a_to_refobject = a_from_jsonitem.CastToDouble();
					return;
				}break;
			case "System." + nameof(System.Boolean):
				{
					a_to_refobject = a_from_jsonitem.CastToBoolData();
					return;
				}break;
			case "System." + nameof(System.Decimal):
				{
					a_to_refobject = a_from_jsonitem.CastToDecimal();
					return;
				}break;
			case "System." + nameof(System.String):
				{
					switch(a_from_jsonitem.GetValueType()){
					case ValueType.SignedNumber:
						{
							a_to_refobject = a_from_jsonitem.GetSignedNumber().ToString();
							return;
						}break;
					case ValueType.UnsignedNumber:
						{
							a_to_refobject = a_from_jsonitem.GetUnsignedNumber().ToString();
							return;
						}break;
					case ValueType.FloatingNumber:
						{
							a_to_refobject = a_from_jsonitem.GetFloatingNumber().ToString();
							return;
						}break;
					case ValueType.DecimalNumber:
						{
							a_to_refobject = a_from_jsonitem.GetDecimalNumber().ToString();
							return;
						}break;
					case ValueType.BoolData:
						{
							a_to_refobject = a_from_jsonitem.GetBoolData().ToString();
							return;
						}break;
					default:
						{
							//失敗。

							#if(DEF_BLUEBACK_DEBUG_ASSERT)
							DebugTool.Assert(false,string.Format("{0}",a_from_jsonitem.GetValueType()));
							#endif

							return;
						}break;
					}
				}break;
			default:
				{
					if(a_to_type.IsEnum == true){
						System.Enum t_enum = (System.Enum)a_to_refobject;
						if(t_enum != null){
							switch(t_enum.GetTypeCode()){
							case System.TypeCode.Byte:
								{
									a_to_refobject = System.Enum.ToObject(a_to_type,a_from_jsonitem.CastToByte());
									return;
								}break;
							case System.TypeCode.SByte:
								{
									a_to_refobject = System.Enum.ToObject(a_to_type,a_from_jsonitem.CastToSbyte());
									return;
								}break;
							case System.TypeCode.Int16:
								{
									a_to_refobject = System.Enum.ToObject(a_to_type,a_from_jsonitem.CastToInt16());
									return;
								}break;
							case System.TypeCode.UInt16:
								{
									a_to_refobject = System.Enum.ToObject(a_to_type,a_from_jsonitem.CastToUint16());
									return;
								}break;
							case System.TypeCode.Int32:
								{
									a_to_refobject = System.Enum.ToObject(a_to_type,a_from_jsonitem.CastToInt32());
									return;
								}break;
							case System.TypeCode.UInt32:
								{
									a_to_refobject = System.Enum.ToObject(a_to_type,a_from_jsonitem.CastToUint32());
									return;
								}break;
							case System.TypeCode.Int64:
								{
									a_to_refobject = System.Enum.ToObject(a_to_type,a_from_jsonitem.CastToInt64());
									return;
								}break;
							case System.TypeCode.UInt64:
								{
									a_to_refobject = System.Enum.ToObject(a_to_type,a_from_jsonitem.CastToUint64());
									return;
								}break;
							default:
								{
									//失敗。

									#if(DEF_BLUEBACK_DEBUG_ASSERT)
									DebugTool.Assert(false,string.Format("{0}",t_enum.GetTypeCode()));
									#endif

									return;
								}break;
							}
						}else{
							//失敗。

							#if(DEF_BLUEBACK_DEBUG_ASSERT)
							DebugTool.Assert(false);
							#endif

							return;
						}
					}else{
						//失敗。

						#if(DEF_BLUEBACK_DEBUG_ASSERT)
						DebugTool.Assert(false);
						#endif

						return;
					}
				}break;
			}
			#pragma warning restore
		}
	}
}

