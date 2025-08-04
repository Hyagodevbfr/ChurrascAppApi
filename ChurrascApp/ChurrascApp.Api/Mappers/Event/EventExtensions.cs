using ChurrascApp.Api.Models.Requests;
using ChurrascApp.Api.Models.Responses.Event;
using ChurrascApp.Application.DTOs.Event;
using ChurrascApp.Domain.Value_Objects;

namespace ChurrascApp.Api.Mappers.Event;

public static class EventExtensions
{
    // Register extensions
    public static EventResponse ToResponse(this EventResponseDto dto)
    {
        var basicInfo = new EventBasicInfo(
            dto.BasicInfo.Name,
            dto.BasicInfo.Description!,
            dto.BasicInfo.DateAndTime,
            dto.BasicInfo.EventLocation
        );
        var organizer = new EventOrganizer(
            dto.Organizer!.Id,
            dto.Organizer.Name,
            dto.Organizer.Number
        );
        var extraActivity = new ExtraActivity(
            dto.ExtraActivity!.Name,
            dto.ExtraActivity.Description,
            dto.ExtraActivity.TotalCost
        );
        var requiredItems = dto.RequiredItems?.Select(item => new RequiredItem(
            item.Name,
            item.RequiredQuantity,
            item.AssignedQuantity,
            item.AssignedUsers
        )).ToList();
        var totalCost = new TotalCost(dto.TotalCost.Value);
        var invitedGuests = dto.InvitedGuests.Select(guest => new Guest(
            guest.Id,
            guest.Name,
            guest.PhoneNumber
        )).ToList();
        var confirmedGuests = dto.ConfirmedGuests.Select(guest => new ConfirmedGuest(
            guest.UserId,
            guest.Name,
            guest.PhoneNumber,
            guest.Contribution,
            guest.IsInExtraActivity
        )).ToList();
        
        return new EventResponse{
            BasicInfo = basicInfo,
            Organizer = organizer,
            HasExtraActivities = dto.HasExtraActivities,
            HasRequiredItems = dto.HasRequiredItems,
            RequiredItems = requiredItems,
            ExtraActivity = extraActivity,
            ContributionType = dto.ContributionType,
            TotalCost = totalCost,
            InviteCode = dto.InviteCode,
            LimitedGuests = dto.LimitedGuests,
            NumberOfGuests = dto.NumberOfGuests,
            InvitedGuests = invitedGuests,
            ConfirmedGuests = confirmedGuests
        };
    }

    public static EventRegisterDto ToDto(this EventRegisterRequest request)
    {
        return new EventRegisterDto
        (
            request.BasicInfo,
            request.Organizer,
            request.HasExtraActivities,
            request.ExtraActivity,
            request.HasRequiredItems,
            request.RequiredItems,
            request.ContributionType,
            request.TotalCost,
            request.InviteCode,
            request.LimitedGuests,
            request.NumberOfGuests,
            request.InvitedGuests,
            request.ConfirmedGuests
        );
    }
}
