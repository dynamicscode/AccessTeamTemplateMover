using System;
using System.IO;
using System.IO.Compression;

namespace AccessTeamTemplateMoverPlugin.Utility
{
    public static class FileZipper
    {
        public static void Compress(FileInfo fileToCompress)
        {
            using (FileStream originalFileStream = fileToCompress.OpenRead())
            {
                if ((File.GetAttributes(fileToCompress.FullName) &
                    FileAttributes.Hidden) != FileAttributes.Hidden & fileToCompress.Extension != ".gz")
                {
                    FileStream compressedFileStream = File.Create(fileToCompress.FullName + ".gz");
                    using (GZipStream compressionStream = new GZipStream(compressedFileStream,
                        CompressionMode.Compress))
                    {
                        originalFileStream.CopyTo(compressionStream);
                    }

                    FileInfo info = new FileInfo(fileToCompress.Name + ".gz");

                    Console.WriteLine("Compressed {0} from {1} to {2} bytes.",
                    fileToCompress.Name, fileToCompress.Length.ToString(), info.Length.ToString());
                }

            }
        }

        public static string Decompress(string fileName)
        {
            FileInfo fileToDecompress = new FileInfo(fileName);
            string newFileName = string.Empty;

            FileStream originalFileStream = fileToDecompress.OpenRead();

            string currentFileName = fileToDecompress.FullName;
            newFileName = nameNewFile(fileToDecompress.Extension, currentFileName);

            using (FileStream decompressedFileStream = File.Create(newFileName))
            {
                using (GZipStream decompressionStream = new GZipStream(originalFileStream, CompressionMode.Decompress))
                {
                    decompressionStream.CopyTo(decompressedFileStream);
                    Console.WriteLine("Decompressed: {0}", fileToDecompress.Name);
                }
            }

            return newFileName;
        }

        private static string nameNewFile(string extension, string currentFileName)
        {
            string newFileName = currentFileName.Remove(currentFileName.Length - extension.Length);
            newFileName = newFileName.Substring(0, newFileName.LastIndexOf('.')) + "_extracted" + newFileName.Substring(newFileName.LastIndexOf('.'));
            return newFileName;
        }
    }
}
