using SFML.System;

namespace Game.Resources;

public struct TileSetDefinition
{
    public required string Name { get; set; }
    public required Vector2u TileSize { get; set; }
}

public static class TileSets
{
    public static readonly TileSetDefinition BaseTileSet = new TileSetDefinition() {Name = "basic_tileset", TileSize = new Vector2u(64, 64)};
}