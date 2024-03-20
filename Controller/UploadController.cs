using System.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Net.Http.Headers;
using navdata.attributes;
using navdata.models;
using navdata.parsers;

namespace navdata.controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class UploadController : ControllerBase
    {
        private readonly ILogger<UploadController> _logger;
        private readonly Arinc424Parser _arincParser;
        private readonly StreamedDataHandler _streamedDataHandler;

        public UploadController(ILogger<UploadController> logger, Arinc424Parser arincParser, StreamedDataHandler streamedDataHandler) {
            _logger = logger;
            _arincParser = arincParser;
            _streamedDataHandler = streamedDataHandler;
        }  

        
        [Route("arinc")]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status415UnsupportedMediaType)]
        [MultipartFormData]
        [DisableFormValueModelBinding]
        public async Task<IActionResult> Arinc424Upload() {     
            
            FileUploadSummary summary = await _streamedDataHandler.HandleData(HttpContext.Request, _arincParser);

            return CreatedAtAction(nameof(Arinc424Upload), summary);
        }
    }
}
