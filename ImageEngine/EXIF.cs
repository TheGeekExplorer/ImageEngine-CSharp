using System;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;

namespace ImageEngine
{
    class EXIF
    {
        public static String Manufacturer;
        public static String Camera;
        public static String Lens;
        public static String ISO;
        public static String ShutterSpeed;
        public static String Aperture;
        public static String FNumber;
        public static String FocalLength;
        public static String ExposureTime;
        public static String ImageWidth;
        public static String ImageHeight;
        public static String Colour;
        public static String ColourProfile;
        public static String DateTaken;
        public static String Date;


        public static bool readExif(String file)
        {

            // Create an Image object. 
            Bitmap image = new Bitmap(@file);

            // Get all property items
            PropertyItem[] propItems = image.PropertyItems;

            // Array to return the results in
            String[] results = new String[100];


            // Run through the Property Items for the Image
            foreach (var prop in propItems) {

                // Pass the property to the router to have it decoded into a string
                String type = prop.Type.ToString();
                String data="";


                if (type=="1")
                    data = type2(prop.Value);

                if (type=="2")
                    data = type2(prop.Value);

                if (type=="3")
                    data = type2(prop.Value);

                if (type=="4")
                    data = type2(prop.Value);

                if (type=="5")
                    data = type5(prop.Value);

                //Console.WriteLine(prop.Id.ToString("x") + "," + prop.Type.ToString() + ", " + data);

                // Manufacturer (determined by ID Hex Value)               
                if (prop.Id.ToString("x") == "10f")
                    Manufacturer = data;

                // Equipment Model (determined by ID Hex Value)
                if (prop.Id.ToString("x") == "110")
                    Camera = data;
                    
                // Lens Make (determined by ID Hex Value)
                if (prop.Id.ToString("x") == "a434")
                    Lens = data;
                    
                // Shutter Speed (determined by ID Hex Value)
                if (prop.Id.ToString("x") == "8827")
                    ISO = data;
                
                // Shutter Speed (determined by ID Hex Value)
                if (prop.Id.ToString("x") == "9201")
                    ShutterSpeed = data;
                
                // Aperture (determined by ID Hex Value)
                if (prop.Id.ToString("x") == "829d")
                    FNumber = data;

                // Aperture (determined by ID Hex Value)
                if (prop.Id.ToString("x") == "9202")
                    Aperture = data;
                    
                // Focal Length (determined by ID Hex Value)
                if (prop.Id.ToString("x") == "a20f")
                    FocalLength = data;
                
                // Exposure Time (determined by ID Hex Value)
                if (prop.Id.ToString("x") == "829a")
                    ExposureTime = data;

            }
            return true;
        }



        // TYPE 1 PropertyItems decoding and returning
        // This type is a BYTE in ASCI chars that needs
        // to be converted into chars
        private static String type1 (Byte prop)
        {
            return Convert.ToChar(prop).ToString();
        }


        // TYPE 2 PropertyItems decoding and returning
        // This type is a BYTE array in ASCI chars that needs
        // to be converted into chars
        private static String type2 (Byte[] prop)
        {
            String data="";

            // Run through the Byte Array
            foreach (var c in prop) {
                
                // Convert ASCII number into Alpha-Numeric Value
                data += Convert.ToChar(c);
            }
            return data;
        }


        // TYPE 2 PropertyItems decoding and returning
        // This type is a BYTE array in ASCI chars that needs
        // to be converted into chars
        private static String type5 (Byte[] prop)
        {
            Double sum = (Convert.ToDouble(prop[0]) + Convert.ToDouble(prop[1])) / 10;
            return sum.ToString();
        }
    }
}

