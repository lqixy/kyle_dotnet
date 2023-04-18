namespace Kyle.Members.Application.Constructs.Dtos;

public class MemberDto
{
    public MemberDto()
    {
    }

    public MemberDto(long id, string password, string account=default, string email = default, string mobile=default)
    {
        Id = id;
        Account = account;
        Email = email;
        Mobile = mobile;
        Password = password;
        CreationTime = DateTime.Now;
    }

    public long Id { get; set; }

    public string Account { get; set; }

    public string UserName { get; set; }

    public string Email { get; set; }

    public string Mobile { get; set; }
    public string Password { get; set; }

    public bool Deleted { get; set; }

    public DateTime CreationTime { get; set; }
}