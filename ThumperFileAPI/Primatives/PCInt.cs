using System.IO;
using Newtonsoft.Json.Linq;
using ThumperFileAPI.Generics;

namespace ThumperFileAPI.Primatives
{
	public class PCInt : PCObject
	{
		public readonly int value;

		public PCInt(int value)
		{
			this.value = value;
		}
		
		public static PCInt FromBytes(BinaryReader bytes) => new(bytes.ReadInt32());

		public override void ToBytes(BinaryWriter bytes) => bytes.Write(value);

		public static PCInt FromJson(JToken token) => new(token.ToObject<int>());
		
		public override JToken ToJson() => new JValue(value);
	}
}