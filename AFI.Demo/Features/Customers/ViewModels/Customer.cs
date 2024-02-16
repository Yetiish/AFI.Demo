using AFI.Demo.Features.Customers.Models;

namespace AFI.Demo.Features.Customers.ViewModels
{
    /// <summary>
    /// The customer's details.
    /// </summary>
    public class Customer : CustomerBase
    {
        /// <summary>
        /// The customer's unique identifier.
        /// </summary>
        public int Id { get; set; }
    }
}
