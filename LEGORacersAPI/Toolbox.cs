using System;
using System.IO;
using System.Security.Cryptography;

namespace LEGORacersAPI
{
    public abstract class Toolbox
    {
        /// <summary>
        /// Retrieves the MD5 hash of the given file.
        /// </summary>
        /// <param name="file">The file to retrieve the MD5 hash from.</param>
        public static string GetMD5Hash(string file)
        {
            using (var md5 = MD5.Create())
            {
                using (var stream = File.OpenRead(file))
                {
                    return BitConverter.ToString(md5.ComputeHash(stream)).Replace("-", "").ToLower();
                }
            }
        }
    }
}