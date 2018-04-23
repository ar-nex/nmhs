using System;
using System.IO;

namespace NaimouzaHighSchool.ViewModels.Helpers
{
    public static class BackgroundImageHelper
    {
        public static string GetRandomImagePath()
        {
            // get the base directory
            string myPictureDirecotry = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
            string pathString = Path.Combine(myPictureDirecotry, "nmhs-nexap\\bg");
            Directory.CreateDirectory(pathString);
            string[] files = Directory.GetFiles(pathString);
            string imgfile = string.Empty;
            if (files.Length > 0)
            {
                Random rnd = new Random();
                imgfile = files[rnd.Next(files.Length)];
            }
            return imgfile;
        }
    }
}
