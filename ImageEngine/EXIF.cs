using System;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;


namespace ImageEngine
{
    class EXIF
    {
        public static int ManufacturerPropID = 0;
        public static int CameraPropID = 1;
        public static int LensPropID = 13;
        public static int ColourPropID = 10;
        public static int ColourProfilePropID = 10;
        public static int DateTakenPropID = 5;
        public static int DatePropID = 5;
        public static String Manufacturer;
        public static String Camera;
        public static String Lens;
        public static String Colour;
        public static String ColourProfile;
        public static String DateTaken;
        public static String Date;




        public static String[] readExif(String file)
        {

            // Create an Image object. 
            Bitmap image = new Bitmap(@file);

            // Get all property items
            PropertyItem[] propItems = image.PropertyItems;
            int i = 0;
            int j = 0;

            // Array to return the results in
            String[] results = new String[50];


            // Run through the Property Items for the Image
            foreach (var prop in propItems) {

                String data = "";

                // We only want the ASCI fields
                if (prop.Type.ToString() == "2") {
                    
                    // Run through the Byte Array
                    foreach (var c in prop.Value) {

                        // Convert ASCII number into Alpha-Numeric Value
                        data += Convert.ToChar(c);
                    }

                    // Add data to the results array
                    results[j] = data;

                    // Iterate next
                    j++;
                }
                i++;
            }

            // Put the properties into the class variables
            Manufacturer  = results[ManufacturerPropID];
            Camera        = results[CameraPropID];
            Lens          = results[LensPropID];
            Colour        = results[ColourPropID];
            ColourProfile = results[ColourProfilePropID];
            DateTaken     = results[DateTakenPropID];
            Date          = results[DatePropID];

            // Return the property items
            return results;
        }
    }
}

