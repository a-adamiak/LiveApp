using System.IO;
using System.Xml;

namespace AAS.Common.Helpers.Serialization
{
	internal class NamespaceIgnorantXmlTextReader : XmlTextReader
	{
		public NamespaceIgnorantXmlTextReader(TextReader reader) : base(reader)
		{
		}

		public override string NamespaceURI => string.Empty;
	}
}