using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Threading.Tasks;
using TestUtils.Utils;

namespace TestUtils.Models
{
    /// <summary>
    /// Uploaded File Model
    /// </summary>
    public class UploadedFile
    {
        /// <summary>
        /// File instance
        /// </summary>
        [Required]
        public IFormFile File { get; set; }

        /// <summary>
        /// Name of file
        /// </summary>
        public string Name
        {
            get
            {
                if (File == null)
                {
                    return null;
                }
                if (_name == null)
                {
                    _name = Path.GetFileName(File.FileName);
                }
                return _name;
            }
        }
        private string _name;

        /// <summary>
        /// Get Content from File
        /// </summary>
        /// <returns></returns>
        public async Task GetContentAsync()
        {
            if (File == null)
            {
                return;
            }

            ZipContent = null;
            try
            {
                ZipContent = await ZipUtils.GetInsideAZipContentsAsync(File.OpenReadStream());
            }
            catch (InvalidDataException) { }

            if (ZipContent == null)
            {
                using (var stream = File.OpenReadStream())
                {
                    using (var reader = new StreamReader(stream))
                    {
                        Content = await reader.ReadToEndAsync();
                    }
                }
            }
        }


        /// <summary>
        /// Content of file
        /// </summary>
        [DataType(DataType.MultilineText)]
        public string Content { set; get; }


        /// <summary>
        /// Contains
        /// </summary>
        public Dictionary<string, string> ZipContent { set; get; }


        /// <summary>
        /// Whether the file is a zip one
        /// </summary>
        public bool IsZip => ZipContent != null;
    }
}
