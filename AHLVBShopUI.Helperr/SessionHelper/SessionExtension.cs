using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace AHLVBShopUI.Helper.SessionHelper
{
    public static class SessionExtension
    {
		// var userStringData=JsonConvert.SerializeObject(responseObject.Data); burayı burada yapıyorum serialize ve deserialize yapılanları tek bir yerde set ve get yapıyorum.
		// referenceloophandling --> hiyerarşik tabloları dönerken exception fırlatmaması için.
		// indented --> hiyerarşik
		public static void SetObject(this ISession session, string key, object? value)
		{
			var stringValue = JsonConvert.SerializeObject(value, Formatting.Indented, new JsonSerializerSettings
			{
				ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
			});

			session.SetString(key, stringValue);
		}

		// _httpContextAccessor.HttpContext.Session.SetString("User",userStringData); şeklinde veriyi çekmek için session u kendimiz yazıyoruz.
		public static T? GetObject<T>(this ISession session, string key)
		{
			var value = session.GetString(key);

			return value == null ? default(T) : JsonConvert.DeserializeObject<T>(value);
		}
	}
}
