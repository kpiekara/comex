using SFML.Graphics;
using SFML.System;

namespace Game.Engine.Components;

public class TileMap : Transformable, Drawable 
{
    private Texture _texture { get; set; }
    private readonly VertexArray _vertexArray = new ();
    
    public TileMap(Texture texture, Vector2u tileSize, Vector2u mapSize, List<uint> tiles)
    {
        _texture = texture;
        _vertexArray.PrimitiveType = PrimitiveType.Triangles;
        _vertexArray.Resize(mapSize.X * mapSize.Y * 6);

        for (uint i = 0; i < mapSize.X; i++)
        {
            for (uint j = 0; j < mapSize.Y; j++)
            {
                var tileId = tiles[(int)(i + j * mapSize.X)];

                var tu = tileId % (_texture.Size.X / tileSize.X);
                var tv = tileId / (_texture.Size.Y / tileSize.Y);

                var baseIndex = (i + j * mapSize.X) * 6;

                _vertexArray[baseIndex + 0] = new Vertex
                {
                    Position = new Vector2f((i + 0) * tileSize.X, (j + 0) * tileSize.Y),
                    TexCoords = new Vector2f((tu + 0) * tileSize.X, (tv + 0) * tileSize.Y),
                    Color = Color.White
                };

                _vertexArray[baseIndex + 1] = new Vertex
                {
                    Position = new Vector2f((i + 1) * tileSize.X, (j + 0) * tileSize.Y),
                    TexCoords = new Vector2f((tu + 1) * tileSize.X, (tv + 0) * tileSize.Y),
                    Color = Color.White
                };

                _vertexArray[baseIndex + 2] = new Vertex
                {
                    Position = new Vector2f((i + 1) * tileSize.X, (j + 1) * tileSize.Y),
                    TexCoords = new Vector2f((tu + 1) * tileSize.X, (tv + 1) * tileSize.Y),
                    Color = Color.White
                };
                
                _vertexArray[baseIndex + 3] = new Vertex
                {
                    Position = new Vector2f((i + 0) * tileSize.X, (j + 0) * tileSize.Y),
                    TexCoords = new Vector2f((tu + 0) * tileSize.X, (tv + 0) * tileSize.Y),
                    Color = Color.White
                };
                
                _vertexArray[baseIndex + 4] = new Vertex
                {
                    Position = new Vector2f((i + 1) * tileSize.X, (j + 1) * tileSize.Y),
                    TexCoords = new Vector2f((tu + 1) * tileSize.X, (tv + 1) * tileSize.Y),
                    Color = Color.White
                };
                
                _vertexArray[baseIndex + 5] = new Vertex
                {
                    Position = new Vector2f((i + 0) * tileSize.X, (j + 1) * tileSize.Y),
                    TexCoords = new Vector2f((tu + 0) * tileSize.X, (tv + 1) * tileSize.Y),
                    Color = Color.White
                };
            }
        }
    }
    
    public void Draw(RenderTarget target, RenderStates states)
    {
        states.Transform *= Transform;
        states.Texture = _texture;
        target.Draw(_vertexArray, states);
    }
}