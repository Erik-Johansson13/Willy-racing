

/*
Ideas and background:
Willy's shopping cart apalooza
Race through different stores in shopping carts.
The user gets to pimp their companion(=engine) to acclimate them to the track.
Certain changes can cause increases and decreases in speed depending on enviornment(eg. Frozen aisles cause decreases in speed).
 */

using System.Linq.Expressions;

class Program
{
    // Creation of clothing
    static List<Clothing> clothing = [
        new("Butt-ass naked", 0, 0, 0, 1), 
        new("Cucci fit", 20, 4, 5, 1.3), 
        new("Lidl fit", 10, 2, 3, 1.2), 
        new("Gentleman fit", 15, 6, 3, 3), 
        new("Pickle Rick", 10, 3, 8, 0.9)
        ];
    // Creation of shoes
    static List<Shoes> shoes = 
        [
        new("Bare grippers", 0, 0, 1), 
        new("Nazi boots", 20, 4, 1.3), 
        new("Tapdancer shoes", 10, 4, 1.2), 
        new("Cucci flipflops", 5, 1, 2), 
        new("Jordans", 20, 5, 3)
        ];
    // Creation of characters
    static Göran göran = new(); static Petar petar = new(); static Bobby bobby = new(); static AnisDonDemina anisDonDemina = new();
    static List<Pusher> pushers = [göran, petar, bobby, anisDonDemina]; 
    // Creation of bots
    static Player bot1 = new(), bot2 = new(), bot3 = new(), bot4 = new();
    static List<Player> bots = [bot1, bot2, bot3, bot4];
    static List<Player> placings = [bot1, bot2, bot3, bot4];
    static List<string> botNames = ["Jeremy", "Lester", "Steve", "Catrina", "Karen", "Alice", "Michael", "Paul", "Jonkler", "Hanna", "Daniel", "Jonathan", "Sami", "Erik", "Allu", "Jonna", "Anna", "JimmieÅk", "MagdalenaAnd", "Uffe", "Knugen", "Darius"];
    // Creation of carts
    static BigCart bigCart = new(); static MediumCart mediumCart = new(); static CarCart carCart = new();
    static List<Vehicle> vehicles = [bigCart, mediumCart, carCart];
    // Creation of maps
    static List<Map> maps = [new("McDonalds drivethru", [0, 0], ['c', 'c'], [40, 40]), new("Willy:s showdown", [0, 0, 1, 0, 1, 0, 0], ['w','c','c','c','w','w','w'], [30, 30, 20, 50, 20, 30, 30])];
    public static void Main(string[] args)
    {
        // Global variables
        int choice = 0;
        double frames = 1;
        bool skip = false;
        bool hasWon = false;
        Random rand = new();
        // Player
        Player player = new();
        bots.Add(player);
        placings.Add(player);
        // Default values
        player.PlayerPusher = göran;
        player.PlayerVehicle = bigCart;
        player.PlayerClothing = clothing[0];
        player.PlayerShoes = shoes[0];
        // Intro
        Console.WriteLine("Willy's shopping cart racing!");
        Console.WriteLine("Enter your name");
        while (true)
        {
            player.Name = Console.ReadLine();
            if (player.Name == "")
            {
                Console.WriteLine("Please enter a name");
                continue;
            }
            else if (player.Name.Contains(' '))
            {
                Console.WriteLine("Names can't contain ' ', please try again");
                continue;
            }
            break;
        }
        Console.WriteLine("PRESS ANY BUTTON TO CONTINUE:");
        Console.ReadKey();
        Console.Clear();
        // Game Loop
        while (true)
        {
            // Customization menu loop
            while (!skip) 
            {
                Console.WriteLine("Customization:");
                Console.WriteLine("1. Change cart");
                Console.WriteLine("2. Change pusher");
                Console.WriteLine("3. Change pushers shoes");
                Console.WriteLine("4. Change pushers clothing");
                Console.WriteLine("5. Drive!");
                Console.WriteLine("6. Help!");
                Console.WriteLine("");
                Console.WriteLine("Current set-up:");
                Console.WriteLine($"Cart: {player.PlayerVehicle.Name}");
                Console.WriteLine($"Pusher: {player.PlayerPusher.PusherName}");
                Console.WriteLine($"Pushers shoes: {player.PlayerShoes.Name}");
                Console.WriteLine($"Pushers clothing: {player.PlayerClothing.Name}");
                choice = FetchChoice(6);
                // Cart customization
                if (choice == 1)
                {
                    // Creating list of choices
                    for (int i = 0; i < vehicles.Count; i++)
                    {
                        Console.Write($"{i + 1}. Name: {vehicles[i].Name}.");
                        for (int j = 1; j < 22 - vehicles[i].Name.Length; j++)
                        {
                            Console.Write(" ");
                        }
                        Console.Write($" Strength: [{Convert.ToInt32(vehicles[i].Strength / 2)}/10]");
                        if (Convert.ToInt32(vehicles[i].Strength / 2) != 10)
                        {
                            Console.Write(" ");
                        }
                        Console.Write($" Speed: [{Convert.ToInt32(vehicles[i].MaxSpeed)}/10]");
                        if (Convert.ToInt32(vehicles[i].MaxSpeed) != 10)
                        {
                            Console.Write(" ");
                        }
                        Console.Write($" Accel: [{Convert.ToInt32(vehicles[i].Acceleration / 0.2)}/10]");
                        if (Convert.ToInt32(vehicles[i].Acceleration / 0.2) != 10)
                        {
                            Console.Write(" ");
                        }
                        Console.Write($" Style: [{Convert.ToInt32(vehicles[i].Style / 5)}/10]");
                        if (Convert.ToInt32(vehicles[i].Style / 5) != 10)
                        {
                            Console.Write(" ");
                        }

                        Console.WriteLine();
                    }
                    Console.WriteLine("");
                    Console.WriteLine($"Current: {player.PlayerVehicle.Name}");
                    choice = FetchChoice(vehicles.Count);
                    player.PlayerVehicle = vehicles[choice - 1];
                    choice = 0;
                    continue;
                }
                // Pusher customization
                else if (choice == 2)
                {
                    for (int i = 0; i < pushers.Count; i++)
                    {
                        Console.Write($"{i + 1}. Name: {pushers[i].PusherName}.");
                        for (int j = 1; j < 16 - pushers[i].PusherName.Length; j++)
                        {
                            Console.Write(" ");
                        }
                        Console.Write($" Speed: [{Convert.ToInt32(pushers[i].PusherSpeedBoost)}/10]");
                        if (Convert.ToInt32(pushers[i].PusherSpeedBoost) != 10)
                        {
                            Console.Write(" ");
                        }
                        Console.Write($" Accel: [{Convert.ToInt32(pushers[i].PusherAccelerationBoost / 0.1)}/10]");
                        if (Convert.ToInt32(pushers[i].PusherAccelerationBoost / 0.1) != 10)
                        {
                            Console.Write(" ");
                        }
                        Console.Write($" Strength: [{Convert.ToInt32(pushers[i].PusherStrengthBoost)}/10]");
                        if (Convert.ToInt32(pushers[i].PusherStrengthBoost) != 10)
                        {
                            Console.Write(" ");
                        }
                        Console.Write($" Style: [{Convert.ToInt32(pushers[i].PusherStyleBoost / 10)}/10]");
                        if (Convert.ToInt32(pushers[i].PusherStyleBoost / 10) != 10 && pushers[i].PusherStyleBoost >= 0)
                        {
                            Console.Write(" ");
                        }
                        Console.Write($" | Description: {pushers[i].PusherDescription}");
                        Console.WriteLine();
                    }
                    Console.WriteLine("");
                    Console.WriteLine($"Current: {player.PlayerPusher.PusherName}");
                    choice = FetchChoice(pushers.Count);
                    player.PlayerPusher = pushers[choice - 1];
                    choice = 0;
                    continue;

                }
                // Shoes customization
                else if (choice == 3)
                {
                    for (int i = 0; i < shoes.Count; i++)
                    {
                        Console.Write($"{i + 1}. Name: {shoes[i].Name}.");
                        for (int j = 1; j < 16 - shoes[i].Name.Length; j++)
                        {
                            Console.Write(" ");
                        }
                        Console.Write($" Warmth: [{Convert.ToInt32(shoes[i].Warmth / 2)}/10]");
                        if (Convert.ToInt32(shoes[i].Warmth / 2) != 10)
                        {
                            Console.Write(" ");
                        }
                        Console.Write($" Speed: [{10 - Convert.ToInt32(shoes[i].SpeedReduction / 0.6)}/10]");
                        if (10 - Convert.ToInt32(shoes[i].SpeedReduction / 0.5) != 10)
                        {
                            Console.Write(" ");
                        }
                        Console.Write($" Style: [{Convert.ToInt32(shoes[i].StyleBoostMult / 0.3)}/10]");
                        if (Convert.ToInt32(shoes[i].StyleBoostMult / 0.3) != 10)
                        {
                            Console.Write(" ");
                        }

                        Console.WriteLine();
                    }
                    Console.WriteLine("");
                    Console.WriteLine($"Current: {player.PlayerShoes.Name}");
                    choice = FetchChoice(shoes.Count);
                    player.PlayerShoes = shoes[choice - 1];
                    choice = 0;
                    continue;

                }
                // Clothing customization
                else if (choice == 4)
                {
                    for (int i = 0; i < clothing.Count; i++)
                    {
                        Console.Write($"{i + 1}. Name: {clothing[i].Name}.");
                        for(int j = 1; j < 15 - clothing[i].Name.Length; j++)
                        {
                            Console.Write(" ");
                        }
                        Console.Write($" Warmth: [{Convert.ToInt32(clothing[i].Warmth / 2)}/10]");
                        if (Convert.ToInt32(clothing[i].Warmth / 2) != 10)
                        {
                            Console.Write(" ");
                        }
                        Console.Write($" Speed: [{10 - Convert.ToInt32(clothing[i].SpeedReduction / 0.6)}/10]");
                        if (10 - Convert.ToInt32(clothing[i].SpeedReduction / 0.6) != 10)
                        {
                            Console.Write(" ");
                        }
                        Console.Write($" Defence: [{Convert.ToInt32(clothing[i].Defence / 0.8)}/10]");
                        if (Convert.ToInt32(clothing[i].Defence / 0.8) != 10)
                        {
                            Console.Write(" ");
                        }
                        Console.Write($" Style: [{Convert.ToInt32(clothing[i].StyleBoostMult / 0.3)}/10]");
                        if (Convert.ToInt32(clothing[i].StyleBoostMult / 0.3) != 10)
                        {
                            Console.Write(" ");
                        }

                        Console.WriteLine();
                    }
                    Console.WriteLine("");
                    Console.WriteLine($"Current: {player.PlayerClothing.Name}");
                    choice = FetchChoice(clothing.Count);
                    player.PlayerClothing = clothing[choice - 1];
                    choice = 0;
                    continue;

                }
                // Exiting customization menu loop
                else if (choice == 5)
                {
                    Console.Clear();
                    break;
                }
                // Printing the instructions
                else if (choice == 6)
                {
                    Console.WriteLine("Welcome to Willy's shopping cart racing. The idea is pretty simple. You just customize your vehicle and pusher, and then you race some bots!");
                    Console.WriteLine("1. Carts: Carts are the vehicles that you race. There are different types with different stats, such as strength or style. Carts also have unique abilities that can activate in a race.");
                    Console.WriteLine("2. Pushers: Pushers is the \"Engine\" you have to power your cart. These also have stats much like the carts, and they also have abilities.");
                    Console.WriteLine("3. Clothing: Clothing is what you make your pusher wear, and depending on which clothing you choose it can impact the race a lot. Clothing also has the special stats \"Defence\" and \"Warmth\", each with their own purpose. Clothing also has style multipliers, instead of simple additive styleboosts.");
                    Console.WriteLine("4. Shoes: Shoes are what your pusher has on their feet. They have the same standard stats as everything else.");
                    Console.WriteLine("");
                    Console.WriteLine("The different stats have different effects on the racing");
                    Console.WriteLine("Style: Increases odds of activating abilities");
                    Console.WriteLine("Strength: Increases chance of hitting someone and resetting their speed");
                    Console.WriteLine("Top speed: The highest speed you can achieve (m/s)");
                    Console.WriteLine("Acceleration: The rate at which your speed increases (m/s^2)");
                    Console.WriteLine("Defence: Decreases the risk of being hit");
                    Console.WriteLine("Warmth: Reduces speed decrease when in a cold zone (Cold zones are a part of a map which affect top speed when going through them)");
                    Console.WriteLine("");
                    Console.WriteLine("It's important to note that the races are completely automated, with completely random occurences. After starting a race, you just need to sit back and watch");
                    Console.WriteLine("");
                    Console.WriteLine("That about sums it all up. Happy racing!");
                    Console.WriteLine("PRESS ANY KEY TO CONTINUE");
                    Console.ReadKey();
                    Console.Clear();

                }
            }
            skip = false;
            // Selecting map to play on
            Console.WriteLine("Select a map to race on");
            for (int i = 0; i < maps.Count; i++)
            {
                Console.WriteLine($"{i + 1}. Name: {maps[i].MapName}. Length: {maps[i].TotalLength} Meters");
            }
            Console.WriteLine($"{maps.Count + 1}. Return to customization");
            choice = FetchChoice(maps.Count + 1);
            if(choice == maps.Count + 1)
            {
                Console.Clear();
                continue;
            }
            player.SelectMap = maps[choice - 1];
            choice = 0;
            // Randomizing bots
            for (int i = 0; i < bots.Count - 1; i++)
            {
                bots[i].PlayerPusher = pushers[rand.Next(0, pushers.Count)];
                bots[i].PlayerClothing = clothing[rand.Next(0, clothing.Count)];
                bots[i].PlayerShoes = shoes[rand.Next(0, shoes.Count)];
                bots[i].PlayerVehicle = vehicles[rand.Next(0, vehicles.Count)];
                bots[i].Name = botNames[rand.Next(0, botNames.Count)];
            }
            // Calculating stats before race
            for (int i = 0; i < bots.Count; i++)
            {
                bots[i].Speed = 0;
                bots[i].MaxSpeed = bots[i].PlayerPusher.PusherSpeedBoost + bots[i].PlayerVehicle.MaxSpeed - bots[i].PlayerClothing.SpeedReduction - bots[i].PlayerShoes.SpeedReduction;
                bots[i].Acceleration = bots[i].PlayerPusher.PusherAccelerationBoost + bots[i].PlayerVehicle.Acceleration;
                bots[i].Style = (bots[i].PlayerPusher.PusherStyleBoost + bots[i].PlayerVehicle.Style) * bots[i].PlayerClothing.StyleBoostMult * bots[i].PlayerShoes.StyleBoostMult;
                if (bots[i].Style <= 0)
                {
                    bots[i].Style = 1;
                }
                bots[i].Warmth = bots[i].PlayerClothing.Warmth + bots[i].PlayerShoes.Warmth;
                bots[i].Defence = bots[i].PlayerClothing.Defence;
                bots[i].Strength = bots[i].PlayerPusher.PusherStrengthBoost + bots[i].PlayerVehicle.Strength;
                // Saving copy of maxspeed
                bots[i].MaxSpeedCopy = bots[i].MaxSpeed;
            }
            // Pause before race with info printing
            Console.WriteLine("The race is about to start");
            Console.WriteLine("The racers are:");
            for (int i = 0; i < bots.Count; i++)
            {
                Console.WriteLine($"Name: {bots[i].Name}. Set-up: {bots[i].PlayerVehicle.Name}, {bots[i].PlayerPusher.PusherName}, {bots[i].PlayerShoes.Name}, {bots[i].PlayerClothing.Name}");
            }
            Console.WriteLine("PRESS ANY KEY TO CONTINUE");
            Console.ReadKey();
            Console.Clear();
            // Countdown
            Console.WriteLine("Ready");
            Thread.Sleep(1000);
            Console.WriteLine("Set");
            Thread.Sleep(1000);
            Console.WriteLine("GO!");
            Thread.Sleep(1000);
            Console.Clear();
            // Resetting distance
            for (int i = 0; i < bots.Count; i++) 
            {
                bots[i].Distance = 0;
            }
            // Gameplay loop
            while (!hasWon)
            {
                // Stat calculations for the field
                for (int i = 0; i < bots.Count; i++)
                {
                    bots[i].MaxSpeed = (bots[i].PlayerPusher.PusherSpeedBoost + bots[i].PlayerVehicle.MaxSpeed - bots[i].PlayerClothing.SpeedReduction - bots[i].PlayerShoes.SpeedReduction)/frames + 1;
                    bots[i].Acceleration = (bots[i].PlayerPusher.PusherAccelerationBoost + bots[i].PlayerVehicle.Acceleration)/frames;
                    bots[i].Style = (bots[i].PlayerPusher.PusherStyleBoost + bots[i].PlayerVehicle.Style) * bots[i].PlayerClothing.StyleBoostMult * bots[i].PlayerShoes.StyleBoostMult/frames;
                    if (bots[i].Style <= 0)
                    {
                        bots[i].Style = 1;
                    }
                    bots[i].Warmth = (bots[i].PlayerClothing.Warmth + bots[i].PlayerShoes.Warmth)/frames;
                    bots[i].Defence = (bots[i].PlayerClothing.Defence)/frames;
                    bots[i].Strength = (bots[i].PlayerPusher.PusherStrengthBoost + bots[i].PlayerVehicle.Strength)/frames;
                    // Checking if tile is cold and calculating speeds based on warmth
                    if (player.SelectMap.TilesWarmth[bots[i].Tile] == 'c')
                    {
                        bots[i].MaxSpeed = bots[i].MaxSpeedCopy * (1 - 0.3 / (bots[i].Warmth+2));
                    }
                    // Checking if tile is a turn
                    if (player.SelectMap.TilesDirection[bots[i].Tile] == 1)
                    {
                        bots[i].Strength *= 2;
                    }
                }
                // Speed calculations for the field
                for (int i = 0; i < bots.Count; i++)
                {
                    bots[i].Speed = SpeedCalc(bots[i].Speed, bots[i].MaxSpeed, bots[i].Acceleration);
                }
                Console.Clear();
                // Distance calculations for the field
                for (int i = 0; i < placings.Count; i++)
                {
                    placings[i].Distance += placings[i].Speed;
                }
                // Placement sorting and printing
                PlacingsSort(placings);
                for (int i = 0; i < placings.Count; i++) 
                {
                    Console.WriteLine($"{i+1}: {placings[i].Name}, Distance: {Math.Round(placings[i].Distance*10)/10} Meters. Speed:{Math.Round(placings[i].Speed*10)/10}");
                    if (placings[i].Distance >= player.SelectMap.TotalLength)
                    {
                        Console.Clear();
                        Console.WriteLine($"{placings[i].Name} has won the race");
                        Thread.Sleep(2000);
                        Console.WriteLine("");
                        Console.WriteLine("Play again?");
                        Console.WriteLine("1. Yes");
                        Console.WriteLine("2. No (Goes back to customization)");
                        choice = FetchChoice(2);
                        if(choice == 1)
                        {
                            skip = true;
                        }
                        else
                        {
                            Console.WriteLine("You return to the cart garage");
                            Thread.Sleep(2000);
                        }
                        Console.Clear();
                        hasWon = true;
                        break;
                    }
                }
                // Checking if race is over
                if (hasWon)
                {
                    continue;
                }
                // Ability activation and printing
                Console.WriteLine();
                for (int i = 0;i < placings.Count; i++)
                {
                    // Checking if ability is active and randomizing
                    if (!placings[i].PlayerPusher.AbilityEnabled)
                    {
                        if (rand.Next(0, Convert.ToInt32(Math.Ceiling(300 / placings[i].Style))) == 1)
                        {
                            // Checking if bobby's ability is activated
                            if (placings[i].PlayerPusher.PusherAbilityName == "DuckNWeave")
                            {
                                placings[i].Defence *= 1.4;
                            }
                            placings[i].PlayerPusher.AbilityOn();
                            placings[i].PlayerPusher.AbilityEnabled = true;
                            Console.WriteLine($"{placings[i].Name} has activated their ability '{placings[i].PlayerPusher.PusherAbilityName}'");
                            Console.WriteLine();
                            continue;
                        }
                    }
                    else
                    {
                        // Checking how long ability has been active
                        if (placings[i].PlayerPusher.AbilityTick >= 4)
                        {
                            if(placings[i].PlayerPusher.PusherAbilityName == "DuckNWeave")
                            {
                                placings[i].Defence /= 1.4;
                            }
                            placings[i].PlayerPusher.AbilityOff();
                            placings[i].PlayerPusher.AbilityEnabled = false;
                            placings[i].PlayerPusher.AbilityTick = 0;
                        }
                        else
                        {
                            placings[i].PlayerPusher.AbilityTick++;
                        }
                    }
                    if (!placings[i].PlayerVehicle.AbilityEnabled)
                    {
                        if (rand.Next(0, Convert.ToInt32(Math.Ceiling(10 / placings[i].Style))) == 1)
                        {
                            placings[i].PlayerVehicle.AbilityOn();
                            Console.WriteLine($"{placings[i].Name} has activated their ability '{placings[i].PlayerVehicle.AbilityName}'");
                            Console.WriteLine();
                        }
                    }
                    else
                    {
                        if (placings[i].PlayerVehicle.AbilityTick >= 4)
                        {
                            placings[i].PlayerVehicle.AbilityOff();
                            placings[i].PlayerVehicle.AbilityEnabled = false;
                            placings[i].PlayerVehicle.AbilityTick = 0;
                        }
                        else
                        {
                            placings[i].PlayerVehicle.AbilityTick++;
                        }
                    }
                }
                // Checking which tile player is on
                for(int i = 0; i < bots.Count; i++)
                {
                    double copy = bots[i].Distance;
                    for (int j = 0; j < player.SelectMap.TilesAmount; j++)
                    {
                        copy -= player.SelectMap.TileLengths[j];
                        bots[i].Tile = j;
                        if (copy < player.SelectMap.TileLengths[j])
                        {
                            break;
                        }
                    }
                }
                // Placing players inside tiles
                for(int i = 0; i < placings.Count; i++)
                {
                    player.SelectMap.Placements[placings[i].Tile].Add(item: placings[i]);
                }
                // Checking if players have collided
                for(int i = 0; i < player.SelectMap.TilesAmount; i++)
                {
                    for(int j = 0; j < player.SelectMap.Placements[i].Count; j++)
                    {
                        Console.WriteLine($"{player.SelectMap.Placements[i][j].Name}");
                    }
                    if (player.SelectMap.Placements[i].Count > 1)
                    {
                        for (int j = 0; j < player.SelectMap.Placements[i].Count - 1; j++)
                        {
                            Player person1 = player.SelectMap.Placements[i][j];
                            Player person2 = player.SelectMap.Placements[i][j+1];
                            Console.WriteLine($"P1:{person1.Name}, P2:{person2.Name}");
                            if (-1 == rand.Next(-2, Convert.ToInt32(person2.Defence * 20 / person1.Strength)) && !person1.HasCollided)
                            {
                                person1.HasCollided = true;
                                person2.Speed = 0;
                                Console.WriteLine();
                                Console.WriteLine($"{person1.Name} has collided with {person2.Name} and made them loose all their speed");
                            }
                            else if (-1 == rand.Next(-2, Convert.ToInt32(person1.Defence * 20 / person2.Strength)) && !person2.HasCollided)
                            {
                                person2.HasCollided = true;
                                person1.Speed = 0;
                                Console.WriteLine();
                                Console.WriteLine($"{person2.Name} has collided with {person1.Name} and made them loose all their speed");
                            }
                        }
                    }
                }
                for(int i = 0; i < player.SelectMap.Placements.Length; i++)
                {
                    player.SelectMap.Placements[i].Clear();
                }
                for (int i = 0;i < bots.Count; i++)
                {
                    bots[i].HasCollided = false;
                }
                // Time before next tick
                Thread.Sleep(Convert.ToInt32(1000/frames));
            }
            // Resetting stats for pushers and vehicles
            for(int i = 0; i < bots.Count; i++)
            {
                if (bots[i].PlayerPusher.AbilityEnabled)
                {
                    bots[i].PlayerPusher.AbilityOff();
                    bots[i].PlayerPusher.AbilityEnabled = false;
                    if (bots[i].PlayerPusher.PusherAbilityName == "DuckNWeave")
                    {
                        bots[i].Defence /= 1.4;
                    }
                }
                if (bots[i].PlayerVehicle.AbilityEnabled)
                {
                    bots[i].PlayerVehicle.AbilityOff();
                    bots[i].PlayerVehicle.AbilityEnabled = false;
                }
            }
            hasWon = false;
        }
    }
    public static int FetchChoice(int options)
    {
        int choice;
        while (true)
        {
            try
            {
                Console.WriteLine("");
                choice = Convert.ToInt16(Console.ReadLine());
                if (choice > options || choice < 1)
                {
                    throw new OverflowException("Input was not a choice");
                }
                break;
            }
            catch (FormatException)
            {
                Console.Write("Input was not a number");
            }
            catch (OverflowException e)
            {
                Console.Write(e.Message);
            }
            Console.WriteLine(", try again");
        }
        Console.Clear();
        return choice;
    }
    public static double SpeedCalc(double speed, double maxSpeed, double acceleration)
    {
        double newSpeed = 0;
        if (speed + acceleration <= maxSpeed)
        {
            newSpeed = speed + acceleration;
        }
        else
        {
            newSpeed = speed;
        }
        return newSpeed;
    }
    public static void PlacingsSort(List<Player> playerList)
    {
        Player copy1, copy2;
        for (int i = 1; i < playerList.Count; i++)
        {
            copy1 = playerList[i];
            copy2 = playerList[i-1];
            if (copy1.Distance > copy2.Distance) 
            {
                playerList[i] = copy2;
                playerList[i - 1] = copy1;
            }
        }
    }

}