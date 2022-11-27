using System.Drawing;
using System.Numerics;

namespace Platforms.Engine.Objects
{
    /// <summary>
    /// default preset for Game object
    /// </summary>
    internal class GameObject
    {
        /// <summary>
        /// Position of game object
        /// </summary>
        public Vector2 Position;

        /// <summary>
        /// Size of game object
        /// </summary>
        public Vector2 Size;

        /// <summary>
        /// Image of GameObject
        /// </summary>
        public Image? Sprite { get; set; }      //Sprite - small 2D image, integrated to larger sceene

        public GameObject(Vector2 position, Vector2 size, Image? image)
        {
            Position = position;
            Size = size;
            Sprite = image;

            PlatformsEngine.AddNewObject(this);
        }

        /// <summary>
        /// Removes object from object list and disposes Image if it has one
        /// </summary>
        public void DestroySelf()
        {
            PlatformsEngine.RemoveObject(this);
            Sprite?.Dispose();                       //Can take alot of resources - needs to be Disposed
        }
    }
}
