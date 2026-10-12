namespace TE.DomainStorytellingApplied.Domain;

public class ReservationService
{
    private readonly List<Reservation> _reservations = [];

    public Reservation Book(Id timeslotId, Id bookerId, Id premisesId)
    {
        if (_reservations.Any(reservation => reservation.TimeslotId == timeslotId))
            throw new Exception("The timeslot is already booked");
        
        if (_reservations.Any(reservation => reservation.PremisesId == premisesId))
            throw new Exception("The premises is already booked");

        var reservation = new Reservation(
            Id.Generate(),
            timeslotId,
            bookerId,
            premisesId);

        _reservations.Add(reservation);
        return reservation;
    }
}