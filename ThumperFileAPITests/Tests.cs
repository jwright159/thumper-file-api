using System.IO;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using ThumperFileAPI.Components;
using ThumperFileAPI.Primatives;

namespace ThumperFileAPITests
{
	[TestFixture]
	public class Tests
	{
		[Test]
		public void AnimationComponent_FromBytes()
		{
			using (Stream stream = new MemoryStream())
			{
				BinaryWriter writer = new BinaryWriter(stream);
				writer.Write(15);
				writer.Write(0f);
				writer.Write(5);
				writer.Write("bepis".ToCharArray());
				writer.Write(999);
				
				writer.Flush();
				stream.Position = 0;

				BinaryReader reader = new BinaryReader(stream);
				AnimationComponent animationComponent = AnimationComponent.FromBytes(reader);
				Assert.That(animationComponent.versionNumber.value, Is.EqualTo(15));
				Assert.That(animationComponent.frame.value, Is.EqualTo(0f));
				Assert.That(animationComponent.unitOfTime.value, Is.EqualTo("bepis"));
				
				writer.Dispose();
				reader.Dispose();
			}
		}
		
		[Test]
		public void AnimationComponent_ToBytes()
		{
			using (Stream stream = new MemoryStream())
			{
				AnimationComponent animationComponent = new AnimationComponent(new PCInt(15), new PCFloat(0f), new PCString("bepis"));
				
				BinaryWriter writer = new BinaryWriter(stream);
				animationComponent.ToBytes(writer);
				
				writer.Flush();
				stream.Position = 0;

				BinaryReader reader = new BinaryReader(stream);
				Assert.That(reader.ReadInt32(), Is.EqualTo(15));
				Assert.That(reader.ReadSingle(), Is.EqualTo(0f));
				Assert.That(reader.ReadInt32(), Is.EqualTo(5));
				Assert.That(reader.ReadChars(5), Is.EqualTo("bepis"));
				
				writer.Dispose();
				reader.Dispose();
			}
		}
		
		[Test]
		public void AnimationComponent_FromJson()
		{
			JObject json = new JObject();
			json.Add("version_number", 15);
			json.Add("frame", 0f);
			json.Add("unit_of_time", "bepis");

			AnimationComponent animationComponent = AnimationComponent.FromJson(json);
			Assert.That(animationComponent.versionNumber.value, Is.EqualTo(15));
			Assert.That(animationComponent.frame.value, Is.EqualTo(0f));
			Assert.That(animationComponent.unitOfTime.value, Is.EqualTo("bepis"));
		}
		
		[Test]
		public void AnimationComponent_ToJson()
		{
			AnimationComponent animationComponent = new AnimationComponent(new PCInt(15), new PCFloat(0f), new PCString("bepis"));
			
			JToken json = animationComponent.ToJson();
			
			Assert.That(json.Value<int>("version_number"), Is.EqualTo(15));
			Assert.That(json.Value<float>("frame"), Is.EqualTo(0f));
			Assert.That(json.Value<string>("unit_of_time"), Is.EqualTo("bepis"));
		}
	}
}