﻿using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.File;
using NLog;
using System;
using System.IO;
using System.Threading.Tasks;
using Common;

namespace UploadDaemon.Upload
{
    /// <summary>
    /// Uploads trace files to an Azure File Storage.
    /// </summary>
    public class AzureUpload : IUpload
    {
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();

        private readonly AzureFileStorage storage;

        public AzureUpload(AzureFileStorage azureFileStorage)
        {
            storage = azureFileStorage;
        }

        public async Task<bool> UploadAsync(string filePath, string version)
        {
            try
            {
                CloudStorageAccount account = GetStorageAccount();

                logger.Debug("Uploading {trace} to {azure}/{directory}/", filePath, account.FileStorageUri, storage.Directory);

                CloudFileShare share = await GetOrCreateShareAsync(account);
                CloudFileDirectory directory = await GetOrCreateTargetDirectoryAsync(share);
                await UploadFileAsync(filePath, directory);

                logger.Info("Successfully uploaded {trace} to {azure}/{directory}", filePath, account.FileStorageUri, storage.Directory);

                return true;
            }
            catch (Exception e)
            {
                logger.Error(e, "Upload of {trace} to Azure File Storage failed: {message}", filePath, e.Message);
                return false;
            }
        }

        private CloudStorageAccount GetStorageAccount()
        {
            try
            {
                return CloudStorageAccount.Parse(storage.ConnectionString);
            }
            catch (Exception e) when (e is ArgumentNullException || e is ArgumentException || e is FormatException)
            {
                // Do not include the connection string to the message as it contains the private connection key!
                throw new UploadFailedException("Invalid Azure File Storage connection string provided.", e);
            }
        }

        private async Task<CloudFileShare> GetOrCreateShareAsync(CloudStorageAccount account)
        {
            CloudFileClient client = account.CreateCloudFileClient();
            CloudFileShare share = client.GetShareReference(storage.ShareName);

            await share.CreateIfNotExistsAsync();
            if (!await share.ExistsAsync())
            {
                throw new UploadFailedException($"Share {storage.ShareName} does not exist and could not be created.");
            }

            return share;
        }

        private async Task<CloudFileDirectory> GetOrCreateTargetDirectoryAsync(CloudFileShare share)
        {
            CloudFileDirectory directory = share.GetRootDirectoryReference();

            if (!string.IsNullOrEmpty(storage.Directory))
            {
                directory = directory.GetDirectoryReference(storage.Directory);
            }

            await CreateRecursiveIfNotExistsAsync(directory);

            return directory;
        }

        private async Task CreateRecursiveIfNotExistsAsync(CloudFileDirectory directory)
        {
            if (!await directory.ExistsAsync())
            {
                await CreateRecursiveIfNotExistsAsync(directory.Parent);
                await directory.CreateAsync();
            }
        }

        private static async Task UploadFileAsync(string sourceFilePath, CloudFileDirectory targetDirectory)
        {
            string fileName = Path.GetFileName(sourceFilePath);
            CloudFile file = targetDirectory.GetFileReference(fileName);
            await file.UploadFromFileAsync(sourceFilePath);
        }

        public string Describe()
        {
            return $"Azure share {storage.ShareName}, directory {storage.Directory}";
        }

        private class UploadFailedException : Exception
        {
            public UploadFailedException(string message) : base(message)
            {
            }

            public UploadFailedException(string message, Exception innerException) : base(message, innerException)
            {
            }
        }
    }
}