namespace JobSearch.Application.DTOs.Identity;

public class UserCreateDto(
    string userName,
    string email,
    string password,
    string phoneNumber,
    string firstName,
    string lastName)
{
    public string UserName { get; init; } = userName;
    public string Email { get; init; } = email;
    public string Password { get; init; } = password;
    public string PhoneNumber { get; init; } = phoneNumber;
    public string FirstName { get; init; } = firstName;
    public string LastName { get; init; } = lastName;
}