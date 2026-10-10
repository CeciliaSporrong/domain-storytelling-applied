using TE.DomainStorytellingApplied.Domain;

namespace TE.DomainStorytellingApplied.Domain.Tests;

public class ReservationTests
{
    [Fact]
    public void GivenValidIds_WhenCreating_ShouldKeepAllIds()
    {
        var reservationId = Id.Generate();
        var timeslotId = Id.Generate();
        var bookerId = Id.Generate();
        var premisesId = Id.Generate();

        var reservation = new Reservation(reservationId, timeslotId, bookerId, premisesId, DateTimeOffset.UtcNow);

        reservation.ReservationId.ShouldBe(reservationId);
        reservation.TimeslotId.ShouldBe(timeslotId);
        reservation.BookerId.ShouldBe(bookerId);
        reservation.PremisesId.ShouldBe(premisesId);
    }

    [Fact]
    public void GivenNewReservation_WhenCreating_ShouldBePending()
    {
        var reservation = CreateReservation();

        reservation.Status.ShouldBe(ReservationStatus.Pending);
    }

    [Fact]
    public void GivenPendingReservation_WhenApproving_ShouldBeApprovedByReviewer()
    {
        var reservation = CreateReservation();
        var reviewerId = Id.Generate();

        reservation.Approve(reviewerId);

        reservation.Status.ShouldBe(ReservationStatus.Approved);
        reservation.ApprovedBy.ShouldBe(reviewerId);
    }

    [Fact]
    public void GivenPendingReservation_WhenRejectingWithReason_ShouldBeRejected()
    {
        var reservation = CreateReservation();
        var reviewerId = Id.Generate();

        reservation.Reject(reviewerId, "The premises are occupied");

        reservation.Status.ShouldBe(ReservationStatus.Rejected);
        reservation.ApprovedBy.ShouldBe(reviewerId);
        reservation.RejectedReason.ShouldBe("The premises are occupied");
    }

    [Fact]
    public void GivenPendingReservation_WhenRejectingWithEmptyReason_ShouldThrow()
    {
        var reservation = CreateReservation();

        Should.Throw<ArgumentException>(() => reservation.Reject(Id.Generate(), ""));
    }

    [Fact]
    public void GivenPendingReservation_WhenRejectingWithWhitespaceReason_ShouldThrow()
    {
        var reservation = CreateReservation();

        Should.Throw<ArgumentException>(() => reservation.Reject(Id.Generate(), "   "));
    }

    private static Reservation CreateReservation() =>
        new(Id.Generate(), Id.Generate(), Id.Generate(), Id.Generate(), DateTimeOffset.UtcNow);
}
