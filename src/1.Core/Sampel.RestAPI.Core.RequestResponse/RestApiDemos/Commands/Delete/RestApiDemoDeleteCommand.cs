using Zamin.Core.RequestResponse.Commands;

namespace Sampel.RestAPI.Core.RequestResponse.RestApiDemos.Commands.Delete
{
    public class RestApiDemoDeleteCommand : ICommand
    {
        public required int Id { get; set; }

    }
}
