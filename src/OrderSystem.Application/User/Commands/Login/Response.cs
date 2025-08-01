namespace OrderSystem.Application.User.Commands.Login;
public class Response
{
    public string AccessToken { get; set; } = null!;
    public string RefreshToken { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string FullName { get; set; } = null!;
}
