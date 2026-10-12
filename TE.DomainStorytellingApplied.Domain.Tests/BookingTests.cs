using TE.DomainStorytellingApplied.Domain;

namespace TE.DomainStorytellingApplied.Domain.Tests;

public class BookingTests
{
    [Fact]
    public void GivenValidIds_WhenBooking_ShouldKeepAllIds()
    {
        var timeslotId = Id.Generate();
        var bookerId = Id.Generate();
        var premisesId = Id.Generate();

        var booking = Booking.Book(timeslotId, bookerId, premisesId);

        booking.BookingId.ShouldNotBeNull();
        booking.TimeslotId.ShouldBe(timeslotId);
        booking.BookerId.ShouldBe(bookerId);
        booking.PremisesId.ShouldBe(premisesId);
    }

    [Fact]
    public void GivenAvailableTimeslot_WhenBookingThroughService_ShouldCreateBooking()
    {
        var service = new BookingService();
        var timeslotId = Id.Generate();
        var bookerId = Id.Generate();
        var premisesId = Id.Generate();

        var booking = service.Book(timeslotId, bookerId, premisesId);

        booking.TimeslotId.ShouldBe(timeslotId);
        booking.BookerId.ShouldBe(bookerId);
        booking.PremisesId.ShouldBe(premisesId);
    }

    [Fact]
    public void GivenBookedTimeslot_WhenBookingAgain_ShouldThrow()
    {
        var service = new BookingService();
        var timeslotId = Id.Generate();

        service.Book(timeslotId, Id.Generate(), Id.Generate());

        Should.Throw<InvalidOperationException>(() =>
            service.Book(timeslotId, Id.Generate(), Id.Generate()));
    }
}