using Zamin.Core.RequestResponse.Commands;

namespace Sampel.RestAPI.Core.RequestResponse.RestApiDemos.Commands.Create
{
    public class RestApiDemoCreateCommand : ICommand<int>
    {
        public required string LastName { get; set; }
        public required string FirstName { get; set; }
        public required string NationalId { get; set; }
        public required string PhoneNumber { get; set; }
    }
}
