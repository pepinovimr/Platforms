using Platforms.Engine.Objects;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Numerics;

namespace Platforms.Engine
{
    /// <summary>
    /// Helps creating maps
    /// </summary>
    internal class MapCreator
    {

        /// <summary>
        /// Creates game map by making game objects from file by converting colors to gameObjects
        /// </summary>
        /// <param name="colorObjectDictionary">Dictionary whit key as color and Tuple with Type of GameObject and Image to set it</param>
        /// <param name="map">Bitmap with pixels </param>
        /// <param name="scale">How big should 1 tile be</param>
        /// <exception cref="ArgumentException">Type is not inherited type from GameObject</exception>
        public static void CreateMapByColor(Dictionary<Color, Tuple<Type, Image>> colorObjectDictionary, Bitmap map, int scale)
        {
            if (IsTypeOfGameObject(colorObjectDictionary))
            {
                throw new ArgumentException("One or more types do not inherit GameObject class");
            }

            for (int i = 0; i < map.Width; i++)
            {
                for(int j = 0; j < map.Height; j++)
                {
                    Color pixel = map.GetPixel(i, j);

                    if (colorObjectDictionary.ContainsKey(pixel))
                    { 
                        Activator.CreateInstance(colorObjectDictionary[pixel].Item1, new Vector2(scale * i, scale * j), new Vector2(scale, scale), colorObjectDictionary[pixel].Item2);
                    }
                }

            }
        }

        private static bool IsTypeOfGameObject(Dictionary<Color, Tuple<Type, Image>> colorObjectDictionary)
        {
            foreach (var t in colorObjectDictionary.Values)
            {
                if (t.Item1 != typeof(GameObject))
                    return false;
            }
            return true;
        }
    }
}
