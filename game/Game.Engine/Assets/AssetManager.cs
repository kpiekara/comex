using Game.Engine.Components;
using SFML.Graphics;
using SFML.System;

namespace Game.Engine.Assets;

public interface IAssetManager
{
    void AddTileSet(string path, string resourceKey, Vector2u tileSize);
    Tile CreateTile(string resourceKey, uint tileId);
    Texture GetTexture(string resourceKey);
    void AddFont(string path, string resourceKey);
    Font GetFont(string basic);
}

public class AssetManager : IAssetManager
{
    private readonly Dictionary<string, Texture> _textures = new();
    private readonly Dictionary<string, Vector2u> _tileSizes = new();
    private readonly Dictionary<string, Font> _fonts = new();
    
    public void AddTileSet(string path, string resourceKey, Vector2u tileSize)
    {
        _textures[resourceKey] = new Texture(path);
        _textures[resourceKey].Smooth = false;
        _tileSizes[resourceKey] = new Vector2u(tileSize.X, tileSize.Y);
    }

    public Texture GetTexture(string resourceKey)
    {
        return _textures[resourceKey];
    }

    public void AddFont(string path, string resourceKey)
    {
        _fonts.Add(resourceKey, new Font(path));
    }

    public Font GetFont(string resourceKey)
    {
        return _fonts[resourceKey];
    }

    public Tile CreateTile(string resourceKey, uint tileId)
    {
        var tileSize = _tileSizes[resourceKey];
        var texture = _textures[resourceKey];
        var tilesInRow = texture.Size.X / tileSize.X;

        var startX = (tileId % tilesInRow)*tileSize.X;
        var startY = (tileId / tilesInRow)*tileSize.Y;
        
        var sprite = new Sprite
        {
            Texture = texture,
            TextureRect = new IntRect
            {
                Top = (int)startY,
                Left = (int)startX,
                Height = (int)tileSize.Y,
                Width = (int)tileSize.X
            }
        };

        return new Tile(sprite);
    }
}