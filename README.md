# SpaceInvaders - 3D

**SpaceInvaders - 3D** ist ein Weltraumspiel, in dem es das Ziel ist, feindliche Raumschiffe zu eliminieren und das eigene Überleben zu sichern. Die feindlichen Raumschiffe werden pro Level verstärkt und das Terrain wird dynamisch generiert.
![Screenshot SpaceInvaders - 3D](images/titleimage.png)

## Steuerung:
- **W, A, S, D**: Vorwärts, Links, Rückwärts, Rechts
- **Q, E**: Rolle nach Links, Rolle nach Rechts
- **Left-Ctrl**: Hover nach unten
- **Space**: Hover nach oben
- **ESC**: Pausen-Menü, pausiert das Spiel
- **Mausbewegung**: Richtung und Steuerung des Raumschiffs

## Enemy-Verhalten:
- **Alignment**: Feinde passen sich in ihrer Bewegung und Ausrichtung an benachbarte Schiffe an.
- **Separation**: Feinde halten Abstand zueinander, um Kollisionen zu vermeiden.
- **Cohesion**: Feinde werden zu ihrer Gruppe hingezogen.
- **Chase**: Feinde jagen den Spieler gezielt und versuchen ihn zu zerstören.

## Terrain-Generierung:
Das Terrain wird pro Level dynamisch generiert. Der Code basiert auf dem Projekt von [KristinLague](https://github.com/KristinLague/Low-Poly-Terrain-Generator). Es wird pro Level ein neues Terrain erstellt, wodurch jedes Spiel einzigartig ist.

## Audio-Komponenten:
- **Explosionen**: Effekte, wenn Raumschiffe zerstört werden.
- **Ambience Audio**: Grundatmosphäre im Hintergrund.
- **Enemy-Spaceship Audio**: Geräusche von Feinden, wenn sie sich nähern.

## Enemy-Generierung:
- Es gibt pro Level vier Spawner.
- Auf dem Schwierigkeitsgrad **Easy** wird alle 5 Sekunden ein Feind generiert.
- Auf dem Schwierigkeitsgrad **Hard** wird alle 3 Sekunden ein Feind generiert.

## Scenes:
- **HomeUI-Scene**: Hauptmenü zur Auswahl des Levels.
- **Easy-Level**: Terrain mit großen Bergen (Erde).
- **Hard-Level**: Terrain mit flachen Hügeln (Mars) und schnellerer Feind-Generierung.

## UI-Komponenten:
- **HomeUI**: Ermöglicht die Auswahl des Levels.
- **PauseUI**: Ermöglicht das Pausieren des Spiels und die Neugenerierung des Terrains.
- **BoundaryUI-Overlay**: Zeigt eine Warnung an, wenn sich der Spieler der Spielgrenze nähert.
- **ScoreUI-Overlay**: Zeigt den aktuellen und den Highscore an.

## Physiksystem:
- Kollidierungen mit Feinden führen zur Zerstörung des Spieler-Schiffs.
- Kollidierung mit der Grenze verhindert, dass der Spieler aus der Map fliegt.
- Kollidierungen mit dem Terrain können Gegner zerstören.

## Verwendete Assets:
- **Sci-Fi-Sfx**: Soundeffekte.
- **SimpleFX**: Explosionseffekte.
- **Thaleah_PixelFont**: Schriftart für das UI.
- **Treys**: Weitere benötigte Assets.
- **TriangleDotNet**: Bibliothek für die Polygon-Terrain-Generierung, notwendig für die Terrain-Generierung von [KristinLague](https://github.com/KristinLague/Low-Poly-Terrain-Generator).

## Credits:
- **Terrain Generator**: [KristinLague](https://github.com/KristinLague/Low-Poly-Terrain-Generator)
- **Entwickler**: Jan Zimmermann

## Modul:
- **EIUN**: Einführung in Unity [Detailbeschreibung - EIUN](https://www.fhnw.ch/de/studium/module/9558478)

## Lizenz:
- [LICENSE](LICENSE.md)