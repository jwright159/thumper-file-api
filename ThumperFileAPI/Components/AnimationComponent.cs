using System.IO;
using Newtonsoft.Json.Linq;
using ThumperFileAPI.Generics;
using ThumperFileAPI.Primatives;

namespace ThumperFileAPI.Components
{
	public class AnimationComponent : PCObject
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

		public override void ToBytes(BinaryWriter bytes)
		{
			versionNumber.ToBytes(bytes);
			frame.ToBytes(bytes);
			unitOfTime.ToBytes(bytes);
		}

		public static AnimationComponent FromJson(JToken token) => new(
			new PCInt(1),
			new PCFloat(0),
			new PCString("kTimeBeats"));

		public override JToken ToJson() => new JObject();
	}
}