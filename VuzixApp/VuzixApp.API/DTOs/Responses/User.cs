namespace VuzixApp.API.DTOs.Responses;

public class User
{
	public string Id { get; }
	public string Email { get; }
	public string Name { get; }
	public string Surname { get; }
	public string ProfilePicture { get; }

	public User(Models.User user)
	{
		Id = user.Id ?? throw new ArgumentNullException("Id is null");
		Email = user.Email;
		Name = user.Name;
		Surname = user.Surname;
		ProfilePicture = user.ProfilePicture;
	}
}