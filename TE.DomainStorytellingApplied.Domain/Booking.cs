namespace TE.DomainStorytellingApplied.Domain;

public class Booking
{
    public Id BookingId { get; init; }
    public Id TimeslotId { get; init; }
    public Id BookerId { get; init; }
    public Id PremisesId { get; init; }

    public Booking(Id bookingId, Id timeslotId, Id bookerId, Id premisesId)
    {
        BookingId = bookingId;
        TimeslotId = timeslotId;
        BookerId = bookerId;
        PremisesId = premisesId;
    }

    public static Booking Book(Id timeslotId, Id bookerId, Id premisesId) =>
        new(Id.Generate(), timeslotId, bookerId, premisesId);
}