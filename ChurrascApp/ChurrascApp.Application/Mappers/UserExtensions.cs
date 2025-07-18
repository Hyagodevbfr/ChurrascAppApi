using ChurrascApp.Application.DTOs.User;
using ChurrascApp.Domain.Entities;
using ChurrascApp.Domain.Value_Objects;

namespace ChurrascApp.Application.Mappers;

public static class UserExtensions
{
    public static UserResponseDto ToResponse(this User user)
    {
        return new UserResponseDto(
            user.Id,
            $"{user.PersonalInfo.FirstName} {user.PersonalInfo.LastName}",
            user.PersonalInfo.Cpf.Number,
            user.ContactInfo.PhoneNumber.Number,
            user.ContactInfo.EmailAddress.Email
        );
    }
    public static User ToEntity(this UserRegisterDto userRegisterDto, string password)
    {
        var cpf = new Cpf(userRegisterDto.Cpf);
        var phoneNumber = new PhoneNumber(userRegisterDto.PhoneNumber);
        var emailAddress = new EmailAddress(userRegisterDto.Email);
        
        var personalInfo = new PersonalInfo(userRegisterDto.FirstName, userRegisterDto.LastName, cpf);
        var contactInfo = new ContactInfo(emailAddress, phoneNumber);
        
        return new User(
            personalInfo,
            contactInfo,
            password
        );
    }

    public static UserUpdateDto ToUpdate(this User user)
    {
        return new UserUpdateDto(
            Id: user.Id,
            FirstName: user.PersonalInfo.FirstName,
            LastName: user.PersonalInfo.LastName,
            Cpf: user.PersonalInfo.Cpf.Number,
            PhoneNumber: user.ContactInfo.PhoneNumber.Number,
            Email: user.ContactInfo.EmailAddress.Email,
            Password: user.Password
            );
    }
}