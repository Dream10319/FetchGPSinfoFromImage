using MetadataExtractor;
using System;
using System.IO;
using System.Runtime.CompilerServices;

namespace fetchgeoinfo
{
    internal class Program
    {
        static void Main()
        {
            string curDic = System.IO.Directory.GetCurrentDirectory() + "\\images";
            try
            {
                string[] files = System.IO.Directory.GetFiles(curDic);
                GPSInfo gpsInfo = new GPSInfo();
                if(File.Exists("result.txt"))
                {
                    File.Delete("result.txt");
                }
                var result = File.Create("result.txt");
                result.Close();
                foreach (string file in files)
                {
                    var directories = ImageMetadataReader.ReadMetadata(file);
                    foreach (var directory in directories)
                    {
                        if(directory.Name == "GPS")
                        {
                            foreach (var tag in directory.Tags)
                            {
                                if (tag.Name == "GPS Version ID")
                                    gpsInfo.version = tag.Description;
                                if (tag.Name == "GPS Latitude Ref")
                                    gpsInfo.latref = tag.Description;
                                if(tag.Name == "GPS Latitude")
                                    gpsInfo.lat = tag.Description;
                                if(tag.Name == "GPS Longitude Ref")
                                    gpsInfo.lonref = tag.Description;
                                if(tag.Name == "GPS Longitude")
                                    gpsInfo.lon = tag.Description;
                                if(tag.Name == "GPS Altitude Ref")
                                    gpsInfo.altref = tag.Description;
                                if(tag.Name == "GPS Altitude")
                                    gpsInfo.alt = tag.Description;
                            }
                        }  
                    }
                    File.AppendAllText(@"result.txt", Path.GetFileName(file) + ":" + gpsInfo.lat + "," + gpsInfo.lon + "," + gpsInfo.alt + Environment.NewLine);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }
            Console.WriteLine("successfully done");
            Console.ReadKey();
        }
    }
}
