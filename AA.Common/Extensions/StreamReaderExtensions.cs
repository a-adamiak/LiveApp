using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AAS.Common.Extensions
{
	public static class StreamReaderExtensions
	{
		public static IEnumerable<string> ReadLazy(this TextReader reader, string separator)
		{
			StringBuilder builder = new StringBuilder();

			Queue<char> separatorBuffer = new Queue<char>(separator.Length);

			while (reader.CanPeek())
			{
				char nextChar = (char)reader.Read();
				if (nextChar == separator[separatorBuffer.Count])
				{
					separatorBuffer.Enqueue(nextChar);
					if (separatorBuffer.Count == separator.Length)
					{
						yield return builder.ToString();
						builder.Length = 0;
						separatorBuffer.Clear();
					}
				}
				else
				{
					separatorBuffer.Enqueue(nextChar);
					while (separatorBuffer.Any())
					{
						builder.Append(separatorBuffer.Dequeue());
						if (separatorBuffer.SequenceEqual(separator.Take(separatorBuffer.Count)))
						{
							break;
						}
					}
				}

				yield return builder + new string(separatorBuffer.ToArray());
			}
		}

		public static bool CanPeek(this TextReader reader)
		{
			return reader.Peek() >= 0;
		}
	}
}