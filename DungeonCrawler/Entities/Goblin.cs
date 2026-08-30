using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using DungeonCrawler.Core;

namespace DungeonCrawler.Entities
{
    public class Goblin : GameEntity
    {
        private const float MovementSpeed = 100f;
        private Vector2 _targetPosition;
        private readonly Random _random = new();
        private int _health;
        private readonly int _maxHealth;

        public int Health => _health;
        public int MaxHealth => _maxHealth;

        public Goblin(Vector2 position, int health = 30)
        {
            Position = position;
            _health = health;
            _maxHealth = health;
            IsActive = true;
            
            // Pick a random nearby position as initial target
            _targetPosition = new Vector2(
                _random.Next((int)Position.X - 100, (int)Position.X + 100),
                _random.Next((int)Position.Y - 100, (int)Position.Y + 100));
        }

        public override void Update(GameTime gameTime)
        {
            if (!IsActive) return;

            // AI: Move towards target position
            Vector2 direction = (_targetPosition - Position).Length() > 0 
                ? (_targetPosition - Position).Normalized() 
                : Vector2.Zero;

            _velocity = direction * MovementSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;

            // Update position
            Position += _velocity;

            // Pick new target if close to current one
            float distanceToTarget = Vector2.Distance(Position, _targetPosition);
            if (distanceToTarget < 50f)
            {
                _targetPosition = new Vector2(
                    _random.Next((int)Position.X - 100, (int)Position.X + 100),
                    _random.Next((int)Position.Y - 100, (int)Position.Y + 100));
            }

            // Check if dead
            if (_health <= 0)
            {
                IsActive = false;
            }
        }

        public void TakeDamage(int damage)
        {
            _health -= damage;
        }

        public override void Initialize()
        {
            base.Initialize();
        }

        public override void Draw(SpriteBatch spriteBatch, Texture2D texture, Vector2 origin)
        {
            // Base draw implementation
            base.Draw(spriteBatch, texture, origin);
        }
    }
}
