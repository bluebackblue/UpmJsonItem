

/**
	Copyright (c) blueback
	Released under the MIT License
	@brief JsonItem化。
*/


/** BlueBack.JsonItem.ConvertObjectToJsonItem
*/
namespace BlueBack.JsonItem.ConvertObjectToJsonItem
{
	/** FromClass
	*/
	public static class FromClass
	{
		/** Convert
		*/
		public static JsonItem Convert(System.Object a_from_object,System.Type a_from_type,ConvertToJsonItemOption a_from_option,WorkPool a_workpool,int a_nest)
		{
			{
				//IDictionary
				{
					System.Collections.IDictionary t_from_dictionary = a_from_object as System.Collections.IDictionary;
					if(t_from_dictionary != null){
						System.Type t_list_key_type = ReflectionTool.ReflectionTool.GetDictionaryKeyType(a_from_type);
						if(t_list_key_type == typeof(string)){
							//Generic.Dictionary<string.*>
							//Generic.SortedDictionary<string,*>
							//Generic.SortedList<string,*>

							JsonItem t_to_jsonitem = new JsonItem(new Value_AssociativeArray());

							//値型。
							System.Type t_list_value_type = ReflectionTool.ReflectionTool.GetListValueType(a_from_object.GetType());

							if(t_list_value_type == typeof(System.Object)){
								//ワークに追加。
								foreach(System.Collections.DictionaryEntry t_from_pair in t_from_dictionary){
									string t_from_listitem_key_string = (string)t_from_pair.Key;
									if(t_from_listitem_key_string != null){
										System.Object t_from_listitem_object = t_from_pair.Value;
										a_workpool.Add(WorkPool.ModeAddAssociativeArray.Start,t_to_jsonitem,t_from_listitem_key_string,t_from_listitem_object,t_from_listitem_object.GetType(),a_from_option,a_nest + 1);
									}else{
										//NULL処理。
										//keyがnullの場合は追加しない。
									}
								}
							}else{
								//ワークに追加。
								foreach(System.Collections.DictionaryEntry t_from_pair in t_from_dictionary){
									string t_from_listitem_key_string = (string)t_from_pair.Key;
									if(t_from_listitem_key_string != null){
										System.Object t_from_listitem_object = t_from_pair.Value;
										a_workpool.Add(WorkPool.ModeAddAssociativeArray.Start,t_to_jsonitem,t_from_listitem_key_string,t_from_listitem_object,t_list_value_type,a_from_option,a_nest + 1);
									}else{
										//NULL処理。
										//keyがnullの場合は追加しない。
									}
								}
							}

							//成功。
							return t_to_jsonitem;
						}else{
							//Generic.Dictionary<key != string.>

							JsonItem t_to_jsonitem = new JsonItem(new Value_IndexArray());

							//サイズがわかるので要素確保。
							t_to_jsonitem.ReSize(t_from_dictionary.Count);

							int t_index = 0;

							//値型。
							System.Type t_list_value_type = ReflectionTool.ReflectionTool.GetListValueType(a_from_type);

							if(t_list_value_type == typeof(System.Object)){
								if(t_list_key_type == typeof(System.Object)){
									//ワークに追加。
									foreach(System.Collections.DictionaryEntry t_from_listitem in t_from_dictionary){
										JsonItem t_keyvalue_jsonitem = new JsonItem(new Value_AssociativeArray());
										t_to_jsonitem.SetItem(t_index,t_keyvalue_jsonitem,false);
										a_workpool.Add(WorkPool.ModeAddAssociativeArray.Start,t_keyvalue_jsonitem,"KEY",t_from_listitem.Key,t_from_listitem.Key.GetType(),a_from_option,a_nest + 1);
										a_workpool.Add(WorkPool.ModeAddAssociativeArray.Start,t_keyvalue_jsonitem,"VALUE",t_from_listitem.Value,t_from_listitem.Value.GetType(),a_from_option,a_nest + 1);
										t_index++;
									}
								}else{
									//ワークに追加。
									foreach(System.Collections.DictionaryEntry t_from_listitem in t_from_dictionary){
										JsonItem t_keyvalue_jsonitem = new JsonItem(new Value_AssociativeArray());
										t_to_jsonitem.SetItem(t_index,t_keyvalue_jsonitem,false);
										a_workpool.Add(WorkPool.ModeAddAssociativeArray.Start,t_keyvalue_jsonitem,"KEY",t_from_listitem.Key,t_list_key_type,a_from_option,a_nest + 1);
										a_workpool.Add(WorkPool.ModeAddAssociativeArray.Start,t_keyvalue_jsonitem,"VALUE",t_from_listitem.Value,t_from_listitem.Value.GetType(),a_from_option,a_nest + 1);
										t_index++;
									}
								}
							}else{
								if(t_list_key_type == typeof(System.Object)){
									//ワークに追加。
									foreach(System.Collections.DictionaryEntry t_from_listitem in t_from_dictionary){
										JsonItem t_keyvalue_jsonitem = new JsonItem(new Value_AssociativeArray());
										t_to_jsonitem.SetItem(t_index,t_keyvalue_jsonitem,false);
										a_workpool.Add(WorkPool.ModeAddAssociativeArray.Start,t_keyvalue_jsonitem,"KEY",t_from_listitem.Key,t_from_listitem.Key.GetType(),a_from_option,a_nest + 1);
										a_workpool.Add(WorkPool.ModeAddAssociativeArray.Start,t_keyvalue_jsonitem,"VALUE",t_from_listitem.Value,t_list_value_type,a_from_option,a_nest + 1);
										t_index++;
									}
								}else{
									//ワークに追加。
									foreach(System.Collections.DictionaryEntry t_from_listitem in t_from_dictionary){
										JsonItem t_keyvalue_jsonitem = new JsonItem(new Value_AssociativeArray());
										t_to_jsonitem.SetItem(t_index,t_keyvalue_jsonitem,false);
										a_workpool.Add(WorkPool.ModeAddAssociativeArray.Start,t_keyvalue_jsonitem,"KEY",t_from_listitem.Key,t_list_key_type,a_from_option,a_nest + 1);
										a_workpool.Add(WorkPool.ModeAddAssociativeArray.Start,t_keyvalue_jsonitem,"VALUE",t_from_listitem.Value,t_list_value_type,a_from_option,a_nest + 1);
										t_index++;
									}
								}
							}

							//成功。
							return t_to_jsonitem;
						}
					}
				}

				//ICollection
				{
					System.Collections.ICollection t_from_collection = a_from_object as System.Collections.ICollection;
					if(t_from_collection != null){

						//Generic.List
						//Generic.Stack
						//Generic.LinkedList
						//Generic.Queue
						//Generic.SortedSet

						JsonItem t_to_jsonitem = new JsonItem(new Value_IndexArray());

						//サイズがわかるので要素確保。
						t_to_jsonitem.ReSize(t_from_collection.Count);

						int t_index = 0;

						//値型。
						System.Type t_list_value_type = ReflectionTool.ReflectionTool.GetListValueType(a_from_type);

						if(t_list_value_type == typeof(System.Object)){
							//Collections.ArrayList

							//ワークに追加。
							foreach(System.Object t_from_listitem in t_from_collection){
								a_workpool.Add(WorkPool.ModeSetIndexArray.Start,t_to_jsonitem,t_index,t_from_listitem,t_from_listitem.GetType(),a_from_option,a_nest + 1);
								t_index++;
							}
						}else{
							//ワークに追加。
							foreach(System.Object t_from_listitem in t_from_collection){
								a_workpool.Add(WorkPool.ModeSetIndexArray.Start,t_to_jsonitem,t_index,t_from_listitem,t_list_value_type,a_from_option,a_nest + 1);
								t_index++;
							}
						}

						//成功。
						return t_to_jsonitem;
					}
				}

				//IEnumerable
				{
					System.Collections.IEnumerable t_from_enumerable = a_from_object as System.Collections.IEnumerable;
					if(t_from_enumerable != null){

						//Generic.HashSet

						JsonItem t_to_jsonitem = new JsonItem(new Value_IndexArray());

						//値型。
						System.Type t_list_value_type = ReflectionTool.ReflectionTool.GetListValueType(a_from_type);

						if(t_list_value_type == typeof(System.Object)){
							//ワークに追加。
							foreach(System.Object t_from_listitem in t_from_enumerable){
								a_workpool.Add(WorkPool.ModeAddIndexArray.Start,t_to_jsonitem,t_from_listitem,t_from_listitem.GetType(),a_from_option,a_nest + 1);
							}
						}else{
							//ワークに追加。
							foreach(System.Object t_from_listitem in t_from_enumerable){
								a_workpool.Add(WorkPool.ModeAddIndexArray.Start,t_to_jsonitem,t_from_listitem,t_list_value_type,a_from_option,a_nest + 1);
							}
						}

						//成功。
						return t_to_jsonitem;
					}
				}

				//class,struct
				{
					JsonItem t_to_jsonitem = new JsonItem(new Value_AssociativeArray());

					//メンバーリスト。取得。
					System.Collections.Generic.List<System.Reflection.FieldInfo> t_fieldinfo_list = new System.Collections.Generic.List<System.Reflection.FieldInfo>();
					ConvertTool.GetMemberListAll(a_from_type,t_fieldinfo_list);

					//ワークに追加。
					foreach(System.Reflection.FieldInfo t_fieldinfo in t_fieldinfo_list){
						a_workpool.Add(WorkPool.ModeFieldInfo.Start,t_to_jsonitem,t_fieldinfo,a_from_object,a_nest + 1);
					}

					//成功。
					return t_to_jsonitem;
				}
			}
		}
	}
}

