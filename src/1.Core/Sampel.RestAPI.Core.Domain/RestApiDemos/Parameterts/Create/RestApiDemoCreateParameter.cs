using Sampel.RestAPI.Core.Domain.RestApiDemos.ValueObjects;

namespace Sampel.RestAPI.Core.Domain.RestApiDemos.Parameterts.Create
{
    public sealed record RestApiDemoCreateParameter(string lastName,
                                                    string firstName,
                                                    string phoneNumber,
                                                    NationalId nationalId);
  
}
