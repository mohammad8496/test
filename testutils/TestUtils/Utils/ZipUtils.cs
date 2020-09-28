using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestUtils.Utils
{
    /// <summary>
    /// Utilities for working with zip files
    /// </summary>
    public static class ZipUtils
    {
        /// <summary>
        ///     Zip a memory stream
        /// </summary>
        /// <param name="sourceStream"> MemoryStream with original file </param>
        /// <param name="fileName"> Name of the file in the ZIP container </param>
        /// <returns> Return byte array of zipped file </returns>
        public static byte[] GetZippedFile(MemoryStream sourceStream, string fileName)
        {
            using (var zipStream = new MemoryStream())
            {
                using (var zip = new ZipArchive(zipStream, ZipArchiveMode.Create, true))
                {
                    var zipEntry = zip.CreateEntry(fileName);
                    using (var writer = new StreamWriter(zipEntry.Open()))
                    {
                        sourceStream.WriteTo(writer.BaseStream);
                    }
                }
                return zipStream.ToArray();
            }
        }

        /// <summary>
        /// create a file from a string and put in in a zip file
        /// </summary>
        /// <param name="content">content of the file</param>
        /// <param name="fileName">file name</param>
        /// <returns></returns>
        public static byte[] GetZippedFileFromString(string content, string fileName)
        {
            var stream = new MemoryStream(Encoding.UTF8.GetBytes(content));

            return GetZippedFile(stream, fileName);
        }

        /// <summary>
        /// Unzip a zip file and return content of it's file
        /// </summary>
        /// <param name="zipBytes">input zip bytes</param>
        /// <returns>A map from file name to it's content as string</returns>
        public static Task<Dictionary<string, string>> GetInsideAZipContentsAsync(byte[] zipBytes)
        {
            using (var zipStream = new MemoryStream(zipBytes))
            {
                return GetInsideAZipContentsAsync(zipStream);
            }
        }

        /// <summary>
        /// Unzip a zip file and return content of it's file
        /// </summary>
        /// <param name="zipStream">Zip content as stream</param>
        /// <returns>A map from file name to it's content as string</returns>
        public static async Task<Dictionary<string, string>> GetInsideAZipContentsAsync(Stream zipStream)
        {
            using (var zip = new ZipArchive(zipStream, ZipArchiveMode.Read))
            {
                var result = new Dictionary<string, string>(zip.Entries.Count);

                foreach (var zipEntry in zip.Entries)
                {
                    using (var reader = new StreamReader(zipEntry.Open()))
                    {
                        result.Add(zipEntry.Name, await reader.ReadToEndAsync());
                    }
                }

                return result;
            }
        }
    }
}
