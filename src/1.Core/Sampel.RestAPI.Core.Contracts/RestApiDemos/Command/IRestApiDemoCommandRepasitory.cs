using Sampel.RestAPI.Core.Domain.RestApiDemos.Entities;
using Zamin.Core.Contracts.Data.Commands;

namespace Sampel.RestAPI.Core.Contracts.RestApiDemos.Command
{
    public interface IRestApiDemoCommandRepasitory : ICommandRepository<RestApiDemo, int>
    {
    }
}
