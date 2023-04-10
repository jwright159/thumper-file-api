using System.IO;
using Newtonsoft.Json.Linq;

namespace ThumperFileAPI.Primatives
{
	public class PCString
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

		public void ToBytes(BinaryWriter bytes)
		{
			bytes.Write(value.Length);
			bytes.Write(value.ToCharArray());
		}

		public static PCString FromJson(JToken token) => new(token.ToObject<string>());
		
		public JToken ToJson() => new JValue(value);
	}
}