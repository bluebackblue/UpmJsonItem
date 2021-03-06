

/**
	Copyright (c) blueback
	Released under the MIT License
	@brief コンバート。
*/


/** BlueBack.JsonItem
*/
namespace BlueBack.JsonItem
{
	/** Convert
	*/
	public static class Convert
	{
		/** オブジェクト => JsonItem。
		*/
		public static JsonItem ObjectToJsonItem<Type>(Type a_instance,ConvertToJsonItemOption a_option)
		{
			if(a_instance != null){
				return ConvertObjectToJsonItem.ConvertObjectToJsonItem.Convert(a_instance,a_instance.GetType(),a_option,null,0);
			}else{
				return null;
			}
		}

		/** オブジェクト => JsonItem。
		*/
		public static JsonItem ObjectToJsonItem<Type>(Type a_instance)
		{
			if(a_instance != null){
				return ConvertObjectToJsonItem.ConvertObjectToJsonItem.Convert(a_instance,a_instance.GetType(),Config.DEFAULT_CONVERTTOJSONITEM_OPTION,null,0);
			}else{
				return null;
			}
		}

		/** JsonItem => オブジェクト。
		*/
		public static Type JsonItemToObject<Type>(JsonItem a_jsonitem)
		{
			if(a_jsonitem != null){
				return a_jsonitem.ConvertToObject<Type>();
			}else{
				return default(Type);
			}
		}

		/** JsonItem => Json文字列。
		*/
		public static void JsonItemToJsonString(JsonItem a_jsonitem,System.Text.StringBuilder a_stringbuilder,ConvertToJsonStringOption a_option)
		{
			if(a_jsonitem != null){
				a_jsonitem.ConvertToJsonString(a_stringbuilder,a_option);
			}
		}

		/** JsonItem => Json文字列。
		*/
		public static string JsonItemToJsonString(JsonItem a_jsonitem)
		{
			if(a_jsonitem != null){
				return a_jsonitem.ConvertToJsonString();
			}else{
				return null;
			}
		}

		/** Json文字列 => JsonItem。
		*/
		public static JsonItem JsonStringToJsonItem(string a_jsonstring)
		{
			return new JsonItem(a_jsonstring);
		}

		/** オブジェクト => Json文字列。
		*/
		public static void ObjectToJsonString<Type>(Type a_instance,System.Text.StringBuilder a_stringbuilder,ConvertToJsonItemOption a_option_tojsonitem,ConvertToJsonStringOption a_option_tojsonstring)
		{
			ObjectToJsonString_Fee(a_instance,a_stringbuilder,a_option_tojsonitem,a_option_tojsonstring);
		}

		/** オブジェクト => Json文字列。
		*/
		public static string ObjectToJsonString<Type>(Type a_instance)
		{
			return ObjectToJsonString_Fee(a_instance);
		}

		/** Json文字列 => オブジェクト。
		*/
		public static Type JsonStringToObject<Type>(string a_jsonstring)
		{
			return JsonStringToObject_Fee<Type>(a_jsonstring);
		}

		/** Fee。オブジェクト => Json文字列。
		*/
		public static void ObjectToJsonString_Fee<Type>(Type a_instance,System.Text.StringBuilder a_stringbuilder,ConvertToJsonItemOption a_option_tojsonitem,ConvertToJsonStringOption a_option_tojsonstring)
		{
			if(a_instance != null){
				JsonItem t_jsonitem = ConvertObjectToJsonItem.ConvertObjectToJsonItem.Convert(a_instance,a_instance.GetType(),a_option_tojsonitem,null,0);
				t_jsonitem.ConvertToJsonString(a_stringbuilder,a_option_tojsonstring);
			}
		}

		/** オブジェクト => Json文字列。
		*/
		public static string ObjectToJsonString_Fee<Type>(Type a_instance)
		{
			if(a_instance != null){
				JsonItem t_jsonitem = ConvertObjectToJsonItem.ConvertObjectToJsonItem.Convert(a_instance,a_instance.GetType(),Config.DEFAULT_CONVERTTOJSONITEM_OPTION,null,0);
				return t_jsonitem.ConvertToJsonString();
			}else{
				return null;
			}
		}

		/** Json文字列 => オブジェクト。
		*/
		public static Type JsonStringToObject_Fee<Type>(string a_jsonstring)
		{
			if(a_jsonstring != null){
				JsonItem t_jsonitem = new JsonItem(a_jsonstring);
				return t_jsonitem.ConvertToObject<Type>();
			}
			return default(Type);
		}

		/** コンバート。正規化。
		*/
		public static string ConvertToNormailze(string a_jsonstring)
		{
			return Normalize.Convert(a_jsonstring);
		}

		/** コンバート。表示成型。
		*/
		public static string ConvertToPretty(string a_jsonstring,string a_neststring)
		{
			return Pretty.Convert(a_jsonstring,a_neststring);
		}
	}
}

