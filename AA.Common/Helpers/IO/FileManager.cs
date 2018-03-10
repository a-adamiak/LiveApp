using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Security;
using AAS.Common.Extensions;

namespace AAS.Common.Helpers.IO
{
	public static class FileManager
	{
		public static void CreateDirectoryIfNotExists(string directoryPath)
		{
			bool pathExists = Directory.Exists(directoryPath);
			if (!pathExists)
			{
				Directory.CreateDirectory(directoryPath);
			}
		}

		public static void CopyFile(string fileFullPath, string targetFullFileName, bool overwrite = false,
			bool throwExceptionWhenFileExists = true)
		{
			if (File.Exists(targetFullFileName))
			{
				if (overwrite)
				{
					File.Delete(targetFullFileName);
				}
				else if ( throwExceptionWhenFileExists)
				{
					throw new InvalidOperationException(
						$"File {targetFullFileName} already exists. Can not copy file {fileFullPath}");
				}
				else
					return;


				File.Copy(fileFullPath, targetFullFileName);
			}		
		}

		public static void MoveFile(string fileFullPath, string targetFileDirectory, string targetFileName,
			bool overwrite = false, bool throwExceptionWhenFileExists = true)
		{
			string targetPath = Path.Combine(targetFileDirectory, targetFileName);

			MoveFile(fileFullPath, targetPath, overwrite, throwExceptionWhenFileExists);
		}

		public static void MoveFile(string fileFullPath, string targetFullFileName, bool overwrite = false,
			bool throwExceptionWhenFileExists = true)
		{
			if (File.Exists(targetFullFileName))
			{
				if (overwrite)
				{
					File.Delete(targetFullFileName);
				}
				else if (throwExceptionWhenFileExists)
				{
					throw new InvalidOperationException(
						$"File {targetFullFileName} already exists. Can not move file {fileFullPath}");
				}
				else
					return;
				File.Move(fileFullPath, targetFullFileName);
			}
		}

		public static void SaveFile(MemoryStream stream, string filePath)
		{
			using (FileStream fileStream = File.OpenWrite(filePath))
			{
				fileStream.Write(stream.ToArray(), 0, (int) stream.Length);
			}
		}

		public static void SendFileOnFtp(string fileFullName, string targetFileUri, string userId,
			SecureString password)
		{
			FileInfo file = new FileInfo(fileFullName);

			FtpWebRequest request = (FtpWebRequest) WebRequest.Create(targetFileUri);
			request.Credentials = new NetworkCredential(userId, password);
			request.Method = WebRequestMethods.Ftp.UploadFile;
			request.UseBinary = true;
			request.ContentLength = file.Length;

			using (FileStream fileStream = File.OpenRead(file.FullName))
			{
				byte[] buffer = new byte[fileStream.Length];
				fileStream.Read(buffer, 0, buffer.Length);
				fileStream.Close();
				using (Stream requestStream = request.GetRequestStream())
				{
					requestStream.Write(buffer, 0, buffer.Length);
				}
			}
		}

		public static void SaveFileOnFtp(MemoryStream stream, string targetFileUri, string userId,
			SecureString password)
		{
			FtpWebRequest request = (FtpWebRequest) WebRequest.Create(targetFileUri);
			request.Credentials = new NetworkCredential(userId, password);
			request.Method = WebRequestMethods.Ftp.UploadFile;
			request.UseBinary = true;
			request.ContentLength = stream.Length;

			byte[] buffer = stream.GetBuffer();
			using (Stream requestStream = request.GetRequestStream())
			{
				requestStream.Write(buffer, 0, buffer.Length);
			}
		}
	}
}