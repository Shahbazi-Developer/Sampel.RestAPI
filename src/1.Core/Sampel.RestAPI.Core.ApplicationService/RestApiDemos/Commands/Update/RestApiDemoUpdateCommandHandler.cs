using Microsoft.Extensions.Logging;
using Sampel.RestAPI.Core.ApplicationService.RestApiDemos.Mappers;
using Sampel.RestAPI.Core.Contracts.RestApiDemos.Command;
using Sampel.RestAPI.Core.RequestResponse.RestApiDemos.Commands.Update;
using Sampel.RestAPI.SharedKernel.Translators;
using Zamin.Core.ApplicationServices.Commands;
using Zamin.Core.Domain.Exceptions;
using Zamin.Core.RequestResponse.Commands;
using Zamin.Extensions.Translations.Abstractions;
using Zamin.Utilities;

namespace Sampel.RestAPI.Core.ApplicationService.RestApiDemos.Commands.Update
{
    public class RestApiDemoUpdateCommandHandler : CommandHandler<RestApiDemoUpdateCommand>
    {
        private readonly IRestApiDemoCommandRepasitory _restApiDemoCommandRepasitory;
        private readonly ILogger<RestApiDemoUpdateCommandHandler> _logger;
        private readonly ITranslator _translator;

        public RestApiDemoUpdateCommandHandler(ZaminServices zaminServices ,ITranslator translator, ILogger<RestApiDemoUpdateCommandHandler> logger, IRestApiDemoCommandRepasitory restApiDemoCommandRepasitory) : base(zaminServices) 
        {
            _translator = translator;
            _logger = logger;
            _restApiDemoCommandRepasitory = restApiDemoCommandRepasitory;
        }

        public override async Task<CommandResult> Handle(RestApiDemoUpdateCommand command)
        {
            var entity = await _restApiDemoCommandRepasitory.GetAsync(command.Id);

            if (entity is null)
            {
                _logger.Log(LogLevel.Information, _translator[TranslatorKeys.HANDLER_RUN_LOG, GetType().Name]);

                throw new InvalidEntityStateException(_translator[TranslatorKeys.VALIDATION_ERROR_NOT_EXIST, nameof(command.Id)]);

            }

            entity.Update(command.ToParameter());
            await _restApiDemoCommandRepasitory.CommitAsync();

            return Ok();
        }
    }
}
