

/**
	Copyright (c) blueback
	Released under the MIT License
	@brief JsonItem化。
*/


/** BlueBack.JsonItem.ConvertObjectToJsonItem
*/
namespace BlueBack.JsonItem.ConvertObjectToJsonItem
{
	/** WorkPool
	*/
	public sealed class WorkPool
	{
		/** ModeAddIndexArray

			IndexArray。追加。

		*/
		public enum ModeAddIndexArray
		{
			/** 開始。
			*/
			Start = 0,
		}

		/** ModeSetIndexArray

			IndexArray。設定。

		*/
		public enum ModeSetIndexArray
		{
			/** 開始。
			*/
			Start = 1,
		}

		/** ModeAddAssociativeArray

			AssociativeArray。追加。

		*/
		public enum ModeAddAssociativeArray
		{
			/** 開始。
			*/
			Start = 2,
		}

		/** ModeFieldInfo

			FieldInfo。

		*/
		public enum ModeFieldInfo
		{
			/** 開始。
			*/
			Start = 3,
		}

		/** list
		*/
		private System.Collections.Generic.List<WorkPool_Item> list;

		/** constructor
		*/
		public WorkPool()
		{
			this.list = new System.Collections.Generic.List<WorkPool_Item>();
		}

		/** Add

			IndexArray。追加。

		*/
		public void Add(ModeAddIndexArray a_mode,JsonItem a_to_jsonitem,System.Object a_from_listitem_object,System.Type a_from_listitem_type,ConvertToJsonItemOption a_from_option,int a_nest)
		{
			WorkPool_Item t_item = new WorkPool_Item();
			{
				//mode
				t_item.mode = (int)a_mode;

				//nest
				t_item.nest = a_nest;

				//コンバート元、インスタンス。
				t_item.from_fieldinfo = null;
				t_item.from_parent_object = null;
				t_item.from_object = a_from_listitem_object;
				t_item.from_type = a_from_listitem_type;
				t_item.from_option = a_from_option;

				//コンバート先。ＪＳＯＮ。
				t_item.to_jsonitem = a_to_jsonitem;
				t_item.to_index = 0;
				t_item.to_key_string = null;
			}
			this.list.Add(t_item);
		}

		/** Add

			IndexArray。設定。

		*/
		public void Add(ModeSetIndexArray a_mode,JsonItem a_to_jsonitem,int a_to_index,System.Object a_from_listitem_object,System.Type a_from_listitem_type,ConvertToJsonItemOption a_from_option,int a_nest)
		{
			WorkPool_Item t_item = new WorkPool_Item();
			{
				//mode
				t_item.mode = (int)a_mode;

				//nest
				t_item.nest = a_nest;

				//コンバート元、インスタンス。
				t_item.from_fieldinfo = null;
				t_item.from_parent_object = null;
				t_item.from_object = a_from_listitem_object;
				t_item.from_type = a_from_listitem_type;
				t_item.from_option = a_from_option;

				//コンバート先。ＪＳＯＮ。
				t_item.to_jsonitem = a_to_jsonitem;
				t_item.to_index = a_to_index;
				t_item.to_key_string = null;
			}
			this.list.Add(t_item);
		}

		/** Add

			AssociativeArray。追加。

		*/
		public void Add(ModeAddAssociativeArray a_mode,JsonItem a_to_jsonitem,string a_to_key_string,System.Object a_from_listitem_object,System.Type a_from_listitem_type,ConvertToJsonItemOption a_from_option,int a_nest)
		{
			WorkPool_Item t_item = new WorkPool_Item();
			{
				//mode
				t_item.mode = (int)a_mode;

				//nest
				t_item.nest = a_nest;

				//コンバート元、インスタンス。
				t_item.from_fieldinfo = null;
				t_item.from_parent_object = null;
				t_item.from_object = a_from_listitem_object;
				t_item.from_type = a_from_listitem_type;
				t_item.from_option = a_from_option;

				//コンバート先。ＪＳＯＮ。
				t_item.to_jsonitem = a_to_jsonitem;
				t_item.to_index = 0;
				t_item.to_key_string = a_to_key_string;
			}
			this.list.Add(t_item);
		}

		/** Add

			FieldInfo。

		*/
		public void Add(ModeFieldInfo a_mode,JsonItem a_to_jsonitem,System.Reflection.FieldInfo a_from_fieldinfo,System.Object a_from_parent_object,int a_nest)
		{
			WorkPool_Item t_item = new WorkPool_Item();
			{
				//モード。
				t_item.mode = (int)a_mode;

				//ネスト。
				t_item.nest = a_nest;

				//コンバート元、インスタンス。
				t_item.from_fieldinfo = a_from_fieldinfo;
				t_item.from_parent_object = a_from_parent_object;
				t_item.from_object = null;
				t_item.from_type = null;
				t_item.from_option = ConvertToJsonItemOption.None;

				//コンバート先。ＪＳＯＮ。
				t_item.to_jsonitem = a_to_jsonitem;
				t_item.to_index = 0;
				t_item.to_key_string = null;
			}
			this.list.Add(t_item);
		}

		/** 更新。
		*/
		public void Main()
		{
			while(true){
				int t_count = this.list.Count;
				if(t_count > 0){
					WorkPool_Item t_current_work = this.list[t_count - 1];
					this.list.RemoveAt(t_count - 1);
					if(this.Main_Item(t_current_work) == false){
						//エラー。
						this.list.Clear();

						#if(DEF_BLUEBACK_DEBUG_ASSERT)
						DebugTool.Assert(false);
						#endif
					}

					#if(DEF_BLUEBACK_JSONITEM_NESTLIMIT)
					if(t_count > Config.LOOPLIMIT){
						#if(DEF_BLUEBACK_DEBUG_ASSERT)
						DebugTool.Assert(false,string.Format("WorkPool : list : {0}",t_count));
						#endif
					}
					#endif
				}else{
					break;
				}
			}
		}

		/** 更新。
		*/
		private bool Main_Item(WorkPool_Item a_item)
		{
			switch(a_item.mode){
			case (int)ModeAddIndexArray.Start:
				{
					//IndexArray。追加。

					JsonItem t_jsonitem_listitem = null;

					#if(DEF_BLUEBACK_JSONITEM_NESTLIMIT)
					if(a_item.nest > Config.NESTLIMIT){
						#if(DEF_BLUEBACK_DEBUG_ASSERT)
						DebugTool.Assert(false,string.Format("WorkPool : nest : {0}",a_item.nest));
						#endif
					}
					#endif

					t_jsonitem_listitem = ConvertObjectToJsonItem.Convert(a_item.from_object,a_item.from_type,a_item.from_option,this,a_item.nest + 1);

					if(a_item.to_jsonitem != null){
						a_item.to_jsonitem.AddItem(t_jsonitem_listitem,false);
					}else{

						#if(DEF_BLUEBACK_DEBUG_ASSERT)
						DebugTool.Assert(false);
						#endif

						return false;
					}
				}return true;
			case (int)ModeSetIndexArray.Start:
				{
					//IndexArray。設定。

					JsonItem t_jsonitem_listitem = null;

					#if(DEF_BLUEBACK_JSONITEM_NESTLIMIT)
					if(a_item.nest > Config.NESTLIMIT){
						#if(DEF_BLUEBACK_DEBUG_ASSERT)
						DebugTool.Assert(false,string.Format("WorkPool : nest : {0}",a_item.nest));
						#endif
					}
					#endif

					t_jsonitem_listitem = ConvertObjectToJsonItem.Convert(a_item.from_object,a_item.from_type,a_item.from_option,this,a_item.nest + 1);

					if(a_item.to_jsonitem != null){
						a_item.to_jsonitem.SetItem(a_item.to_index,t_jsonitem_listitem,false);
					}else{

						#if(DEF_BLUEBACK_DEBUG_ASSERT)
						DebugTool.Assert(false);
						#endif

						return false;
					}
				}return true;
			case (int)ModeAddAssociativeArray.Start:
				{
					//AssociativeArray。追加。

					JsonItem t_jsonitem_member = null;

					#if(DEF_BLUEBACK_JSONITEM_NESTLIMIT)
					if(a_item.nest > Config.NESTLIMIT){
						#if(DEF_BLUEBACK_DEBUG_ASSERT)
						DebugTool.Assert(false,string.Format("WorkPool : nest : {0}",a_item.nest));
						#endif
					}
					#endif

					t_jsonitem_member = ConvertObjectToJsonItem.Convert(a_item.from_object,a_item.from_type,a_item.from_option,this,a_item.nest + 1);

					if(a_item.to_jsonitem != null){
						a_item.to_jsonitem.SetItem(a_item.to_key_string,t_jsonitem_member,false);
					}else{

						#if(DEF_BLUEBACK_DEBUG_ASSERT)
						DebugTool.Assert(false);
						#endif

						return false;
					}
				}return true;
			case (int)ModeFieldInfo.Start:
				{
					//FieldInfo。

					//ＥＮＵＭの文字列化。
					if(a_item.from_fieldinfo.IsDefined(typeof(Attribute.EnumString),false) == true){
						a_item.from_option = ConvertToJsonItemOption.EnumString;
					}else{
						a_item.from_option = ConvertToJsonItemOption.None;
					}

					System.Object t_raw = a_item.from_fieldinfo.GetValue(a_item.from_parent_object);
					if(t_raw != null){

						JsonItem t_jsonitem_member = null;

						#if(DEF_BLUEBACK_JSONITEM_NESTLIMIT)
						if(a_item.nest > Config.NESTLIMIT){
							#if(DEF_BLUEBACK_DEBUG_ASSERT)
							DebugTool.Assert(false,string.Format("WorkPool : nest : {0}",a_item.nest));
							#endif
						}
						#endif

						t_jsonitem_member = ConvertObjectToJsonItem.Convert(t_raw,t_raw.GetType(),a_item.from_option,this,a_item.nest + 1);

						if(a_item.to_jsonitem != null){
							a_item.to_jsonitem.SetItem(a_item.from_fieldinfo.Name,t_jsonitem_member,false);
						}else{

							#if(DEF_BLUEBACK_DEBUG_ASSERT)
							DebugTool.Assert(false);
							#endif

							return false;
						}

					}else{
						//NULL処理。
					}

				}return true;
			}

			return false;
		}

	}
}

