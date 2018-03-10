using System;
using System.Runtime.InteropServices;
using System.Security;

namespace AAS.Common.Extensions
{
	public static class SecureStringExtensions
	{
		public static string Decrypt(this SecureString securedString)
		{
			IntPtr value = IntPtr.Zero;
			try
			{
				value = Marshal.SecureStringToGlobalAllocUnicode(securedString);

				return Marshal.PtrToStringUni(value);
			}
			finally
			{
				Marshal.ZeroFreeGlobalAllocUnicode(value);
			}
		}

		public static SecureString Encrypt(this string value)
		{
			 SecureString securedString = new SecureString();

			foreach (char character in value)
			{
				securedString.AppendChar(character);			
			}
			securedString.MakeReadOnly();
			return securedString;
		}
	}
}