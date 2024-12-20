

class Shoes
{
    public string Name { get; set; }
    public int Warmth { get; set; }
    public int SpeedReduction { get; set; }
    public double StyleBoostMult { get; set; }
    public Shoes(string name, int warmth, int speedReduction, double styleBoostMult)
    {
        Name = name;
        Warmth = warmth;
        SpeedReduction = speedReduction;
        StyleBoostMult = styleBoostMult;
    }
}