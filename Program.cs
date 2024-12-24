class Program
{
    static void Main(string[] args)
    {
        ParkingLot parkingLot = null;

        while (true)
        {
            Console.WriteLine("Enter command:");
            string command = Console.ReadLine()?.Trim();

            if (command == "exit")
            {
                break;
            }

            if (command.StartsWith("create_parking_lot"))
            {
                var match = System.Text.RegularExpressions.Regex.Match(command, @"create_parking_lot (\d+)");
                if (match.Success)
                {
                    int totalSlots = int.Parse(match.Groups[1].Value);
                    parkingLot = new ParkingLot(totalSlots);
                    Console.WriteLine($"Created a parking lot with {totalSlots} slots");
                }
            }
            else if (command.StartsWith("park"))
            {
                var match = System.Text.RegularExpressions.Regex.Match(command, @"park (\S+) (\S+) (\S+)");
                if (match.Success && parkingLot != null)
                {
                    string regNumber = match.Groups[1].Value;
                    string colour = match.Groups[2].Value;
                    string typeStr = match.Groups[3].Value;
                    VehicleType type = Enum.Parse<VehicleType>(typeStr, true);

                    var vehicle = new Vehicle(regNumber, colour, type);
                    var result = parkingLot.ParkVehicle(vehicle);
                    Console.WriteLine(result);
                }
            }
            else if (command.StartsWith("leave"))
            {
                var match = System.Text.RegularExpressions.Regex.Match(command, @"leave (\d+)");
                if (match.Success && parkingLot != null)
                {
                    int slotNumber = int.Parse(match.Groups[1].Value);
                    var result = parkingLot.LeaveParking(slotNumber);
                    Console.WriteLine(result);
                }
            }
            else if (command == "status" && parkingLot != null)
            {
                parkingLot.DisplayStatus();
            }
            else if (command.StartsWith("type_of_vehicles"))
            {
                var match = System.Text.RegularExpressions.Regex.Match(command, @"type_of_vehicles (\S+)");
                if (match.Success && parkingLot != null)
                {
                    string typeStr = match.Groups[1].Value;
                    VehicleType type = Enum.Parse<VehicleType>(typeStr, true);
                    var count = parkingLot.CountVehiclesByType(type);
                    Console.WriteLine(count);
                }
            }
            else if (command.StartsWith("registration_numbers_for_vehicles_with_colour"))
            {
                var match = System.Text.RegularExpressions.Regex.Match(command, @"registration_numbers_for_vehicles_with_colour (\S+)");
                if (match.Success && parkingLot != null)
                {
                    string colour = match.Groups[1].Value;
                    var regNumbers = parkingLot.GetRegistrationNumbersByColour(colour);
                    Console.WriteLine(regNumbers);
                }
            }
        }
    }
}
