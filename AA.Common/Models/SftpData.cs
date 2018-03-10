using System;
using System.Security;
using System.Security.Cryptography;
using AAS.Common.Extensions;
using AAS.Common.Helpers.Security;
using AAS.Common.Practices.Option;

namespace AAS.Common.Models
{
	public class SftpData
	{
		private static readonly string passPhrease = "AASPras";
		private static readonly string hashAlgorithm = "SHA256";
		private static readonly string salt = "AASTextSalt";
		private static readonly string initVector = "!1A3g2D4s9K556g7";
		private static readonly short keySize = 256;
		private static readonly short passwordIterations = 2;

		public string Host { get; protected set; }
		public short? Port { get; protected set; }
		public string UserId { get; protected set; }
		public SecureString Password => SecurePassword(HashedPassword);
		public string HashedPassword { get; private set; }
		public string RemoteDirectory { get; protected set; }
		public Uri RemoteDirectoryUri => new Uri(RemoteDirectory, UriKind.RelativeOrAbsolute);

		public SftpData()
		{
		}

		public SftpData(string host, short? port, string userId, string password, string remoteDir)
		{
			if (!Uri.IsWellFormedUriString(remoteDir, UriKind.RelativeOrAbsolute))
			{
				throw new UriFormatException($"{remoteDir} is not a valid uri");
			}

			Host = host;
			Port = port;
			UserId = userId;
			HashedPassword = EncryptPassword(password);
			RemoteDirectory = remoteDir;
		}

		private static string EncryptPassword(string password)
		{
			return RijndaelAlgorithm.Encrypt(password, passPhrease, salt, hashAlgorithm, passwordIterations, initVector, keySize);
		}

		private static SecureString SecurePassword(string hashedPassword)
		{
			return RijndaelAlgorithm.Decrypt(hashedPassword, passPhrease, salt, hashAlgorithm, passwordIterations, initVector, keySize)
				.Encrypt();
		}

	}
}