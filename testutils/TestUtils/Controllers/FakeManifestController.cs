using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.IO.Compression;
using System.Net;
using System.Text;
using TestUtils.Models.Manifest;
using TestUtils.Utils;

namespace TestUtils.Controllers
{
    /// <summary>
    /// Utilities around fake manifests
    /// </summary>
    [Route("api/[controller]/[action]")]
    public class FakeManifestController : Controller
    {
        /// <summary>
        /// Generate a fake manifest
        /// </summary>
        /// <param name="manifest">manifest model</param>
        /// <response code="200">Return the manifest content</response>
        /// <response code="400">If some nessesary input field is missing</response>
        /// <response code="500">If there is an error</response>
        [HttpGet]
        public string Generate(FakeManifest manifest)
        {
            return manifest.ToString();
        }

        /// <summary>
        /// Generate a fake manifest and show it on the page and then call download action
        /// </summary>
        /// <param name="manifest">manifest model</param>
        /// <response code="200">Return the manifest content and also download the file</response>
        /// <response code="400">If some nessesary input field is missing</response>
        /// <response code="500">If there is an error</response>
        [HttpGet]
        public IActionResult GenerateAndDownload(FakeManifest manifest)
        {
            return View(manifest);
        }

        /// <summary>
        /// Generate a fake Manifest and put it in a file inside a zip file and download it
        /// </summary>
        /// <param name="manifest">manifest model</param>
        /// <returns></returns>
        /// <response code="200">Will get the file</response>
        /// <response code="400">If some nessesary input field is missing</response>
        /// <response code="500">If there is an error</response>
        [HttpGet]
        public IActionResult Download(FakeManifest manifest)
        {
            var manifestContent = manifest.ToString();

            var zippedFileBytes = ZipUtils.GetZippedFileFromString(manifestContent, manifest.Name);

            return File(zippedFileBytes,
                        "application/zip",
                        $"{manifest.Name}.zip");

        }
    }
}
