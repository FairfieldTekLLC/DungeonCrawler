using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using DungeonCrawler.Core;

namespace DungeonCrawler.Entities
{
    public class Player : GameEntity
    {
        private const float MovementSpeed = 200f;
        private Vector2 _velocity;
        private KeyboardState _previousState;

        public int Health { get; set; }
        public int MaxHealth { get; set; }
        public bool IsAttacking { get; set; }

        public override void Initialize()
        {
            base.Initialize();
            _previousState = Keyboard.GetState();
            Health = 100;
            MaxHealth = 100;
        }

        public override void Update(GameTime gameTime)
        {
            var keyboardState = Keyboard.GetState();

            if (keyboardState.IsKeyDown(Keys.W) || keyboardState.IsKeyDown(Keys.Up))
                _velocity.Y -= MovementSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;
            else if (keyboardState.IsKeyDown(Keys.S) || keyboardState.IsKeyDown(Keys.Down))
                _velocity.Y += MovementSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (keyboardState.IsKeyDown(Keys.A) || keyboardState.IsKeyDown(Keys.Left))
                _velocity.X -= MovementSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;
            else if (keyboardState.IsKeyDown(Keys.D) || keyboardState.IsKeyDown(Keys.Right))
                _velocity.X += MovementSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;

            var magnitude = _velocity.Length();
            if (magnitude > MovementSpeed)
            {
                _velocity.Normalize() *= MovementSpeed;
            }

            Position += _velocity * (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (_previousState.IsKeyUp(Keys.W) && keyboardState.IsKeyDown(Keys.W))
                _velocity.Y = 0;
            if (_previousState.IsKeyUp(Keys.S) && keyboardState.IsKeyDown(Keys.S))
                _velocity.Y = 0;
            if (_previousState.IsKeyUp(Keys.A) && keyboardState.IsKeyDown(Keys.A))
                _velocity.X = 0;
            if (_previousState.IsKeyUp(Keys.D) && keyboardState.IsKeyDown(Keys.D))
                _velocity.X = 0;

            IsAttacking = keyboardState.IsKeyDown(Keys.Space);

            _previousState = keyboardState;
        }

        public override void Draw(SpriteBatch spriteBatch, Texture2D texture, Vector2 origin)
        {
            base.Draw(spriteBatch, texture, origin);
        }

        public void TakeDamage(int amount)
        {
            Health -= amount;
            if (Health <= 0) Health = 0;
        }
    }
}
