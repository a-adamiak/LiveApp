using System.IO;
using AAS.Common.Practices.Core;

namespace AAS.Common.Models
{
	public class TemporaryDictionary : Disposable
	{
		public TemporaryDictionary()
		{
			string tempFolder = Path.GetTempFileName();
			File.Delete(tempFolder);
			Directory.CreateDirectory(tempFolder);
			DirectoryPath = tempFolder;
		}

		public string DirectoryPath { get; }

		public override void ReleaseUnmanagedMemory()
		{
		}

		public override void ReleaseManagedMemory()
		{
			Directory.Delete(DirectoryPath, true);
		}
	}
}