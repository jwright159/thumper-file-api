using System.IO;
using Newtonsoft.Json.Linq;
using ThumperFileAPI.Primatives;

namespace ThumperFileAPI.Components
{
	public class AnimationComponent
	{
		public readonly PCInt versionNumber;
		public readonly PCFloat frame;
		public readonly PCString unitOfTime;

		public AnimationComponent(PCInt versionNumber, PCFloat frame, PCString unitOfTime)
		{
			this.versionNumber = versionNumber;
			this.frame = frame;
			this.unitOfTime = unitOfTime;
		}

		public static AnimationComponent FromBytes(BinaryReader bytes) => new(
			PCInt.FromBytes(bytes),
			PCFloat.FromBytes(bytes),
			PCString.FromBytes(bytes));

		public void ToBytes(BinaryWriter bytes)
		{
			versionNumber.ToBytes(bytes);
			frame.ToBytes(bytes);
			unitOfTime.ToBytes(bytes);
		}

		public static AnimationComponent FromJson(JToken token) => new(
			PCInt.FromJson(token["version_number"]),
			PCFloat.FromJson(token["frame"]),
			PCString.FromJson(token["unit_of_time"]));

		public JToken ToJson()
		{
			JObject jObject = new();
			jObject.Add("version_number", versionNumber.ToJson());
			jObject.Add("frame", frame.ToJson());
			jObject.Add("unit_of_time", unitOfTime.ToJson());
			return jObject;
		}
	}
}