using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Sampel.RestAPI.Core.Domain.RestApiDemos.ValueObjects;

namespace Sampel.RestAPI.Infra.Data.Sql.Commands.Common.ValueConverters
{
    public class DeletedValueConverter : ValueConverter<Deleted, bool>
    {
        public DeletedValueConverter() : base(m => m.Value, p => new(p))
        {
        }
    }
        
}
