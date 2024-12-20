class Player
{
    public string Name { get; set; }
    public double Distance { get; set; }
    public double Speed { get; set; }
    public double MaxSpeed { get; set; }
    public double MaxSpeedCopy { get; set; }
    public double Acceleration { get; set; }
    public double Braking { get; set; }
    public double Warmth { get; set; }
    public double Defence { get; set; }
    public double Strength { get; set; }
    public double Style { get; set; }
    public int Tile { get; set; }
    public bool HasCollided { get; set; }
    public Pusher? PlayerPusher { get; set; }
    public Shoes? PlayerShoes { get; set; }
    public Clothing? PlayerClothing { get; set; }
    public Vehicle? PlayerVehicle { get; set; }
    public Map? SelectMap { get; set; }
    public Player()
    {
        Tile = 0;
        Distance = 0;
        Speed = 0;
        MaxSpeed = 0;
        Acceleration = 0;
        Braking = 0;
        Warmth = 0;
        Style = 0;
        HasCollided = false;
    }
}