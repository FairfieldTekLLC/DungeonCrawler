using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace DungeonCrawler.Core
{
    public abstract class GameEntity
    {
        public Vector2 Position { get; protected set; }
        public Vector2 Velocity { get; protected set; }
        public bool IsActive { get; protected set; } = true;

        public virtual void Initialize() { }
        public virtual void Update(GameTime gameTime) { }
        public virtual void Draw(SpriteBatch spriteBatch, Texture2D texture, Vector2 origin) { }
    }
}
