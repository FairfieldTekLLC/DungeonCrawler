
```json
{
  "phases": {
    "MVP": {
      "description": "Minimum playable game - core gameplay loop with movement, combat, basic dungeon, and loot",
      "tasks": [
        {
          "id": "1",
          "description": "Set up Visual Studio solution with .NET 10 and MonoGame",
          "status": "todo"
        },
        {
          "id": "2",
          "description": "Create project structure with separate namespaces (Core, Systems, Entities, UI)",
          "status": "todo",
          "dependencies": ["1"]
        },
        {
          "id": "3",
          "description": "Implement player movement system with WASD controls",
          "status": "todo",
          "dependencies": ["2"]
        },
        {
          "id": "4",
          "description": "Create basic dungeon generation algorithm (single floor)",
          "status": "todo",
          "dependencies": ["2"]
        },
        {
          "id": "5",
          "description": "Implement basic combat system with melee attacks",
          "status": "todo",
          "dependencies": ["3"]
        },
        {
          "id": "6",
          "description": "Create Goblin enemy entity with basic AI",
          "status": "todo",
          "dependencies": ["5"]
        },
        {
          "id": "7",
          "description": "Implement loot drop system (basic items)",
          "status": "todo",
          "dependencies": ["6"]
        },
        {
          "id": "8",
          "description": "Create main menu screen",
          "status": "todo",
          "dependencies": ["2"]
        },
        {
          "id": "9",
          "description": "Implement basic health bar UI",
          "status": "todo",
          "dependencies": ["3"]
        },
        {
          "id": "10",
          "description": "Test MVP: player can explore dungeon, fight goblins, collect loot",
          "status": "todo",
          "dependencies": ["4", "7", "8", "9"]
        }
      ]
    },
    "Beta": {
      "description": "Feature complete - all major systems implemented with leveling, inventory, save/load, and multiple enemy types",
      "tasks": [
        {
          "id": "11",
          "description": "Implement player leveling system (XP, level-up mechanics)",
          "status": "todo"
        },
        {
          "id": "12",
          "description": "Create inventory system with item slots",
          "status": "todo",
          "dependencies": ["11"]
        },
        {
          "id": "13",
          "description": "Implement mana system and magic attacks",
          "status": "todo",
          "dependencies": ["11"]
        },
        {
          "id": "14",
          "description": "Add damage calculation with critical hits",
          "status": "todo",
          "dependencies": ["5"]
        },
        {
          "id": "15",
          "description": "Create Skeleton enemy entity",
          "status": "todo",
          "dependencies": ["6"]
        },
        {
          "id": "16",
          "description": "Create Orc enemy entity",
          "status": "todo",
          "dependencies": ["15"]
        },
        {
          "id": "17",
          "description": "Implement multi-floor dungeon generation",
          "status": "todo",
          "dependencies": ["4"]
        },
        {
          "id": "18",
          "description": "Create corridor system connecting rooms",
          "status": "todo",
          "dependencies": ["17"]
        },
        {
          "id": "19",
          "description": "Implement save/load system with multiple save slots",
          "status": "todo"
        },
        {
          "id": "20",
          "description": "Create inventory screen UI",
          "status": "todo",
          "dependencies": ["12"]
        },
        {
          "id": "21",
          "description": "Implement character stats display UI",
          "status": "todo",
          "dependencies": ["11"]
        },
        {
          "id": "22",
          "description": "Add health and mana bar UI elements",
          "status": "todo",
          "dependencies": ["3", "13"]
        },
        {
          "id": "23",
          "description": "Implement minimap display",
          "status": "todo"
        },
        {
          "id": "24",
          "description": "Test Beta: full dungeon exploration, combat with multiple enemy types, leveling, inventory management, save/load",
          "status": "todo",
          "dependencies": ["17", "19", "20", "21", "22", "23"]
        }
      ]
    },
    "Release 1.0": {
      "description": "Polish and production-ready - fog of war, boss monsters, weapon/armor loot, documentation, and final polish",
      "tasks": [
        {
          "id": "25",
          "description": "Implement fog of war system (visibility radius)",
          "status": "todo"
        },
        {
          "id": "26",
          "description": "Create Boss monster entity with unique abilities",
          "status": "todo",
          "dependencies": ["16"]
        },
        {
          "id": "27",
          "description": "Implement weapon loot system (swords, axes, etc.)",
          "status": "todo",
          "dependencies": ["7"]
        },
        {
          "id": "28",
          "description": "Implement armor loot system (helmets, chestplates, etc.)",
          "status": "todo",
          "dependencies": ["7"]
        },
        {
          "id": "29",
          "description": "Add potion loot system (health potions, mana potions)",
          "status": "todo",
          "dependencies": ["7"]
        },
        {
          "id": "30",
          "description": "Integrate real monster images from asset library",
          "status": "todo"
        },
        {
          "id": "31",
          "description": "Add XML comments to all public methods and classes",
          "status": "todo"
        },
        {
          "id": "32",
          "description": "Create comprehensive README.md with setup instructions",
          "status": "todo"
        },
        {
          "id": "33",
          "description": "Perform final testing on all systems",
          "status": "todo",
          "dependencies": ["25", "26", "27", "28", "29", "30"]
        },
        {
          "id": "34",
          "description": "Verify solution builds without errors",
          "status": "todo"
        },
        {
          "id": "35",
          "description": "Final release validation: complete gameplay loop, fog of war, boss fights, loot drops, save/load, documentation",
          "status": "todo",
          "dependencies": ["25", "26", "27", "28", "29", "31", "32", "33"]
        }
      ]
    }
  }
}
```
