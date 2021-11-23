﻿using QuizApp.Application.Interfaces.Infrastructure;
using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using System.IO;

namespace QuizApp.Infrastructure.Storage
{
    public class AzureStorageService : IFileStorageService
    {
        private readonly string connectionString;

        public AzureStorageService(IConfiguration configuration)
        {
            connectionString = configuration.GetConnectionString("AzureStorageConnection");
        }

        public async Task DeleteFile(string fileRoute, string containerName)
        {
            if (string.IsNullOrEmpty(fileRoute)) return;

            var client = new BlobContainerClient(connectionString, containerName);
            await client.CreateIfNotExistsAsync();
            var fileName = Path.GetFileName(fileRoute);
            var blob = client.GetBlobClient(fileName);
            await blob.DeleteIfExistsAsync();
        }

        public async Task<string> EditFile(byte[] content, string extension, string containerName, string fileRoute)
        {
            await DeleteFile(fileRoute, containerName);
            return await SaveFile(content, extension, containerName);
        }

        public async Task<string> SaveFile(byte[] content, string extension, string containerName)
        {
            var client = new BlobContainerClient(connectionString, containerName);
            await client.CreateIfNotExistsAsync();
            client.SetAccessPolicy(PublicAccessType.Blob);

            var fileName = $"{Guid.NewGuid()}{extension}";
            var blob = client.GetBlobClient(fileName);

            using var ms = new MemoryStream(content);
            await blob.UploadAsync(ms);

            return blob.Uri.ToString();
        }
    }
}
