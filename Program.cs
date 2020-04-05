using System;
using System.IO;
using ImageEngine;

namespace ImageTest
{
    class Program
    {
        static void Main(string[] args)
        {
            int i = 0;

            // File to read data from
            if (args.Length == 0) throw new Exception();
            
            // Get all image files in directory
            String[] dirs = Directory.GetFiles(@args[1], "*.jpg");

            // Run through each file, and get their EXIF data
            foreach (var d in dirs) {
                i++;

                // Get the EXIF data for a photo
                String[] results = EXIF.readExif(d);
                
                // Write lines to file
                Console.WriteLine(
                    "File="             + d                  + 
                    ", Manufacturer="   + EXIF.Manufacturer  + 
                    ", Camera="         + EXIF.Camera        + 
                    ", Lens="           + EXIF.Lens          +
                    ", Colour Palette=" + EXIF.ColourProfile + 
                    ", Date Taken="     + EXIF.Date
                );
            }
        }
    }
}

