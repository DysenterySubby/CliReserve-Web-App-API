using Azure.Storage;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using CliReserve.Dtos.Clir;
using CliReserve.Entities;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;

namespace CliReserve.Services
{
    public class ClirBlobService
    {
        private readonly IConfiguration _configuration;
        private readonly string _key;
        private readonly string _storageAccount;

        private readonly BlobContainerClient _filesContainer;
        public ClirBlobService(IConfiguration configuration)
        {
            _configuration = configuration;

            _key = _configuration.GetSection("Azure:Key").Value;
            _storageAccount = _configuration.GetSection("Azure:StorageAccount").Value;

            var credential = new StorageSharedKeyCredential(_storageAccount, _key);

            var blobServiceClient = new BlobServiceClient(new Uri($"https://{_storageAccount}.blob.core.windows.net"), credential);

            _filesContainer = blobServiceClient.GetBlobContainerClient("clir");
        }

        public async Task<byte[]> GetClirImageAsync(string clirName)
        {
            BlobClient blobClient = _filesContainer.GetBlobClient($"{clirName.ToLower()}/{clirName.ToLower()}.jpg");
            if (await blobClient.ExistsAsync())
            {
                BlobDownloadInfo download = await blobClient.DownloadAsync();
                using (MemoryStream ms = new MemoryStream())
                {
                    await download.Content.CopyToAsync(ms);
                    return ms.ToArray();
                }
            }
            return null;

        }
        public async Task<byte[]> GetSeatTypeImageAsync(string seatTypeId, string clirName)
        {
            
            BlobClient blobClient = _filesContainer.GetBlobClient($"{clirName.ToLower()}/{seatTypeId}.png");
            if (await blobClient.ExistsAsync())
            {
                BlobDownloadInfo download = await blobClient.DownloadAsync();
                using (MemoryStream ms = new MemoryStream())
                {
                    await download.Content.CopyToAsync(ms);
                    return ms.ToArray();
                }
            }
            return null;
        }
    }
}
