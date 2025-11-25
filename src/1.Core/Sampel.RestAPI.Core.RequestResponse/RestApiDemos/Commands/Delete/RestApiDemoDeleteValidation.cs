using FluentValidation;
using Sampel.RestAPI.SharedKernel.Translators;
using Zamin.Extensions.Translations.Abstractions;

namespace Sampel.RestAPI.Core.RequestResponse.RestApiDemos.Commands.Delete
{
    public class RestApiDemoDeleteValidation : AbstractValidator<RestApiDemoDeleteCommand>
    {
        public RestApiDemoDeleteValidation(ITranslator translator)
        {
            RuleFor(x => x.Id)
           .NotEmpty()
           .WithMessage(translator[TranslatorKeys.VALIDATION_ERROR_NOT_EMPTY, nameof(RestApiDemoDeleteCommand.Id)]);
        }
    }
}
