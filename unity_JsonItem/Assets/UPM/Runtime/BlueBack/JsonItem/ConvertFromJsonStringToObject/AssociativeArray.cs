

/**
 * Copyright (c) blueback
 * Released under the MIT License
 * @brief コンバート。
*/


/** BlueBack.JsonItem.ConvertFromJsonStringToObject
*/
namespace BlueBack.JsonItem.ConvertFromJsonStringToObject
{
	/** Json文字列 ==> 連想配列。
	*/
	public class AssociativeArray
	{
		/** Convert
		*/
		public static void Convert(string a_in_jsonstring,System.Collections.Generic.Dictionary<string,JsonItem> a_out_list)
		{
			{
				if(a_in_jsonstring.Length < 2){
					//不明。

					#if(DEF_BLUEBACK_JSONITEM_ASSERT)
					DebugTool.Assert(false);
					#endif

					return;
				}

				if(a_in_jsonstring[0] != '{'){
					//不明。

					#if(DEF_BLUEBACK_JSONITEM_ASSERT)
					DebugTool.Assert(false);
					#endif

					return;
				}

				int t_index = 1;
				while(t_index < a_in_jsonstring.Length){

					#pragma warning disable 0162
					switch(a_in_jsonstring[t_index]){
					case '}':
						{
							//終端。

							#if(DEF_BLUEBACK_JSONITEM_ASSERT)
							DebugTool.Assert((t_index + 1) == a_in_jsonstring.Length);
							#endif

							return;
						}break;
					case ',':
						{
							//次の項目あり。
							t_index++;
						}break;
					}
					#pragma warning restore
			
					//名前。
					string t_name_string;
					{
						if((a_in_jsonstring[t_index] == '"')||(a_in_jsonstring[t_index] == '\'')){
							int t_name_size = JsonStringLength.GetStringDataLength(a_in_jsonstring,t_index);
							if(t_name_size >= 2){
								t_name_string = a_in_jsonstring.Substring(t_index + 1,t_name_size - 2);
								t_index += t_name_size;
							}else{
								//不明。

								#if(DEF_BLUEBACK_JSONITEM_ASSERT)
								DebugTool.Assert(false);
								#endif

								return;
							}
						}else{
							//不明。

							#if(DEF_BLUEBACK_JSONITEM_ASSERT)
							DebugTool.Assert(false);
							#endif

							return;
						}
					}
			
					//「:」。
					if(a_in_jsonstring[t_index] == ':'){
						t_index++;
					}else{
						//不明。

						#if(DEF_BLUEBACK_JSONITEM_ASSERT)
						DebugTool.Assert(false);
						#endif

						return;
					}
			
					//値。
					int t_value_size = 0;
					{
						#pragma warning disable 0162
						switch(ValueType_FirstCharValueType.Get(a_in_jsonstring[t_index])){
						case ValueType.StringData:
							{
								t_value_size = JsonStringLength.GetStringDataLength(a_in_jsonstring,t_index);
							}break;
						case ValueType.Calc_UnknownNumber:
						case ValueType.SignedNumber:
						case ValueType.UnsignedNumber:
						case ValueType.FloatingNumber:
						case ValueType.DecimalNumber:
							{
								t_value_size = JsonStringLength.GetNumberLength(a_in_jsonstring,t_index);
							}break;
						case ValueType.AssociativeArray:
							{
								t_value_size = JsonStringLength.GetAssociateArrayLength(a_in_jsonstring,t_index);
							}break;
						case ValueType.IndexArray:
							{
								t_value_size = JsonStringLength.GetIndexArrayLength(a_in_jsonstring,t_index);
							}break;
						case ValueType.Calc_BoolDataTrue:
							{
								t_value_size = JsonStringLength.GetBoolDataTrueLength(a_in_jsonstring,t_index);
							}break;
						case ValueType.Calc_BoolDataFalse:
							{
								t_value_size = JsonStringLength.GetBoolDataFalseLength(a_in_jsonstring,t_index);
							}break;
						case ValueType.BinaryData:
							{
								t_value_size = JsonStringLength.GetBinaryDataLength(a_in_jsonstring,t_index);
							}break;
						case ValueType.Null:
							{
								t_value_size = JsonStringLength.GetNullLength(a_in_jsonstring,t_index);
							}break;
						default:
							{
								//不明。

								#if(DEF_BLUEBACK_JSONITEM_ASSERT)
								DebugTool.Assert(false);
								#endif

								return;
							}break;
						}
						#pragma warning restore
					}
			
					//リストに追加。
					if(t_value_size > 0){
						JsonItem t_additem = new JsonItem();
						{
							t_additem.SetJsonString(a_in_jsonstring.Substring(t_index,t_value_size));
						}

						a_out_list.Add(t_name_string,t_additem);
						t_index += t_value_size;
					}else{
						//不明。

						#if(DEF_BLUEBACK_JSONITEM_ASSERT)
						DebugTool.Assert(false);
						#endif

						return;
					}
				}
			}
		
			//不明。

			#if(DEF_BLUEBACK_JSONITEM_ASSERT)
			DebugTool.Assert(false);
			#endif

			return;
		}
	}
}

