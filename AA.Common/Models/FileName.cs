namespace AAS.Common.Models
{

	public class FileName
	{

		public FileName(string fileName, string fileExtension)
		{
			Name = fileName;
			Extension = fileExtension;
		}

		public string Name { get; }
		public string Extension { get; }

		public string NameWithExtension => $"{Name}.{Extension}";

		public override string ToString()
		{
			return NameWithExtension;
		}
	}
}