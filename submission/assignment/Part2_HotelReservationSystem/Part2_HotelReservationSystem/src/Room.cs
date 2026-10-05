namespace Part2_HotelReservationSystem.src;

public class Room
{
    public int RoomNumber { get; }
    public RoomType RoomType { get; }
    public decimal NightlyRate { get; private set; }
    public bool IsUnderMaintenance { get; private set; }

    public Room(int roomNumber, RoomType roomType, decimal nightlyRate)
    {
        if (nightlyRate <= 0)
        {
            throw new ArgumentException("Nightly rate must be positive.");
        }

        RoomNumber = roomNumber;
        RoomType = roomType;
        NightlyRate = nightlyRate;
        IsUnderMaintenance = false;
    }

    public void UpdateNightlyRate(decimal newRate)
    {
        if (newRate <= 0)
        {
            throw new ArgumentException("Nightly rate must be positive.");
        }

        NightlyRate = newRate;
    }

    public void StartMaintenance()
    {
        IsUnderMaintenance = true;
    }

    public void EndMaintenance()
    {
        IsUnderMaintenance = false;
    }
}