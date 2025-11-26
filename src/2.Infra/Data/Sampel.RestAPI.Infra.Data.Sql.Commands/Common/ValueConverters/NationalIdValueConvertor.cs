using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Sampel.RestAPI.Core.Domain.RestApiDemos.ValueObjects;

namespace Sampel.RestAPI.Infra.Data.Sql.Commands.Common.ValueConverters
{
    public class NationalIdValueConvertor : ValueConverter<NationalId, string>
    {
        public NationalIdValueConvertor() : base(n => n.Value, p => new(p))
        {

        }
    }
}
