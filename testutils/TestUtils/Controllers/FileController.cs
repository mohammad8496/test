using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TestUtils.Models;

namespace TestUtils.Controllers
{
    /// <summary>
    /// Do operation about files
    /// </summary>
    [Route("api/[controller]/[action]")]
    public class FileController : Controller
    {
        /// <summary>
        /// Show file content
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult ShowFileContent()
        {
            return View();
        }

        /// <summary>
        /// Show file content
        /// </summary>
        /// <param name="file">file from view</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> ShowFileContent(UploadedFile file)
        {
            await file.GetContentAsync();

            return View(file);
        }
    }
}
