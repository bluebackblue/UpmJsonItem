

/**
	Copyright (c) blueback
	Released under the MIT License
	@brief JsonItem化。
*/


/** BlueBack.JsonItem.ConvertObjectToJsonItem
*/
namespace BlueBack.JsonItem.ConvertObjectToJsonItem
{
	/** ConvertObjectToJsonItem
	*/
	public static class ConvertObjectToJsonItem
	{
		/** Convert
		*/
		public static JsonItem Convert(System.Object a_from_object,System.Type a_from_type,ConvertToJsonItemOption a_from_option,WorkPool a_workpool,int a_nest)
		{
			WorkPool t_workpool = a_workpool;

			if(t_workpool == null){
				t_workpool = new WorkPool();				
			}

			JsonItem t_to_jsonitem = null;

			{
				if(a_from_object != null){
					switch(a_from_type.FullName){
					case "System." + nameof(System.String):
						{
							System.String t_value = a_from_object as System.String;

							if(t_value != null){
								t_to_jsonitem = new JsonItem(new Value_StringData(t_value));
							}else{
								//NULL処理。
								t_to_jsonitem = null;
							}
						}break;
					case "System." + nameof(System.Char):
						{
							t_to_jsonitem = new JsonItem(new Value_Number<System.Char>((System.Char)a_from_object));
						}break;
					case "System." + nameof(System.SByte):
						{
							t_to_jsonitem = new JsonItem(new Value_Number<System.SByte>((System.SByte)a_from_object));
						}break;
					case "System." + nameof(System.Byte):
						{
							t_to_jsonitem = new JsonItem(new Value_Number<System.Byte>((System.Byte)a_from_object));
						}break;
					case "System." + nameof(System.Int16):
						{
							t_to_jsonitem = new JsonItem(new Value_Number<System.Int16>((System.Int16)a_from_object));
						}break;
					case "System." + nameof(System.UInt16):
						{
							t_to_jsonitem = new JsonItem(new Value_Number<System.UInt16>((System.UInt16)a_from_object));
						}break;
					case "System." + nameof(System.Int32):
						{
							t_to_jsonitem = new JsonItem(new Value_Number<System.Int32>((System.Int32)a_from_object));
						}break;
					case "System." + nameof(System.UInt32):
						{
							t_to_jsonitem = new JsonItem(new Value_Number<System.UInt32>((System.UInt32)a_from_object));
						}break;
					case "System." + nameof(System.Int64):
						{
							t_to_jsonitem = new JsonItem(new Value_Number<System.Int64>((System.Int64)a_from_object));
						}break;
					case "System." + nameof(System.UInt64):
						{
							t_to_jsonitem = new JsonItem(new Value_Number<System.UInt64>((System.UInt64)a_from_object));
						}break;
					case "System." + nameof(System.Single):
						{
							t_to_jsonitem = new JsonItem(new Value_Number<System.Single>((System.Single)a_from_object));
						}break;
					case "System." + nameof(System.Double):
						{
							t_to_jsonitem = new JsonItem(new Value_Number<System.Double>((System.Double)a_from_object));
						}break;
					case "System." + nameof(System.Boolean):
						{
							t_to_jsonitem = new JsonItem(new Value_Number<System.Boolean>((System.Boolean)a_from_object));
						}break;
					case "System." + nameof(System.Decimal):
						{
							t_to_jsonitem = new JsonItem(new Value_Number<System.Decimal>((System.Decimal)a_from_object));
						}break;
					default:
						{
							if(a_from_type.IsArray == true){
								//[]
								t_to_jsonitem = FromArray.Convert(a_from_object,a_from_type,a_from_option,t_workpool,a_nest);
							}else if(a_from_type.IsEnum == true){
								//Enum
								t_to_jsonitem = FromEnum.Convert(a_from_object,a_from_option);
							}else{
								//class struct generic
								t_to_jsonitem = FromClass.Convert(a_from_object,a_from_type,a_from_option,t_workpool,a_nest);
							}
						}break;
					}
				}else{
					//NULL処理。
				}
			}

			//再起呼び出し。
			if(a_workpool == null){
				t_workpool.Main();
			}

			return t_to_jsonitem;
		}
	}
}

