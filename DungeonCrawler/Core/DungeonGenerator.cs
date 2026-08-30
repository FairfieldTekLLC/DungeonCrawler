using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace DungeonCrawler.Core
{
    public class Room
    {
        public Vector2 Position { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public Rectangle Bounds => new Rectangle((int)Position.X, (int)Position.Y, Width, Height);

        public Room(Vector2 position, int width, int height)
        {
            Position = position;
            Width = width;
            Height = height;
        }
    }

    public class DungeonGenerator
    {
        private readonly Random _random = new();
        private readonly List<Room> _rooms = new();
        private readonly int _maxRooms;
        private readonly int _minRoomSize;
        private readonly int _maxRoomSize;
        private readonly int _screenWidth;
        private readonly int _screenHeight;

        public DungeonGenerator(int maxRooms, int minRoomSize, int maxRoomSize, int screenWidth, int screenHeight)
        {
            _maxRooms = maxRooms;
            _minRoomSize = minRoomSize;
            _maxRoomSize = maxRoomSize;
            _screenWidth = screenWidth;
            _screenHeight = screenHeight;
        }

        public List<Room> Generate()
        {
            _rooms.Clear();
            for (int i = 0; i < _maxRooms; i++)
            {
                int width = _random.Next(_minRoomSize, _maxRoomSize);
                int height = _random.Next(_minRoomSize, _maxRoomSize);
                float x = _random.Next(0, _screenWidth - width);
                float y = _random.Next(0, _screenHeight - height);
                var room = new Room(new Vector2(x, y), width, height);
                _rooms.Add(room);
            }
            return _rooms;
        }

        public List<Room> GetRooms() => _rooms;
    }
}
