using System.IO;
using System.Xml;

namespace AAS.Common.Helpers.Serialization
{
	public interface IXmlSerializer<TTarget>
	{
		XmlDocument SerializeDocument(TTarget objectToSerialize);
		XmlElement SerializeElement(TTarget objectToSerialize);
		void SerializeIntoStream(MemoryStream stream, TTarget objectToSerialize);

		bool CanDeserializeFile(string fileFullName);
		TTarget DeserializeFile(string fileFullName);
	}
}