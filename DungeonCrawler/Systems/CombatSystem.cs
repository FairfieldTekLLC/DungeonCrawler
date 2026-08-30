using System.Collections.Generic;
using Microsoft.Xna.Framework;
using DungeonCrawler.Entities;

namespace DungeonCrawler.Systems
{
    public class CombatSystem
    {
        public void ProcessMeleeCombat(Player player, List<Goblin> enemies)
        {
            // Player attacks enemies
            foreach (var enemy in enemies)
            {
                if (!enemy.IsActive) continue;
                
                float distance = Vector2.Distance(player.Position, enemy.Position);
                if (distance < 50 && player.IsAttacking)
                {
                    enemy.TakeDamage(10);
                }
            }

            // Enemies attack player
            foreach (var enemy in enemies)
            {
                if (!enemy.IsActive) continue;
                
                float distance = Vector2.Distance(player.Position, enemy.Position);
                if (distance < 40 && enemy.IsAttacking)
                {
                    player.TakeDamage(5);
                }
            }
        }
    }
}
