namespace TE.DomainStorytellingApplied.Domain;

public class Reservation
{
    public Id ReservationId { get; init; }
    public Id TimeslotId { get; init; }
    public Id BookerId { get; init; }
    public Id PremisesId { get; init; }
}