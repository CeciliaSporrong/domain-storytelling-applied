using TE.DomainStorytellingApplied.Domain;

namespace TE.DomainStorytellingApplied.Domain.Tests;

public class ReservationTests
{
    [Fact]
    public void GivenValidIds_WhenBooking_ShouldKeepAllIds()
    {
        var reservationId = Id.Generate();
        var timeslotId = Id.Generate();
        var bookerId = Id.Generate();
        var premisesId = Id.Generate();

        var reservation = new Reservation
        {
            ReservationId = reservationId,
            TimeslotId = timeslotId,
            BookerId = bookerId,
            PremisesId = premisesId
        };

        reservation.ReservationId.ShouldBe(reservationId);
        reservation.TimeslotId.ShouldBe(timeslotId);
        reservation.BookerId.ShouldBe(bookerId);
        reservation.PremisesId.ShouldBe(premisesId);
    }
}