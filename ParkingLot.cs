public class ParkingLot
{
    public List<ParkingSlot> Slots { get; set; }
    public int TotalSlots => Slots.Count;

    public ParkingLot(int totalSlots)
    {
        Slots = new List<ParkingSlot>(totalSlots);
        for (int i = 0; i < totalSlots; i++)
        {
            Slots.Add(new ParkingSlot(i + 1));
        }
    }

    public string ParkVehicle(Vehicle vehicle)
    {
        var slot = Slots.FirstOrDefault(s => s.IsAvailable);
        if (slot == null)
        {
            return "Sorry, parking lot is full";
        }

        slot.Vehicle = vehicle;
        slot.IsAvailable = false;
        return $"Allocated slot number: {slot.SlotNumber}";
    }

    public string LeaveParking(int slotNumber)
    {
        var slot = Slots.FirstOrDefault(s => s.SlotNumber == slotNumber);
        if (slot == null || slot.IsAvailable)
        {
            return "Slot not found or already empty";
        }

        slot.Vehicle = null;
        slot.IsAvailable = true;
        return $"Slot number {slotNumber} is free";
    }

    public void DisplayStatus()
    {
        Console.WriteLine("Slot No. | Registration No | Type | Colour");
        foreach (var slot in Slots.Where(s => !s.IsAvailable))
        {
            Console.WriteLine($"{slot.SlotNumber} | {slot.Vehicle?.RegistrationNumber} | {slot.Vehicle?.Type} | {slot.Vehicle?.Colour}");
        }
    }

    public int CountVehiclesByType(VehicleType type)
    {
        return Slots.Count(s => !s.IsAvailable && s.Vehicle?.Type == type);
    }

    public string GetRegistrationNumbersByColour(string colour)
    {
        var vehicles = Slots.Where(s => !s.IsAvailable && s.Vehicle?.Colour == colour)
                            .Select(s => s.Vehicle?.RegistrationNumber);
        return string.Join(", ", vehicles);
    }
}
