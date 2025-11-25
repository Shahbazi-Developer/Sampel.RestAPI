using FluentValidation;
using Sampel.RestAPI.SharedKernel.Translators;
using Zamin.Extensions.Translations.Abstractions;

namespace Sampel.RestAPI.Core.RequestResponse.RestApiDemos.Queries.GetById
{
    public class RestApiDemoGetByIdValidation : AbstractValidator<RestApiDemoGetByIdQuery>
    {
        public RestApiDemoGetByIdValidation(ITranslator translator)
    {
        RuleFor(x => x.Id)
             .NotEmpty()
             .WithMessage(translator[TranslatorKeys.VALIDATION_ERROR_NOT_EMPTY, nameof(RestApiDemoGetByIdQuery.Id)]);
    }

    }
}
