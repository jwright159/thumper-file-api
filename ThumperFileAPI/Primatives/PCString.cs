using System.IO;
using Newtonsoft.Json.Linq;
using ThumperFileAPI.Generics;

namespace ThumperFileAPI.Primatives
{
	public class PCString : PCObject
	{
		public readonly string value;

		public PCString(string value)
		{
			this.value = value;
		}

		public static PCString FromBytes(BinaryReader bytes)
		{
			int count = bytes.ReadInt32();
			string value = new(bytes.ReadChars(count));
			return new PCString(value);
		}

		public override void ToBytes(BinaryWriter bytes)
		{
			bytes.Write(value.Length);
			bytes.Write(value);
		}

		public static PCString FromJson(JToken token) => new(token.ToObject<string>());
		
		public override JToken ToJson() => new JValue(value);
	}
}