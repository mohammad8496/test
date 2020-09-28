using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TestUtils.Models;

namespace TestUtils.Controllers
{
    /// <summary>
    /// Get Information about build process of this version
    /// </summary>
    [Route("api/[controller]/[action]")]
    public class CIInfoController : Controller
    {
        private readonly ICIInfoProvider _cIInfoProvider;

        /// <summary>
        /// The Construntor
        /// </summary>
        /// <param name="cIInfoProvider">The CI Info provider</param>
        public CIInfoController(ICIInfoProvider cIInfoProvider)
        {
            _cIInfoProvider = cIInfoProvider;
        }

        /// <summary>
        /// Get Build Date of App
        /// </summary>
        /// <response code="200">Return Build Date</response>
        /// <response code="500">If there is an error</response>
        [HttpGet]
        public async Task<string> BuildDate()
        {
            return await _cIInfoProvider.GetBuildDateAsStringAsync();
        }
    }
}
