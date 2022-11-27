using System.Drawing;
using System.Numerics;

namespace Platforms.Engine.Objects
{
    /// <summary>
    /// Default preset for Player Object
    /// </summary>
    internal class PlayerObject : GameObject
    {
        /// <summary>
        /// Speed of Player
        /// </summary>
        public float Speed { get; set; }

        public PlayerObject(Vector2 position, Vector2 size, Image? image) : base(position, size, image)
        {
        }

        public void Stop()
        {
            Speed = 0f;
        }
    }
}
