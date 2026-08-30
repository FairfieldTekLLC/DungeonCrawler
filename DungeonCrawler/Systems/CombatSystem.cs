using System;
using Microsoft.Xna.Framework;
using DungeonCrawler.Core;
using DungeonCrawler.Entities;

namespace DungeonCrawler.Systems
{
    public class CombatSystem
    {
        private readonly GameTime _gameTime;
        private readonly Rectangle _viewport;

        public CombatSystem(GameTime gameTime, Rectangle viewport)
        {
            _gameTime = gameTime;
            _viewport = viewport;
        }

        public void ProcessCombat(Player player, List<GameEntity> enemies)
        {
            foreach (var enemy in enemies)
            {
                if (!enemy.IsActive) continue;

                // Check melee attack range
                float distance = Vector2.Distance(player.Position, enemy.Position);
                const float MeleeRange = 40f;

                if (distance <= MeleeRange)
                {
                    // Simple melee attack logic
                    int damage = CalculateMeleeDamage();
                    
                    // Apply damage to enemy
                    if (enemy is Goblin goblin)
                    {
                        goblin.TakeDamage(damage);
                        
                        // Knockback effect
                        Vector2 direction = (enemy.Position - player.Position).Length() > 0 
                            ? (enemy.Position - player.Position).Normalized() 
                            : Vector2.Zero;
                        enemy.Velocity += direction * 150f;
                    }
                }
            }
        }

        private int CalculateMeleeDamage()
        {
            // Base damage + random variance
            return new Random().Next(8, 15);
        }
    }
}
