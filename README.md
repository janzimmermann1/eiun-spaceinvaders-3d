# SpaceInvaders - 3D

**SpaceInvaders - 3D** is a space game where the goal is to eliminate enemy spaceships and ensure your own survival. Enemy spaceships become stronger with each level, and the terrain is dynamically generated.
![Screenshot SpaceInvaders - 3D](https://github.com/janzimmermann1/eiun_spaceinvaders/blob/main/images/titleimage.png)

> Play now [SpaceInvaders - 3D](https://brjaenu.itch.io/spaceinvaders-3d-web) on itch.io

## Controls:
- **W, A, S, D**: Move Forward, Left, Backward, Right
- **Q, E**: Roll Left, Roll Right
- **Left-Ctrl**: Hover Down
- **Space**: Hover Up
- **ESC**: Pause Menu, pauses the game
- **Mouse Movement**: Control the spaceship's direction

## Enemy Behavior:
- **Alignment**: Enemies align their movement and orientation with nearby ships.
- **Separation**: Enemies keep their distance from each other to avoid collisions.
- **Cohesion**: Enemies are drawn toward their group.
- **Chase**: Enemies actively hunt the player and try to destroy them.

## Terrain Generation:
The terrain is dynamically generated per level. The code is based on the project by [KristinLague](https://github.com/KristinLague/Low-Poly-Terrain-Generator). A new terrain is created for each level, making each game unique.

## Audio Components:
- **Explosions**: Effects when spaceships are destroyed.
- **Ambience Audio**: Background atmosphere sounds.
- **Enemy Spaceship Audio**: Sounds when enemies are approaching.

## Enemy Generation:
- There are four spawners per level.
- On **Easy** difficulty, one enemy is generated every 5 seconds.
- On **Hard** difficulty, one enemy is generated every 3 seconds.

## Scenes:
- **HomeUI Scene**: Main menu for selecting levels.
- **Easy Level**: Terrain with large mountains (Earth).
- **Hard Level**: Terrain with flat hills (Mars) and faster enemy generation.

## UI Components:
- **HomeUI**: Allows the player to select levels.
- **PauseUI**: Allows the player to pause the game and regenerate the terrain.
- **BoundaryUI Overlay**: Displays a warning when the player approaches the game boundary.
- **ScoreUI Overlay**: Displays the current score and high score.

## Physics System:
- Collisions with enemies will destroy the player's ship.
- Collisions with the boundary prevent the player from flying out of the map.
- Collisions with terrain can destroy enemies.

## Used Assets:
- **[Sci-Fi SFX](https://assetstore.unity.com/packages/audio/sound-fx/sci-fi-sfx-32830)**: Sound effects.
- **[SimpleFX](https://assetstore.unity.com/packages/vfx/particles/simple-fx-cartoon-particles-67834)**: Explosion effects.
- **[Thaleah_PixelFont](https://assetstore.unity.com/packages/2d/fonts/free-pixel-font-thaleah-140059)**: Font for the UI.
- **[Treys](https://assetstore.unity.com/packages/3d/vehicles/space/low-poly-spaceships-set-209758)**: Spaceships.
- **[TriangleDotNet](https://github.com/garykac/triangle.net)**: This project is using Triangle.Net for Triangulation, required for terrain generation by [KristinLague](https://github.com/KristinLague/Low-Poly-Terrain-Generator).

## Credits:
- **Terrain Generator**: [KristinLague](https://github.com/KristinLague/Low-Poly-Terrain-Generator)
- **Developer**: Jan Zimmermann

## Module:
- **EIUN**: Introduction to Unity - [Module Details - EIUN](https://www.fhnw.ch/de/studium/module/9558478)

## License:
- [LICENSE](LICENSE.md)
