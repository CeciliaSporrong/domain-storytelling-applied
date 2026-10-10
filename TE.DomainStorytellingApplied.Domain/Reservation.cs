namespace TE.DomainStorytellingApplied.Domain;

public class Reservation
{
    public Id ReservationId { get; init; }
    public Id TimeslotId { get; init; }
    public Id BookerId { get; init; }
    public Id PremisesId { get; init; }

    public DateTimeOffset ReservationTime { get; set; }
    public ReservationStatus Status { get; set; }

    public Id? ApprovedBy { get; set; } 
    public string? RejectedReason { get; set; } 

    public Reservation(Id reservationId, Id timeslotId, Id bookerId, Id premisesId, DateTimeOffset reservationTime)
    {
        ReservationId = reservationId;
        TimeslotId = timeslotId;
        BookerId = bookerId;
        PremisesId = premisesId;
        ReservationTime = reservationTime;

        Status = ReservationStatus.Pending;
    }

    public void Approve(Id approverId)
    {
        Status = ReservationStatus.Approved;
        ApprovedBy = approverId;
        RejectedReason = null;
    }

    public void Reject(Id approverId, string reason)
    {
        if (string.IsNullOrWhiteSpace(reason))
        {
            throw new ArgumentException(
                "A rejection reason is required.",
                nameof(reason));
        }

        Status = ReservationStatus.Rejected;
        ApprovedBy = approverId;
        RejectedReason = reason;
    }
}

public enum ReservationStatus
{
    Pending,
    PendingReview,
    Approved,
    Rejected
}