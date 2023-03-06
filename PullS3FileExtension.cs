using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Siliconvalve.AwsS3Extension;
using Newtonsoft.Json;
using Siliconvalve.AwsS3Extension.Model;

namespace samplefunc02
{
    public static class PullS3FileExtension
    {
        [FunctionName("PullS3FileExtension")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req,
            [S3TextFile(BucketName = "%bucketName%",FileKeyName ="%keyName%",AwsRegionName ="%regionName%")] AwsTextFile s3FileContents,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function received a request.");

            return new OkObjectResult(s3FileContents.Content);
        }
    }
}