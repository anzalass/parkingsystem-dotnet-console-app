public class ParkingSlot
{
    public int SlotNumber { get; }
    public bool IsAvailable { get; set; }
    public Vehicle? Vehicle { get; set; }

    public ParkingSlot(int slotNumber)
    {
        SlotNumber = slotNumber;
        IsAvailable = true;
    }
}
