namespace AFI.Demo.Features.Customers.Models;

public abstract class CustomerBase
{
    /// <summary>
    /// The customer's first name.
    /// </summary>
    public string? FirstName { get; set; }

    /// <summary>
    /// The customer's last name.
    /// </summary>
    public string? Surname { get; set; }

    /// <summary>
    /// The customer's email address.
    /// </summary>
    public string? Email { get; set; }

    /// <summary>
    /// The customer's policy reference number.
    /// </summary>
    public string? PolicyReference { get; set; }

    /// <summary>
    /// The customer's date of birth.
    /// </summary>
    public DateTime? DateOfBirth { get; set; }
}
