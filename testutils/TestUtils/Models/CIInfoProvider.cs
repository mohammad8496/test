using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using TestUtils.Utils;

namespace TestUtils.Models
{
    /// <summary>
    /// A class for getting ci info from file
    /// </summary>
    public class CIInfoProvider : ICIInfoProvider
    {
        private readonly string _cIInfoFilePath;
        private readonly IFileProvider _fileProvider;
        private Dictionary<string, string> cIInfo = null;
        private readonly ILogger _logger;

        /// <summary>
        /// Constructor that takes CI Info file path
        /// </summary>
        /// <param name="fileProvider">file provider</param>
        /// <param name="optionsAccessor">used to get CIInfo file path</param>
        /// <param name="logger"></param>
        public CIInfoProvider(IFileProvider fileProvider, IOptions<AppOptions> optionsAccessor,
            ILogger<CIInfoProvider> logger)
        {
            _cIInfoFilePath = optionsAccessor.Value.CIInfoFilePath;
            _fileProvider = fileProvider;
            _logger = logger;

            _logger.LogTrace(LoggingEvents.FUNCTION_CALL, "Creating new instance of CIInfoProvider");
        }

        /// <summary>
        /// Get CI info as a dictionay
        /// </summary>
        /// <returns></returns>
        public async Task<Dictionary<string, string>> GetCIInfoAsync()
        {
            _logger.LogInformation(LoggingEvents.FUNCTION_CALL, "Requesting CIInfo");

            if (cIInfo == null)
            {
                _logger.LogDebug("CIInfo is empty so getting it from file provider usgin path {CIInfoPath}", _cIInfoFilePath);
                using (var readStream = _fileProvider.GetFileInfo(_cIInfoFilePath).CreateReadStream())
                {
                    using (var reader = new StreamReader(readStream))
                    {
                        var cIFileContent = await reader.ReadToEndAsync();
                        _logger.LogDebug("CIInfo file content got: {CIFileContent}", cIFileContent);

                        cIInfo = JsonConvert.DeserializeObject<Dictionary<string, string>>(cIFileContent);
                    }
                }
            }

            _logger.LogDebug(LoggingEvents.FUNCTION_RETURN, "Returning CI Info: {CIInfo}", cIInfo);
            return cIInfo;
        }

        /// <summary>
        /// Get Build Data as a string
        /// </summary>
        /// <returns></returns>
        public async Task<string> GetBuildDateAsStringAsync()
        {
            _logger.LogTrace(LoggingEvents.FUNCTION_CALL, "Requesting build Date");

            var cIInfo = await GetCIInfoAsync();
            var buildDate = cIInfo["build_date"];

            _logger.LogTrace(LoggingEvents.FUNCTION_RETURN, "Returing build Date: {BuildDate}", buildDate);
            return buildDate;
        }
    }
}
