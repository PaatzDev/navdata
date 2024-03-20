using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Net.Http.Headers;
using navdata.models;

namespace navdata.parsers {
    public class StreamedDataHandler {

        private readonly ILogger<StreamedDataHandler> _logger;

        public StreamedDataHandler(ILogger<StreamedDataHandler> logger) {
            _logger = logger;
        }


        public async Task<FileUploadSummary> HandleData(HttpRequest request, IParser parser) {
            string boundary = GetBoundary(MediaTypeHeaderValue.Parse(request.ContentType));
            MultipartReader reader = new MultipartReader(boundary, request.Body);
            MultipartSection? section = await reader.ReadNextSectionAsync();
            
            FileUploadSummary summary = new FileUploadSummary();
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            while (section != null) {
                FileMultipartSection? fileSection = section.AsFileSection();
                if (fileSection != null && fileSection.FileStream != null) {
                    await parser.Parse(fileSection.FileStream, CancellationToken.None);
                    summary.FilePaths.Add(fileSection.FileName);
                    summary.TotalFilesUploaded++;
                }
            
                section = await reader.ReadNextSectionAsync();
            }

            stopwatch.Stop();

            _logger.LogInformation($"Parsed files within: {stopwatch.Elapsed}");

            return summary;
        }

        private string GetBoundary(MediaTypeHeaderValue contentType) {
            var boundary = HeaderUtilities.RemoveQuotes(contentType.Boundary).Value;

            if (string.IsNullOrWhiteSpace(boundary)) {
                throw new InvalidDataException("Missing content-type boundary.");
            }

            return boundary;
        }
    }
}