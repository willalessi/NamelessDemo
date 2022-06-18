# NamelessDemo

### Demonstration of roguelike game dev project
---

## Demo is divided into 4 parts

### 1. Boss Level Build

- Sample playthrough of current state of boss level
- Boss level can be sectioned into two stages
  1. 100%-50% HP: Two normal attacks
  2. < 50% HP: Minions will spawn and two nowmal attacks

### 2. Demo Build (Test this first)

- Showcases different implemented features, E.g.:
1. UI
2. Enemies
3. Player movement/attacks
4. Consumables
5. Health

- Also lists specific inputs/diretions

### 3. Main Game

- Playthrough of the current state of the game
- Starts in a hub area where the player can deposit currency and upgrade stats/consumables
- Currency is earned through killing enemies in a run through of the game
- Currency can be spent once it is deposited in the well in the middle of the area
- Player can interact with two NPC's by pressing 'e' near either of them
- One NPC upgrades consumables while the other upgrades stats
- The player can enter the first level of the game by colliding with the sign in the far right of the scene
- The first level implements basic level gen properties
- Random map pieces, consumables, and enemies are spawned throughout the first level
- Note: The current state of level gen is not the final, this is the portion of the game that will recieve the highest priority in the future
- At the end of the first level, the player will encounter a collision that loads them into the boss level

### 4. Scripts

- Few sample of scripts implemented in the game
- Player Movement
- Enemy Movement
- Consumables
