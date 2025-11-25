using FluentValidation;
using Sampel.RestAPI.SharedKernel.Translators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zamin.Extensions.Translations.Abstractions;

namespace Sampel.RestAPI.Core.RequestResponse.RestApiDemos.Commands.Create
{
    public sealed class RestApiDemoCreateValidation : AbstractValidator<RestApiDemoCreateCommand>
    {
        public RestApiDemoCreateValidation(ITranslator translator)
        {
            RuleFor(x => x.FirstName)
               .NotEmpty()
               .WithMessage(translator[TranslatorKeys.VALIDATION_ERROR_NOT_EMPTY, nameof(RestApiDemoCreateCommand.FirstName)])
               .MaximumLength(MaxLengthConfiguration.FIRSTNAME_MAXLENGTHS)
               .WithMessage(translator[TranslatorKeys.VALIDATION_ERROR_MAX_LENGTH, nameof(RestApiDemoCreateCommand.FirstName)])
               .MinimumLength(MaxLengthConfiguration.FIRSTNAME_MINLENGTHS)
               .WithMessage(translator[TranslatorKeys.VALIDATION_ERROR_MIN_LENGTH, nameof(RestApiDemoCreateCommand.FirstName)]);

            RuleFor(x => x.LastName)
                .NotEmpty()
                .WithMessage(translator[TranslatorKeys.VALIDATION_ERROR_NOT_EMPTY, nameof(RestApiDemoCreateCommand.LastName)])
                .MaximumLength(MaxLengthConfiguration.LASTNAME_MAXLENGTHS)
                .WithMessage(translator[TranslatorKeys.VALIDATION_ERROR_MAX_LENGTH, nameof(RestApiDemoCreateCommand.LastName)])
                .MinimumLength(MaxLengthConfiguration.LASTNAME_MINLENGTHS)
                .WithMessage(translator[TranslatorKeys.VALIDATION_ERROR_MIN_LENGTH, nameof(RestApiDemoCreateCommand.LastName)]);

            RuleFor(x => x.NationalId)
                .NotEmpty()
                .WithMessage(translator[TranslatorKeys.VALIDATION_ERROR_NOT_EMPTY, nameof(RestApiDemoCreateCommand.NationalId)])
                .MinimumLength(MaxLengthConfiguration.NATIONAL_FOR_ID_MINLENGTHS)
                .WithMessage(translator[TranslatorKeys.VALIDATION_ERROR_MIN_LENGTH, nameof(RestApiDemoCreateCommand.NationalId)
                                       , MaxLengthConfiguration.NATIONAL_FOR_ID_MINLENGTHS.ToString()])
                .MaximumLength(MaxLengthConfiguration.NATIONAL_ID_MAXLENGTHS)
                .WithMessage(translator[TranslatorKeys.VALIDATION_ERROR_MAX_LENGTH, nameof(RestApiDemoCreateCommand.NationalId)
                                      , MaxLengthConfiguration.NATIONAL_ID_MAXLENGTHS.ToString()]);


            RuleFor(x => x.PhoneNumber)
                .NotEmpty()
                .WithMessage(translator[TranslatorKeys.VALIDATION_ERROR_NOT_EXIST, nameof(RestApiDemoCreateCommand.PhoneNumber)])
                .Matches(@"^09(0[1-3]|1[0-9]|2[0-2]|3[0-9]|9[0-9])\d{7}$")
                .WithMessage(translator[TranslatorKeys.VALIDATION_ERROR_INVALID_FORMAT, nameof(RestApiDemoCreateCommand.PhoneNumber)]);
        }
    }
}
