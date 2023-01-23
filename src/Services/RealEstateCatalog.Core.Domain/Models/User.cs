namespace RealEstateCatalog.Core.Domain.Models;

#nullable disable
public class User : BaseEntity
{
    public string Username { get; set; }
    public byte[] Password { get; set; }
    public byte[] PasswordKey { get; set; }
}
