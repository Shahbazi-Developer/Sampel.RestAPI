using Sampel.RestAPI.Core.Domain.RestApiDemos.Parameterts.Create;
using Sampel.RestAPI.Core.Domain.RestApiDemos.Parameterts.Update;
using Sampel.RestAPI.Core.Domain.RestApiDemos.ValueObjects;
using System.Reflection.Emit;
using Zamin.Core.Domain.Entities;

namespace Sampel.RestAPI.Core.Domain.RestApiDemos.Entities
{
    public class RestApiDemo : AggregateRoot<int>
    {
        public string? LastName { get; private set; }
        public string? FirstName { get; private set; }
        public NationalId? NationalId { get; private set; }
        public string? PhoneNumber { get; private set; }
        public Deleted Deleted { get; private set; }

        private RestApiDemo()
        { }


        public RestApiDemo(RestApiDemoCreateParameter parameter)
        {
            LastName = parameter.lastName;
            FirstName = parameter.firstName;
            PhoneNumber = parameter.phoneNumber;
            NationalId = parameter.nationalId;
            PhoneNumber = parameter.phoneNumber;
        }

        public void Update(RestApiDemoUpdateParameter parameter)
        {
            LastName = parameter.lastName;
            FirstName = parameter.firstName;
            PhoneNumber = parameter.phoneNumber;
            NationalId = parameter.nationalId;
            PhoneNumber = parameter.phoneNumber;
        }

        public void Delete()
        {
            Deleted = new(true);
        }

    }
}
