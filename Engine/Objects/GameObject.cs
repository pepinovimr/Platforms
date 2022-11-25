using System.Numerics;

namespace Platforms.Engine.Objects
{
    internal class GameObject
    {
        public Vector2 Position;
        public Vector2 Size;

        public GameObject(Vector2 position, Vector2 size)
        {
            Position = position;
            Size = size;

            PlatformsEngine.AddNewObject(this);
        }

        public void DestroySelf()
        {
            PlatformsEngine.RemoveObject(this);
        }
    }
}
