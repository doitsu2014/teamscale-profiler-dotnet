﻿using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Abstractions;
using System.IO.Abstractions.TestingHelpers;

namespace UploadDaemon.Archiving
{
    [TestFixture]
    public class ArchiveTest
    {
        private const string TraceDirectory = @"C:\users\public\traces";
        private Mock<IDateTimeProvider> dateTimeProvider;

        [SetUp]
        public void SetUp()
        {
            dateTimeProvider = new Mock<IDateTimeProvider>();
        }

        [Test]
        public void ShouldMoveFilesToCorrectSubfolders()
        {
            IFileSystem fileSystem = new MockFileSystem(new Dictionary<string, MockFileData>()
            {
                { FileInTraceDirectory("coverage_1_1.txt"), @"uploaded" },
                { FileInTraceDirectory("coverage_1_2.txt"), @"missing version" },
                { FileInTraceDirectory("coverage_1_3.txt"), @"empty trace" },
            });

            new Archive(TraceDirectory, fileSystem, dateTimeProvider.Object).ArchiveUploadedFile(FileInTraceDirectory("coverage_1_1.txt"));
            new Archive(TraceDirectory, fileSystem, dateTimeProvider.Object).ArchiveFileWithoutVersionAssembly(FileInTraceDirectory("coverage_1_2.txt"));
            new Archive(TraceDirectory, fileSystem, dateTimeProvider.Object).ArchiveEmptyFile(FileInTraceDirectory("coverage_1_3.txt"));

            string[] files = fileSystem.Directory.GetFiles(TraceDirectory, "*.txt", SearchOption.AllDirectories);

            Assert.That(files, Is.EquivalentTo(new string[] {
                FileInTraceDirectory(@"uploaded\coverage_1_1.txt"),
                FileInTraceDirectory(@"missing-version\coverage_1_2.txt"),
                FileInTraceDirectory(@"empty-traces\coverage_1_3.txt"),
            }));
        }

        [Test]
        public void ShouldHandleArchivingExceptionsGracefully()
        {
            IFileSystem fileSystemMock = FileSystemMockingUtils.MockFileSystem(fileMock =>
                {
                    fileMock.Setup(file => file.ReadAllLines(FileInTraceDirectory("coverage_1_1.txt"))).Throws<IOException>();
                },
            directoryMock =>
                {
                    // not needed
                }
            ).Object;

            new Archive(TraceDirectory, fileSystemMock, dateTimeProvider.Object).ArchiveUploadedFile(FileInTraceDirectory("coverage_1_1.txt"));
        }

        [Test]
        public void ShouldPurgeOldFiles()
        {
            dateTimeProvider.Setup(dtp => dtp.Now).Returns(new DateTime(2019, 5, 4));
            IFileSystem fileSystemMock = new MockFileSystem(new Dictionary<string, MockFileData>()
            {
                { FileInTraceDirectory(@"uploaded\coverage_1_1.txt"), FileCreatedOn(2019, 5, 1) },
                { FileInTraceDirectory(@"uploaded\coverage_1_2.txt"), FileCreatedOn(2019, 5, 2) },
                { FileInTraceDirectory(@"uploaded\coverage_1_3.txt"), FileCreatedOn(2019, 5, 3) },
                { FileInTraceDirectory(@"missing-version\coverage_1_2.txt"), FileCreatedOn(2019, 4, 1) },
                { FileInTraceDirectory(@"empty-traces\coverage_1_3.txt"), FileCreatedOn(2019, 5, 1) },
            });

            new Archive(TraceDirectory, fileSystemMock, dateTimeProvider.Object).PurgeUploadedFiles(TimeSpan.FromDays(2));
            new Archive(TraceDirectory, fileSystemMock, dateTimeProvider.Object).PurgeFilesWithoutVersionAssembly(TimeSpan.FromDays(2));
            new Archive(TraceDirectory, fileSystemMock, dateTimeProvider.Object).PurgeUploadedFiles(TimeSpan.FromDays(5));

            string[] remainingFiles = fileSystemMock.Directory.GetFiles(TraceDirectory, "*.txt", SearchOption.AllDirectories);
            Assert.That(remainingFiles, Is.EquivalentTo(new string[] {
               FileInTraceDirectory(@"uploaded\coverage_1_3.txt"),
               FileInTraceDirectory(@"empty-traces\coverage_1_3.txt"),
            }));
        }

        [Test]
        public void ShouldHandlePurgingExceptionsGracefully()
        {
            IFileSystem fileSystemMock = FileSystemMockingUtils.MockFileSystem(fileMock =>
                {
                    // not needed
                },
            directoryMock =>
                {
                    directoryMock.Setup(dir => dir.GetFiles(Path.Combine(TraceDirectory, "empty-traces"))).Throws<IOException>();
                }
            ).Object;

            new Archive(TraceDirectory, fileSystemMock, dateTimeProvider.Object).PurgeEmptyFiles(TimeSpan.FromDays(42));
        }

        /// <summary>
        /// Returns a file with the given name in the trace directory.
        /// </summary>
        private string FileInTraceDirectory(string fileName)
        {
            return Path.Combine(TraceDirectory, fileName);
        }

        private MockFileData FileCreatedOn(int year, int month, int day)
        {
            return new MockFileData("")
            {
                CreationTime = new DateTime(year, month, day)
            };
        }
    }
}
