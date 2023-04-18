namespace Kyle.Members.Application.Constructs.Dtos;

public class LoginOutputDto
{
    public string Key { get; set; }

    public int ExpiresTime { get; set; }

    public long UserId { get; set; }
}