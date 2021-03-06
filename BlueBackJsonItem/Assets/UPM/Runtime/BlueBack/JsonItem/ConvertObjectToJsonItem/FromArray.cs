

/**
	Copyright (c) blueback
	Released under the MIT License
	@brief JsonItem化。
*/


/** BlueBack.JsonItem.ConvertObjectToJsonItem
*/
namespace BlueBack.JsonItem.ConvertObjectToJsonItem
{
	/** FromArray
	*/
	public static class FromArray
	{
		/** Convert
		*/
		public static JsonItem Convert(System.Object a_from_object,System.Type a_from_type,ConvertToJsonItemOption a_from_option,WorkPool a_workpool,int a_nest)
		{
			{
				//[]

				System.Array t_array_raw = (System.Array)a_from_object;

				JsonItem t_to_jsonitem = new JsonItem(new Value_IndexArray());

				//サイズ確保。
				t_to_jsonitem.ReSize(t_array_raw.Length);

				//値型。
				System.Type t_list_value_type = ReflectionTool.ReflectionTool.GetListValueType(a_from_type);

				if(t_list_value_type == typeof(System.Object)){
					for(int ii=0;ii<t_array_raw.Length;ii++){
						//ワークに追加。
						System.Object t_listitem_object = t_array_raw.GetValue(ii);
						a_workpool.Add(WorkPool.ModeSetIndexArray.Start,t_to_jsonitem,ii,t_listitem_object,t_listitem_object.GetType(),a_from_option,a_nest + 1);
					}
				}else{
					for(int ii=0;ii<t_array_raw.Length;ii++){
						//ワークに追加。
						System.Object t_listitem_object = t_array_raw.GetValue(ii);
						a_workpool.Add(WorkPool.ModeSetIndexArray.Start,t_to_jsonitem,ii,t_listitem_object,t_list_value_type,a_from_option,a_nest + 1);
					}
				}

				//成功。
				return t_to_jsonitem;
			}
		}
	}
}

