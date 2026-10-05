namespace Part2_HotelReservationSystem.src;

public class Hotel
{
    private readonly List<Guest> _guests = new();
    private readonly List<Room> _rooms = new();
    private readonly List<Reservation> _reservations = new();

    public IReadOnlyList<Guest> Guests => _guests;
    public IReadOnlyList<Room> Rooms => _rooms;
    public IReadOnlyList<Reservation> Reservations => _reservations;

    public void AddGuest(Guest guest)
    {
        if (_guests.Any(g => g.GuestId == guest.GuestId))
        {
            throw new InvalidOperationException(
                "A guest with this ID already exists.");
        }

        _guests.Add(guest);
    }

    public void AddRoom(Room room)
    {
        if (_rooms.Any(r => r.RoomNumber == room.RoomNumber))
        {
            throw new InvalidOperationException(
                "A room with this number already exists.");
        }

        _rooms.Add(room);
    }

    public Reservation CreateReservation(
        int reservationId,
        Guest guest,
        Room room,
        DateTime checkInDate,
        DateTime checkOutDate)
    {
        if (_reservations.Any(r => r.ReservationId == reservationId))
        {
            throw new InvalidOperationException(
                "A reservation with this ID already exists.");
        }

        bool overlappingReservation = _reservations.Any(r =>
            r.Room == room &&
            r.Status != ReservationStatus.Cancelled &&
            r.Status != ReservationStatus.CheckedOut &&
            checkInDate < r.CheckOutDate &&
            checkOutDate > r.CheckInDate);

        if (overlappingReservation)
        {
            throw new InvalidOperationException(
                "The room is already booked for the selected dates.");
        }

        Reservation reservation = new(
            reservationId,
            checkInDate,
            checkOutDate,
            room);

        _reservations.Add(reservation);
        guest.AddReservation(reservation);

        return reservation;
    }
}