using Part2_HotelReservationSystem.src;

Hotel hotel = new();

Guest guest = new(1, "Ahmed Hassan", "01012345678");

Room room = new(101, RoomType.Double, 1500m);

hotel.AddGuest(guest);
hotel.AddRoom(room);

Reservation reservation = hotel.CreateReservation(
    1001,
    guest,
    room,
    new DateTime(2026, 10, 10),
    new DateTime(2026, 10, 13));

Console.WriteLine($"Guest: {guest.FullName}");
Console.WriteLine($"Room: {room.RoomNumber}");
Console.WriteLine($"Room Type: {room.RoomType}");
Console.WriteLine($"Nightly Rate: {room.NightlyRate:C}");
Console.WriteLine($"Status: {reservation.Status}");
Console.WriteLine($"Total Cost: {reservation.TotalCost:C}");

reservation.Confirm();

Console.WriteLine($"Status after confirmation: {reservation.Status}");

reservation.CheckIn();

Console.WriteLine($"Status after check-in: {reservation.Status}");

reservation.CheckOut();

Console.WriteLine($"Status after check-out: {reservation.Status}");

Console.WriteLine($"Guest reservation history: {guest.Reservations.Count}");