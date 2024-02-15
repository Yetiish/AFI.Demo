namespace AFI.Demo.ViewModels;

public abstract class UserBase
{
    /// <summary>
    /// The user's first name.
    /// </summary>
    public string? FirstName { get; set; }

    /// <summary>
    /// The user's last name.
    /// </summary>
    public string? Surname { get; set; }

    /// <summary>
    /// The user's email address.
    /// </summary>
    public string? Email { get; set; }

    /// <summary>
    /// The user's policy reference number.
    /// </summary>
    public string? PolicyReference { get; set; }

    /// <summary>
    /// The user's date of birth.
    /// </summary>
    public DateTime? DateOfBirth { get; set; }
}
