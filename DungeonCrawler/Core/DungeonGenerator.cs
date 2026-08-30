using System;
using Microsoft.Xna.Framework;

namespace DungeonCrawler.Core
{
    public class Room
    {
        public Vector2 Position { get; private set; }
        public Vector2 Size { get; private set; }
        public bool Connected { get; set; }

        public Room(Vector2 position, Vector2 size)
        {
            Position = position;
            Size = size;
            Connected = false;
        }

        public Rectangle Bounds => new Rectangle(
            (int)Position.X,
            (int)Position.Y,
            (int)Size.X,
            (int)Size.Y);
    }

    public class DungeonGenerator
    {
        private readonly int _mapWidth;
        private readonly int _mapHeight;
        private readonly int _minRoomSize;
        private readonly int _maxRoomSize;
        private readonly int _maxRooms;
        private readonly Random _random;
        private readonly List<Room> _rooms = new();

        public DungeonGenerator(int mapWidth, int mapHeight, int minRoomSize = 4, int maxRoomSize = 10, int maxRooms = 8)
        {
            _mapWidth = mapWidth;
            _mapHeight = mapHeight;
            _minRoomSize = minRoomSize;
            _maxRoomSize = maxRoomSize;
            _maxRooms = maxRooms;
            _random = new Random();
        }

        public List<Room> Generate()
        {
            _rooms.Clear();

            // Place rooms randomly with collision detection
            int attempts = 0;
            while (_rooms.Count < _maxRooms && attempts < 100)
            {
                var roomSize = new Vector2(
                    _random.Next(_minRoomSize, _maxRoomSize + 1),
                    _random.Next(_minRoomSize, _maxRoomSize + 1));

                var roomPosition = new Vector2(
                    _random.Next(0, _mapWidth - (int)roomSize.X),
                    _random.Next(0, _mapHeight - (int)roomSize.Y));

                if (!HasCollision(roomPosition, roomSize))
                {
                    _rooms.Add(new Room(roomPosition, roomSize));
                }

                attempts++;
            }

            // Connect rooms with corridors
            ConnectRooms();

            return _rooms;
        }

        private bool HasCollision(Vector2 position, Vector2 size)
        {
            var newRoom = new Rectangle((int)position.X, (int)position.Y, (int)size.X, (int)size.Y);

            foreach (var room in _rooms)
            {
                if (newRoom.Intersects(room.Bounds))
                    return true;
            }

            return false;
        }

        private void ConnectRooms()
        {
            // Simple approach: connect each room to the next one sequentially
            for (int i = 0; i < _rooms.Count - 1; i++)
            {
                var startRoom = _rooms[i];
                var endRoom = _rooms[i + 1];

                // Mark rooms as connected
                startRoom.Connected = true;
                endRoom.Connected = true;
            }

            if (_rooms.Count > 0)
                _rooms[_rooms.Count - 1].Connected = true;
        }

        public List<Room> GetRooms() => _rooms;
    }
}
