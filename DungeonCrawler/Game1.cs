using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using DungeonCrawler.Core;
using DungeonCrawler.Entities;
using DungeonCrawler.Systems;

namespace DungeonCrawler
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        
        // Game entities
        private Player _player;
        private List<Goblin> _enemies = new();
        private List<Item> _lootDrops = new();
        
        // Systems
        private DungeonGenerator _dungeonGenerator;
        private CombatSystem _combatSystem;
        
        // UI elements
        private int _healthBarWidth = 200;
        private int _healthBarHeight = 20;
        private Texture2D _healthBarTexture;
        
        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            base.Initialize();
            
            // Initialize player
            _player = new Player();
            _player.Position = new Vector2(100, 100);
            _player.Initialize();
            
            // Generate dungeon
            _dungeonGenerator = new DungeonGenerator(800, 600, 4, 10, 5);
            var rooms = _dungeonGenerator.Generate();
            
            // Spawn enemies in rooms
            foreach (var room in rooms)
            {
                if (_enemies.Count < 3) // Limit number of enemies for MVP
                {
                    var goblin = new Goblin(room.Position + Vector2.One * 50);
                    _enemies.Add(goblin);
                }
            }
            
            // Initialize combat system
            _combatSystem = new CombatSystem(GameTime, GraphicsDevice.Viewport.Bounds);
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            _healthBarTexture = new Texture2D(GraphicsDevice, 1, 1);
            _healthBarTexture.SetData(new[] { Color.White });
        }

        protected override void Update(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            
            // Update player
            _player.Update(gameTime);
            
            // Update enemies
            foreach (var enemy in _enemies)
            {
                if (enemy.IsActive)
                    enemy.Update(gameTime);
            }
            
            // Process combat
            _combatSystem.ProcessMeleeCombat(_player, _enemies);
            
            // Check for loot drops from dead enemies
            foreach (var enemy in _enemies)
            {
                if (!enemy.IsActive && !_lootDrops.Any(l => l.Position == enemy.Position))
                {
                    var loot = new Item(ItemType.HealthPotion, enemy.Position);
                    _lootDrops.Add(loot);
                }
            }
            
            // Check for item pickup
            foreach (var loot in _lootDrops)
            {
                if (Vector2.Distance(_player.Position, loot.Position) < 30 && loot.IsActive)
                {
                    loot.Pickup();
                    // Apply effect to player (simplified)
                    if (loot.Type == ItemType.HealthPotion)
                    {
                        _player.Health += loot.Value;
                    }
                }
            }
            
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            
            _spriteBatch.Begin();
            
            // Draw dungeon rooms (simplified as rectangles)
            var rooms = _dungeonGenerator.GetRooms();
            foreach (var room in rooms)
            {
                _spriteBatch.Draw(_healthBarTexture, room.Bounds, Color.Gray);
            }
            
            // Draw player
            _player.Draw(_spriteBatch, _healthBarTexture, Vector2.Zero);
            
            // Draw enemies
            foreach (var enemy in _enemies)
            {
                if (enemy.IsActive)
                    enemy.Draw(_spriteBatch, _healthBarTexture, Vector2.Zero);
            }
            
            // Draw loot drops
            foreach (var loot in _lootDrops)
            {
                if (loot.IsActive)
                    loot.Draw(_spriteBatch, _healthBarTexture, Vector2.Zero);
            }
            
            // Draw health bar
            DrawHealthBar(_spriteBatch);
            
            _spriteBatch.End();
            
            base.Draw(gameTime);
        }
        
        private void DrawHealthBar(SpriteBatch spriteBatch)
        {
            var healthPercent = (float)_player.Health / _player.MaxHealth;
            var rect = new Rectangle(10, 10, _healthBarWidth, _healthBarHeight);
            
            // Background
            spriteBatch.Draw(_healthBarTexture, rect, Color.DimGray);
            
            // Health bar fill
            var fillRect = new Rectangle(rect.X, rect.Y, (int)(rect.Width * healthPercent), rect.Height);
            spriteBatch.Draw(_healthBarTexture, fillRect, Color.Green);
        }
    }
}
