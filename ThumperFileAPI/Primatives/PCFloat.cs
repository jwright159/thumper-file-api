using System.IO;
using Newtonsoft.Json.Linq;
using ThumperFileAPI.Generics;

namespace ThumperFileAPI.Primatives
{
	public class PCFloat : PCObject
	{
		public readonly float value;

		public PCFloat(float value)
		{
			this.value = value;
		}
		
		public static PCFloat FromBytes(BinaryReader bytes) => new(bytes.ReadSingle());

		public override void ToBytes(BinaryWriter bytes) => bytes.Write(value);

		public static PCFloat FromJson(JToken token) => new(token.ToObject<float>());
		
		public override JToken ToJson() => new JValue(value);
	}
}