using System.IO;
using Newtonsoft.Json.Linq;

namespace ThumperFileAPI.Primatives
{
	public class PCFloat
	{
		public readonly float value;

		public PCFloat(float value)
		{
			this.value = value;
		}
		
		public static PCFloat FromBytes(BinaryReader bytes) => new(bytes.ReadSingle());

		public void ToBytes(BinaryWriter bytes) => bytes.Write(value);

		public static PCFloat FromJson(JToken token) => new(token.ToObject<float>());
		
		public JToken ToJson() => new JValue(value);
	}
}