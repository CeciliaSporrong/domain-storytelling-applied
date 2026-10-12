namespace TE.DomainStorytellingApplied.Domain;

public class Reservation
{
    public Id ReservationId { get; init; }
    public Id TimeslotId { get; init; }
    public Id BookerId { get; init; }
    public Id PremisesId { get; init; }

    public Reservation(Id reservationId, Id timeslotId, Id bookerId, Id premisesId)
    {
        ReservationId = reservationId;
        TimeslotId = timeslotId;
        BookerId = bookerId;
        PremisesId = premisesId;
    }

    public static Reservation Book(Id timeslotId, Id bookerId, Id premisesId) =>
        new(Id.Generate(), timeslotId, bookerId, premisesId);
}