using Microsoft.Extensions.Logging;
using Sampel.RestAPI.Core.Contracts.RestApiDemos.Command;
using Sampel.RestAPI.Core.RequestResponse.RestApiDemos.Commands.Delete;
using Sampel.RestAPI.SharedKernel.Translators;
using Zamin.Core.ApplicationServices.Commands;
using Zamin.Core.Domain.Exceptions;
using Zamin.Core.RequestResponse.Commands;
using Zamin.Extensions.Translations.Abstractions;
using Zamin.Utilities;

namespace Sampel.RestAPI.Core.ApplicationService.RestApiDemos.Commands.Delete
{
    public class RestApiDemoDeleteCommandHandler : CommandHandler<RestApiDemoDeleteCommand>
    {
        private readonly IRestApiDemoCommandRepasitory _restApiDemoCommandRepasitory;
        private readonly ILogger<RestApiDemoDeleteCommandHandler> _logger;
        private readonly ITranslator _translator;

        public RestApiDemoDeleteCommandHandler(ZaminServices zaminServices, ILogger<RestApiDemoDeleteCommandHandler> logger, IRestApiDemoCommandRepasitory restApiDemoCommandRepasitory, ITranslator translator) : base(zaminServices)
        {
            _logger = logger;
            _restApiDemoCommandRepasitory = restApiDemoCommandRepasitory;
            _translator = translator;
        }

        public override async Task<CommandResult> Handle(RestApiDemoDeleteCommand command)
        {
            Domain.RestApiDemos.Entities.RestApiDemo entity = await _restApiDemoCommandRepasitory.GetAsync(command.Id);

            if (entity is null)
            {
                _logger.Log(LogLevel.Information, _translator[TranslatorKeys.HANDLER_RUN_LOG, GetType().Name]);

                throw new InvalidEntityStateException(_translator[TranslatorKeys.VALIDATION_ERROR_NOT_EXIST, nameof(command.Id)]);
            }

            _restApiDemoCommandRepasitory.Delete(entity);

            await _restApiDemoCommandRepasitory.CommitAsync();

            return Ok();
        }
    }
}
