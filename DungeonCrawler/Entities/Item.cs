using Microsoft.Xna.Framework;

namespace DungeonCrawler.Entities
{
    public enum ItemType
    {
        HealthPotion,
        ManaPotion,
        Gold,
        Weapon,
        Armor
    }

    public class Item
    {
        public ItemType Type { get; private set; }
        public Vector2 Position { get; set; }
        public bool IsActive { get; set; } = true;
        public int Value { get; set; }

        public Item(ItemType type, Vector2 position)
        {
            Type = type;
            Position = position;
            IsActive = true;
            Value = type switch
            {
                ItemType.HealthPotion => 10,
                ItemType.ManaPotion => 5,
                ItemType.Gold => 1,
                ItemType.Weapon => 20,
                ItemType.Armor => 15,
                _ => 0
            };
        }

        public void Pickup()
        {
            IsActive = false;
        }
    }
}
