

/**
	Copyright (c) blueback
	Released under the MIT License
	@brief コンバート。
*/


/** BlueBack.JsonItem.ConvertJsonStringToObject
*/
namespace BlueBack.JsonItem.ConvertJsonStringToObject
{
	/** Json文字列 ==> バイナリデータ。
	*/
	public static class BinaryData
	{
		/** Convert
		*/
		public static void Convert(string a_in_jsonstring,System.Collections.Generic.List<byte> a_out_list)
		{
			if(a_in_jsonstring.Length < 2){
				//不明。

				#if(DEF_BLUEBACK_DEBUG_ASSERT)
				DebugTool.Assert(false,string.Format("{0}",a_in_jsonstring));
				#endif

				return;
			}

			if(a_in_jsonstring[0] != '<'){
				//不明。

				#if(DEF_BLUEBACK_DEBUG_ASSERT)
				DebugTool.Assert(false,string.Format("{0}",a_in_jsonstring));
				#endif

				return;
			}

			int t_index = 1;
			while(t_index < a_in_jsonstring.Length){
				if(a_in_jsonstring[t_index] == '>'){
					//終端。

					#if(DEF_BLUEBACK_DEBUG_ASSERT)
					DebugTool.Assert((t_index + 1) == a_in_jsonstring.Length,string.Format("index = {0} : char = {1} : {2}",t_index,a_in_jsonstring[t_index],a_in_jsonstring));
					#endif

					return;
				}else{
					if(t_index + 1 < a_in_jsonstring.Length){

						byte t_binary_1;
						byte t_binary_2;
						StringConvertTool.HexStringToByte.Convert_NoCheck(a_in_jsonstring[t_index + 0],out t_binary_1);
						StringConvertTool.HexStringToByte.Convert_NoCheck(a_in_jsonstring[t_index + 1],out t_binary_2);
						byte t_binary = (byte)(t_binary_1 << 4 | t_binary_2);

						//リストに追加。
						a_out_list.Add(t_binary);
						t_index += 2;
					}else{
						//不明。

						#if(DEF_BLUEBACK_DEBUG_ASSERT)
						DebugTool.Assert(false,string.Format("index = {0} : char = {1} : {2}",t_index,a_in_jsonstring[t_index],a_in_jsonstring));
						#endif

						return;
					}
				}
			}

			//不明。

			#if(DEF_BLUEBACK_DEBUG_ASSERT)
			DebugTool.Assert(false,string.Format("{0}",a_in_jsonstring));
			#endif

			return;
		}
	}
}

