using TE.DomainStorytellingApplied.Domain;

namespace TE.DomainStorytellingApplied.Domain.Tests;

public class ReservationTests
{
    [Fact]
    public void GivenValidIds_WhenBooking_ShouldKeepAllIds()
    {
        var timeslotId = Id.Generate();
        var bookerId = Id.Generate();
        var premisesId = Id.Generate();

        var reservation = Reservation.Book(timeslotId, bookerId, premisesId);

        reservation.ReservationId.ShouldNotBeNull();
        reservation.TimeslotId.ShouldBe(timeslotId);
        reservation.BookerId.ShouldBe(bookerId);
        reservation.PremisesId.ShouldBe(premisesId);
    }

    [Fact]
    public void GivenAvailableTimeslot_WhenBookingThroughService_ShouldCreateReservation()
    {
        var service = new ReservationService();
        var timeslotId = Id.Generate();
        var bookerId = Id.Generate();
        var premisesId = Id.Generate();

        var reservation = service.Book(timeslotId, bookerId, premisesId);

        reservation.TimeslotId.ShouldBe(timeslotId);
        reservation.BookerId.ShouldBe(bookerId);
        reservation.PremisesId.ShouldBe(premisesId);
    }

    [Fact]
    public void GivenBookedTimeslot_WhenBookingAgain_ShouldThrow()
    {
        var service = new ReservationService();
        var timeslotId = Id.Generate();

        service.Book(timeslotId, Id.Generate(), Id.Generate());

        Should.Throw<InvalidOperationException>(() =>
            service.Book(timeslotId, Id.Generate(), Id.Generate()));
    }
}