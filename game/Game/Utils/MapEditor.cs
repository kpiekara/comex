using System.Text.Json;
using System.Text.Json.Serialization;
using Game.Engine.Numeric;

namespace Game.Utils;

public enum TileType
{
    Stone,
    Water
}

public class MapFile
{
    public MapNode[,] Nodes { get; set; }
    public uint X { get; set; }
    public uint Y { get; set; }
}

public class MapNode
{
    [JsonPropertyName("t")]
    public TileType Type { get; set; }

    [JsonIgnore]
    public bool IsStone => Type == TileType.Stone;
    
    [JsonIgnore]
    public bool IsWater => Type == TileType.Water;
}

public class MapEditor
{
    public void Save(string path, MapFile mapFile)
    {
        var mapJson = JsonSerializer.Serialize(AsIntermediate(mapFile));
        File.WriteAllText(path, mapJson);
    }

    public MapFile Load(string path)
    {
        var mapJson = File.ReadAllText(path);
        return AsRegular(JsonSerializer.Deserialize<MapFileIntermediate>(mapJson));
    }

    public MapFile Random(uint x, uint y)
    {
        var mapFile = new MapFile
        {
            X = x,
            Y = y,
            Nodes = new MapNode[x, y]
        };
        
        for (uint i = 0; i < x; i++)
        {
            for (uint j = 0; j < y; j++)
            {
                mapFile.Nodes[i, j] = new MapNode();
                if (Randomization.Bool(0.1f) || i == 0 || j == 0 || i == x - 1 || j == y - 1)
                {
                    mapFile.Nodes[i, j].Type = TileType.Stone;
                }
                else
                {
                    mapFile.Nodes[i, j].Type = TileType.Water;
                }
            }
        }

        return mapFile;
    }
    
    private class MapFileIntermediate
    {
        public List<List<MapNode>> Nodes { get; set; }
        public uint X { get; set; }
        public uint Y { get; set; }
    }
    
    private MapFileIntermediate AsIntermediate(MapFile mapFile)
    {
        var list = new List<List<MapNode>>();
        var rows = mapFile.X;
        var cols = mapFile.Y;
        for (var i = 0; i < rows; i++)
        {
            var rowList = new List<MapNode>();
            for (var j = 0; j < cols; j++)
            {
                rowList.Add(mapFile.Nodes[i, j]);
            }
            list.Add(rowList);
        }
        
        return new MapFileIntermediate
        {
            Nodes = list,
            X = mapFile.X,
            Y = mapFile.Y
        };
    }

    private MapFile AsRegular(MapFileIntermediate? mapFileIntermediate)
    {
        if (mapFileIntermediate is null)
        {
            throw new Exception("Find me!");
        }
        
        var rows = mapFileIntermediate.X;
        var cols = mapFileIntermediate.Y;
        var nodes = new MapNode[rows, cols];
        for (var i = 0; i < rows; i++)
        {
            for (var j = 0; j < cols; j++)
            {
                nodes[i, j] = mapFileIntermediate.Nodes[i][j];
            }
        }
        
        return new MapFile
        {
            Nodes = nodes,
            X = mapFileIntermediate.X,
            Y = mapFileIntermediate.Y
        };
    }
}