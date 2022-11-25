using System.Numerics;

namespace Platforms.Engine.Objects
{
    internal class PlayerObject : GameObject
    {
        public float Speed { get; set; }

        public PlayerObject(Vector2 position, Vector2 size) : base(position, size)
        {
        }

        public void Stop()
        {
            Speed = 0f;
        }
    }
}
