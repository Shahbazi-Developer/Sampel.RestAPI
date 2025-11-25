using Sampel.RestAPI.Core.Domain.RestApiDemos.Parameterts.Create;
using Sampel.RestAPI.Core.Domain.RestApiDemos.Parameterts.Update;
using Sampel.RestAPI.Core.RequestResponse.RestApiDemos.Commands.Create;
using Sampel.RestAPI.Core.RequestResponse.RestApiDemos.Commands.Update;

namespace Sampel.RestAPI.Core.ApplicationService.RestApiDemos.Mappers
{
    public static class RestApiDemoMapper
    {
        public static RestApiDemoCreateParameter ToParameter(this RestApiDemoCreateCommand command)
       => new RestApiDemoCreateParameter(lastName: command.LastName, firstName: command.FirstName, nationalId: command.NationalId, phoneNumber: command.PhoneNumber);

        public static RestApiDemoUpdateParameter ToParameter(this RestApiDemoUpdateCommand command)
            => new RestApiDemoUpdateParameter(lastName: command.LastName, firstName: command.FirstName, nationalId: command.NationalId, phoneNumber: command.PhoneNumber);
    }
}
