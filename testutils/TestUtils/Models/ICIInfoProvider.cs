using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TestUtils.Models
{
    /// <summary>
    /// Define a provider to get CI Info
    /// </summary>
    public interface ICIInfoProvider
    {
        /// <summary>
        /// Get CI info as a dictionay
        /// </summary>
        /// <returns></returns>
        Task<Dictionary<string, string>> GetCIInfoAsync();

        /// <summary>
        /// Get Build Data as a string
        /// </summary>
        /// <returns></returns>
        Task<string> GetBuildDateAsStringAsync();
    }
}