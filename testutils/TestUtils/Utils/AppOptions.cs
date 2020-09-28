namespace TestUtils.Utils
{
    /// <summary>
    /// Contains App Configs
    /// </summary>
    public class AppOptions
    {
        /// <summary>
        /// Path of CI Info File
        /// </summary>
        public string CIInfoFilePath { set;  get; }

        /// <summary>
        /// Url Prefix for entire app
        /// </summary>
        public string UrlPrefix { set;  get; } = "";
    }
}
