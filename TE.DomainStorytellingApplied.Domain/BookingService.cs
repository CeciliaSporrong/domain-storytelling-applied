namespace TE.DomainStorytellingApplied.Domain;

public class BookingService
{
    private readonly List<Booking> _bookings = [];

    public Booking Book(Id timeslotId, Id bookerId, Id premisesId)
    {
        if (_bookings.Any(booking => booking.TimeslotId == timeslotId))
            throw new InvalidOperationException("The timeslot is already booked");

        var booking = Booking.Book(timeslotId, bookerId, premisesId);

        _bookings.Add(booking);
        return booking;
    }
}