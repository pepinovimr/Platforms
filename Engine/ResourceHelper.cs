using System.Collections.Generic;
using System.Drawing;
using System.IO;

namespace Platforms.Engine
{
    /// <summary>
    /// Loads resources from File
    /// </summary>
    internal static class ResourceHelper
    {
        /// <param name="path">Path to file with sprites/Images</param>
        /// <returns>Dictionary with loaded Images with their name as Keys</returns>
        /// <exception cref="DirectoryNotFoundException">Thrown if path is invalid</exception>
        public static Dictionary<string, Image> GetSprites(string path)
        {
            if (!Directory.Exists(path))
                throw new DirectoryNotFoundException("Directory on path " + path + "was not found!");

            Dictionary<string, Image> images = new Dictionary<string, Image>();

            foreach (string resource in Directory.GetFiles(path))
            {
                string[] pathParts = resource.Split('\\');
                images.Add(pathParts[pathParts.Length - 1].Split('.')[0], Image.FromFile(resource)); ;
            }

            return images;
        }
        public static Bitmap GetMap(string path)
        {
            if (!File.Exists(path))
                throw new FileNotFoundException("File on path " + path + "was not found!");

            return (Bitmap)Bitmap.FromFile(path);
        }
    }
}
