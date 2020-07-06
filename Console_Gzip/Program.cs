using System;
using System.IO;
using System.IO.Compression;

namespace Console_Gzip
{
    class Program
    {
        static string fileName = @"C:\testC\111.txt";
        static string outputFileName = @"C:\testC\111.gzip"; 
        static void Main(string[] args)
        {
            Compress();
            deCompress();
        }
        static void Compress()
        { 
            try
            {
                using (FileStream inputStream = new FileStream(fileName, FileMode.OpenOrCreate,FileAccess.ReadWrite))
                {
                    using (FileStream outputStream = new FileStream(outputFileName,FileMode.OpenOrCreate,FileAccess.ReadWrite))
                    {
                        using (GZipStream gzip = new GZipStream(outputStream,CompressionMode.Compress))
                        {
                            inputStream.CopyTo(gzip);
                        } 
                    } 
                } 
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }
        }
        //..........................................................
        static void deCompress()
        { 
            try
            {
                using (FileStream inputStream = new FileStream(outputFileName, FileMode.OpenOrCreate, FileAccess.ReadWrite))
                {
                    using (FileStream outputStream = new FileStream(fileName, FileMode.OpenOrCreate, FileAccess.ReadWrite))
                    {
                        using (GZipStream gzip = new GZipStream(inputStream, CompressionMode.Decompress))
                        {
                            gzip.CopyTo(outputStream);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }
        }
        //..........................................................


    }
}
