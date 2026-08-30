using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using DungeonCrawler.Core;

namespace DungeonCrawler.Entities
{
    public class Goblin : GameEntity
    {
        private const float MovementSpeed = 100f;
        private Vector2 _velocity;

        public int Health { get; set; }
        public int MaxHealth { get; set; }
        public bool IsActive => Health > 0;
        public bool IsAttacking { get; set; }

        public override void Initialize()
        {
            base.Initialize();
            Health = 50;
            MaxHealth = 50;
        }

        public override void Update(GameTime gameTime)
        {
            var distanceToPlayer = Vector2.Distance(Position, new Vector2(100, 100));

            if (distanceToPlayer > 50)
            {
                var direction = Vector2.Normalize(new Vector2(100 - Position.X, 100 - Position.Y));
                _velocity = direction * MovementSpeed;
            }

            Position += _velocity * (float)gameTime.ElapsedGameTime.TotalSeconds;
        }

        public override void Draw(SpriteBatch spriteBatch, Texture2D texture, Vector2 origin)
        {
            base.Draw(spriteBatch, texture, origin);
        }

        public void TakeDamage(int amount)
        {
            Health -= amount;
            if (Health <= 0) IsActive = false;
        }
    }
}
