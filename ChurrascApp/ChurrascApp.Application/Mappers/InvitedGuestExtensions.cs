using ChurrascApp.Domain.Entities;
using ChurrascApp.Domain.Value_Objects;

namespace ChurrascApp.Application;

public static class InvitedGuestExtensions
{
    public static Guest ToGuest(this Participant participant)
    {
        return new Guest(
            participant.UserId,
             participant.FullName,
              participant.PhoneNumber
        );
    }

    public static ConfirmedGuest ToConfirmedGuest(this Participant participant)
    {
        var contribution = participant.ContributedAmount != null ?
                    new Contribution
                    {
                        ConfirmedPayment = participant.ContributedAmount.IsPaid,
                        Item = participant.AssignedItems != null && participant.AssignedItems.Any()
                               ? string.Join(", ", participant.AssignedItems.Select(ai => ai.Name))
                               : "No item assigned"
                    } : null;

        return new ConfirmedGuest(participant.UserId, participant.FullName, participant.PhoneNumber, contribution!, participant.ParticipantInExtraActivity ?? false || true);
    }
}
