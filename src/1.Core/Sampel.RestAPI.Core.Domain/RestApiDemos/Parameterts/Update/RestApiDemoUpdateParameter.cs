using Sampel.RestAPI.Core.Domain.RestApiDemos.ValueObjects;

namespace Sampel.RestAPI.Core.Domain.RestApiDemos.Parameterts.Update
{
    public sealed record RestApiDemoUpdateParameter(string lastName,
                                                    string firstName,
                                                    string phoneNumber,
                                                    NationalId nationalId);
   
}
