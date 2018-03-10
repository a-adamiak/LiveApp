using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace AAS.Common.Helpers.Serialization
{
	public class NamespaceIgnorantXmlSerializer<TTarget> : IXmlSerializer<TTarget>
	{
		private static XmlSerializerNamespaces Namespaces
		{
			get
			{
				XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
				namespaces.Add("", "");

				return namespaces;
			}
		}

		#region Serialization

		public XmlDocument SerializeDocument(TTarget objectToSerialize)
		{
			XmlDocument result = new XmlDocument();
			using (XmlWriter writer = result.CreateNavigator().AppendChild())
			{
				new XmlSerializer(typeof(TTarget))
					.Serialize(writer, objectToSerialize, Namespaces);
			}

			return result;
		}

		public XmlElement SerializeElement(TTarget objectToSerialize)
		{
			return SerializeDocument(objectToSerialize).DocumentElement;
		}

		public void SerializeIntoStream(MemoryStream stream, TTarget objectToSerialize)
		{
			new XmlSerializer(typeof(TTarget))
				.Serialize(stream, objectToSerialize, Namespaces);
		}

		#endregion

		#region Deserialization 

		public bool CanDeserializeFile(string fileFullName)
		{
			using (StreamReader reader = new StreamReader(fileFullName))
			{
				using (XmlTextReader xmlReader = new NamespaceIgnorantXmlTextReader(reader))
				{
					xmlReader.Namespaces = false;
					return new XmlSerializer(typeof(TTarget))
						.CanDeserialize(xmlReader);
				}
			}
		}

		public TTarget DeserializeFile(string fileFullName)
		{
			using (StreamReader reader = new StreamReader(fileFullName))
			{
				using (XmlTextReader xmlReader = new NamespaceIgnorantXmlTextReader(reader))
				{
					xmlReader.Namespaces = false;
					return (TTarget) new XmlSerializer(typeof(TTarget))
						.Deserialize(xmlReader);
				}
			}
		}

		#endregion
	}
}