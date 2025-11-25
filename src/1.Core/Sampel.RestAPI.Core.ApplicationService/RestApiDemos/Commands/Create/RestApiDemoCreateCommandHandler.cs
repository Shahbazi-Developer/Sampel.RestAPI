using Microsoft.Extensions.Logging;
using Sampel.RestAPI.Core.ApplicationService.RestApiDemos.Mappers;
using Sampel.RestAPI.Core.Contracts.RestApiDemos.Command;
using Sampel.RestAPI.Core.Domain.RestApiDemos.Entities;
using Sampel.RestAPI.Core.RequestResponse.RestApiDemos.Commands.Create;
using Zamin.Core.ApplicationServices.Commands;
using Zamin.Core.RequestResponse.Commands;
using Zamin.Extensions.Translations.Abstractions;
using Zamin.Utilities;

namespace Sampel.RestAPI.Core.ApplicationService.RestApiDemos.Commands.Create
{
    public class RestApiDemoCreateCommandHandler : CommandHandler<RestApiDemoCreateCommand, int>
    {
        private readonly IRestApiDemoCommandRepasitory _restApiDemoCommandRepasitory;
        private readonly ILogger<RestApiDemoCreateCommandHandler> _logger;
        private readonly ITranslator _translator;

        public RestApiDemoCreateCommandHandler(ZaminServices zaminServices, IRestApiDemoCommandRepasitory restApiDemoCommandRepasitory, ILogger<RestApiDemoCreateCommandHandler> logger, ITranslator translator) : base(zaminServices)
        {
            _restApiDemoCommandRepasitory = restApiDemoCommandRepasitory;
            _logger = logger;
            _translator = translator;
        }

        public override async Task<CommandResult<int>> Handle(RestApiDemoCreateCommand command)
        {
            var entity = new RestApiDemo(command.ToParameter());

            await _restApiDemoCommandRepasitory.InsertAsync(entity);
            await _restApiDemoCommandRepasitory.CommitAsync();

            return Ok(entity.Id);
        }
    }
}
