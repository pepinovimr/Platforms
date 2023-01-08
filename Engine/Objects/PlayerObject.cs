using System.Drawing;
using System.Linq;
using System.Numerics;

namespace Platforms.Engine.Objects
{
    /// <summary>
    /// Default preset for Player Object
    /// </summary>
    internal class PlayerObject : GameObject
    {
        public PlayerObject(Vector2 position, Vector2 size, Image? image) : base(position, size, image)
        {
        }

        /// <summary>
        /// Checks wheter playerObject is in collision with Terrain Object
        /// </summary>
        /// <returns>True if player is coliding, false otherwise</returns>
        public bool IsColiding()
        {
            foreach (var o in PlatformsEngine.AllObjects.Where(x => x.GetType() == typeof(TerrainObject)))
            {
                //AABB colision detection
                if(Position.X < o.Position.X + o.Size.X &&
                    Position.X + Size.X > o.Position.X &&
                    Position.Y < o.Position.Y + o.Size.Y &&
                    Position.Y + Size.Y > o.Position.Y)
                {
                    return true;
                }

            }
            return false;
        }
    }
}
