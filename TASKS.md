
```json
{
  "tasks": [
    {
      "id": "1",
      "description": "Read requirements.md",
      "status": "done"
    },
    {
      "id": "2",
      "description": "Create TASKS.md",
      "status": "done"
    },
    {
      "id": "3",
      "description": "Break implementation into phases",
      "status": "done"
    },
    {
      "id": "4",
      "description": "Include dependencies between tasks",
      "status": "in_progress"
    },
    {
      "id": "5",
      "description": "Set up Visual Studio solution",
      "status": "todo",
      "dependencies": ["3"]
    },
    {
      "id": "6",
      "description": "Create project structure",
      "status": "todo",
      "dependencies": ["3"]
    },
    {
      "id": "7",
      "description": "Implement player movement",
      "status": "todo",
      "dependencies": ["5", "6"]
    },
    {
      "id": "8",
      "description": "Implement combat system",
      "status": "todo",
      "dependencies": ["7"]
    },
    {
      "id": "9",
      "description": "Implement dungeon generation",
      "status": "todo",
      "dependencies": ["6"]
    },
    {
      "id": "10",
      "description": "Implement loot system",
      "status": "todo",
      "dependencies": ["9"]
    },
    {
      "id": "11",
      "description": "Implement UI elements",
      "status": "todo",
      "dependencies": ["6"]
    },
    {
      "id": "12",
      "description": "Implement save/load system",
      "status": "todo",
      "dependencies": ["6"]
    },
    {
      "id": "13",
      "description": "Add README.md",
      "status": "todo",
      "dependencies": ["6"]
    },
    {
      "id": "14",
      "description": "Add XML comments",
      "status": "todo",
      "dependencies": ["6"]
    },
    {
      "id": "15",
      "description": "Final testing and verification",
      "status": "todo",
      "dependencies": ["7", "8", "9", "10", "11", "12", "13", "14"]
    }
  ]
}
```
