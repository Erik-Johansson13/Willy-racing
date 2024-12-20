

class Map
{
    public string MapName { get; set; }
    public int TilesAmount { get; set; }
    public int[] TilesDirection { get; set; }
    public char[] TilesWarmth { get; set; }
    public int[] TileLengths { get; set; }
    public List<Player>[] Placements { get; set; }
    public int TotalLength { get; set; }
    
    public Map(string mapName, int[] tiles, char[] tilesWarmth, int[] tileLengths)
    {
        MapName = mapName;
        TilesDirection = tiles;
        TilesWarmth = tilesWarmth;
        TileLengths = tileLengths;
        TilesAmount = TileLengths.Length;
        TotalLength = 0;
        Placements = new List<Player>[TilesAmount];
        for (int i = 0; i < TilesAmount; i++) 
        {
            TotalLength += TileLengths[i];
            Placements[i] = new();
        }
    }
}