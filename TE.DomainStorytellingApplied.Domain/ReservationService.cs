namespace TE.DomainStorytellingApplied.Domain;

public class ReservationService
{
    private readonly List<Reservation> _reservations = [];

    public Reservation Book(Id timeslotId, Id bookerId, Id premisesId)
    {
        if (_reservations.Any(reservation => reservation.TimeslotId == timeslotId))
            throw new InvalidOperationException("The timeslot is already booked");

        var reservation = Reservation.Book(timeslotId, bookerId, premisesId);

        _reservations.Add(reservation);
        return reservation;
    }
}