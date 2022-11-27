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

        public static Dictionary<string, Image> getImages(string path)
        {
            Dictionary<string, Image> images = new Dictionary<string, Image>();
            if (!Directory.Exists(path))
                throw new DirectoryNotFoundException("Directory on path " + path + "was not found!");

            foreach (string resource in Directory.GetFiles(path))
            {
                string[] pathParts = resource.Split('\\');
                images.Add(pathParts[pathParts.Length - 1].Split('.')[0], Image.FromFile(resource)); ;
            }

            return images;
        }
    }
}
