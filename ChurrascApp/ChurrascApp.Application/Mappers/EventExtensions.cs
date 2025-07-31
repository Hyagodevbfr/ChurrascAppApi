using ChurrascApp.Application.DTOs.Event;
using ChurrascApp.Domain.Entities;
using ChurrascApp.Domain.Value_Objects;

namespace ChurrascApp.Application.Mappers;

public static class EventExtensions
{
    // Converts an EventResponseDto to an Event entity
    public static Event ToEntity(this EventResponseDto responseDto)
    {
        var basicInfo = new EventBasicInfo(
            responseDto.BasicInfo.Name,
            responseDto.BasicInfo.Description!,
            responseDto.BasicInfo.DateAndTime,
            responseDto.BasicInfo.EventLocation
        );
        var organizer = new EventOrganizer(
            responseDto.Organizer!.Id,
            responseDto.Organizer.Name,
            responseDto.Organizer.Number
        );
        var extraActivity = new ExtraActivity(
            responseDto.ExtraActivity!.Name,
            responseDto.ExtraActivity.Description,
            responseDto.ExtraActivity.TotalCost
        );
        var requiredItems = responseDto.RequiredItems?.Select(item => new RequiredItem(
            item.Name,
            item.RequiredQuantity,
            item.AssignedQuantity,
            item.AssignedUsers
        )).ToList();
        var totalCost = new TotalCost(responseDto.TotalCost.Value);
        var invitedGuests = responseDto.InvitedGuests.Select(guest => new Guest(
            guest.Id,
            guest.Name,
            guest.PhoneNumber
        )).ToList();
        var confirmedGuests = responseDto.ConfirmedGuests.Select(guest => new ConfirmedGuest(
            guest.UserId,
            guest.Name,
            guest.PhoneNumber,
            guest.Contribution,
            guest.IsInExtraActivity
        )).ToList();

        return new Event(
            basicInfo,
            organizer,
            responseDto.HasExtraActivities,
            responseDto.HasRequiredItems,
            requiredItems,
            extraActivity,
            responseDto.ContributionType,
            totalCost,
            responseDto.LimitedGuests,
            responseDto.NumberOfGuests,
            invitedGuests,
            confirmedGuests
        );
    }

    // Converts an Event entity to an EventResponseDto
    public static EventResponseDto ToResponse(this Event entity)
    {
        return new EventResponseDto(
            entity.Id,
            entity.BasicInfo,
            entity.Organizer,
            entity.HasExtraActivities,
            entity.ExtraActivity,
            entity.HasRequiredItems,
            entity.RequiredItems,
            entity.ContributionType,
            entity.TotalCost,
            entity.InviteCode,
            entity.LimitedGuests,
            entity.NumberOfGuests,
            entity.InvitedGuests,
            entity.ConfirmedGuests
        );
    }

    // Converts an EventRegisterDto to an Event entity
    public static Event ToEntity(this EventRegisterDto registerDto)
    {
        var basicInfo = new EventBasicInfo(
            registerDto.BasicInfo.Name,
            registerDto.BasicInfo.Description!,
            registerDto.BasicInfo.DateAndTime,
            registerDto.BasicInfo.EventLocation
        );
        var organizer = new EventOrganizer(
            registerDto.Organizer!.Id,
            registerDto.Organizer.Name,
            registerDto.Organizer.Number
        );
        var extraActivity = new ExtraActivity(
            registerDto.ExtraActivity!.Name,
            registerDto.ExtraActivity.Description,
            registerDto.ExtraActivity.TotalCost
        );
        var requiredItems = registerDto.RequiredItems?.Select(item => new RequiredItem(
            item.Name,
            item.RequiredQuantity,
            item.AssignedQuantity,
            item.AssignedUsers
        )).ToList();
        var totalCost = new TotalCost(registerDto.TotalCost.Value);
        var invitedGuests = registerDto.InvitedGuests.Select(guest => new Guest(
            guest.Id,
            guest.Name,
            guest.PhoneNumber
        )).ToList();
        var confirmedGuests = registerDto.ConfirmedGuests.Select(guest => new ConfirmedGuest(
            guest.UserId,
            guest.Name,
            guest.PhoneNumber,
            guest.Contribution,
            guest.IsInExtraActivity
        )).ToList();

        return new Event(
            basicInfo,
            organizer,
            registerDto.HasExtraActivities,
            registerDto.HasRequiredItems,
            requiredItems,
            extraActivity,
            registerDto.ContributionType,
            totalCost,
            registerDto.LimitedGuests,
            registerDto.NumberOfGuests,
            invitedGuests,
            confirmedGuests
        );
    }

    // Converts an Event Entity to an EventUpdateDto
    public static EventUpdateDto ToUpdate(this Event entity)
    {
        return new EventUpdateDto(
            Id: entity.Id,
            BasicInfo: entity.BasicInfo,
            Organizer: entity.Organizer,
            HasExtraActivities: entity.HasExtraActivities,
            ExtraActivity: entity.ExtraActivity,
            HasRequiredItems: entity.HasRequiredItems,
            RequiredItems: entity.RequiredItems,
            ContributionType: entity.ContributionType,
            TotalCost: entity.TotalCost,
            InviteCode: entity.InviteCode,
            LimitedGuests: entity.LimitedGuests,
            NumberOfGuests: entity.NumberOfGuests,
            InvitedGuests: entity.InvitedGuests,
            ConfirmedGuests: entity.ConfirmedGuests
        );
    }
}

