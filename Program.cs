using System;
using System.IO;
using ImageEngine;

namespace CSharpTesting
{
    class Program
    {
        static void Main(string[] args)
        {
            String path = "D:\\Photos\\DCIM\\100CANON\\";

            // File to read data from
            if (args.Length != 0) path = args[1];

            // Get all image files in directory
            string[] dirs = Directory.GetFiles(@path, "*.jpg");

            // Now write the EXIF data out to a file
            StreamWriter file = new StreamWriter(@path + "EXIF.txt", false);

            // Run through each file, and get their EXIF data
            //foreach (var d in dirs) {

                // Get the EXIF data for a photo
                bool result = EXIF.readExif(path + "IMG_0763.jpg");
                
                Console.WriteLine("Manufacturer: "  + EXIF.Manufacturer);
                Console.WriteLine("Camera Model: "  + EXIF.Camera);
                Console.WriteLine("Lens Model: "    + EXIF.Lens);
                Console.WriteLine("Aperture: "      + EXIF.Aperture);
                Console.WriteLine("Aperture: "      + EXIF.FNumber);
                Console.WriteLine("Focal Length: "  + EXIF.FocalLength);
                Console.WriteLine("Shutter Speed: " + EXIF.ShutterSpeed);
                Console.WriteLine("Exposure Time: " + EXIF.ExposureTime);
                Console.WriteLine("Image Size:  "   + EXIF.ImageWidth + "x" + EXIF.ImageHeight);
            //}

            file.Close();
        }
    }
}

