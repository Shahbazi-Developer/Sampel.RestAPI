using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sampel.RestAPI.Core.Domain.RestApiDemos.Entities;
using Sampel.RestAPI.SharedKernel.Translators;

namespace Sampel.RestAPI.Infra.Data.Sql.Commands.RestApiDemos.Configs
{
    public class RestApiDemoConfig : IEntityTypeConfiguration<RestApiDemo>
    {
        public void Configure(EntityTypeBuilder<RestApiDemo> builder)
        {
            builder.ToTable("RestApiDemos");
            builder.HasKey(x => x.Id);

            builder.OwnsOne(p => p.NationalId, builderAction =>
            {
                builderAction.Property(p1 => p1.Value).HasColumnName("NationalId");
            });

            builder.OwnsOne(p => p.Deleted, builderAction =>
            {
                builderAction.Property(p1 => p1.Value).HasColumnName(nameof(RestApiDemo.Deleted));
            });

            builder.Property(c => c.LastName).IsRequired(false).HasMaxLength(MaxLengthConfiguration.NAME_LAB_MAXLENGTHS).HasColumnName(nameof(RestApiDemo.LastName));
            builder.Property(c => c.FirstName).IsRequired(false).HasMaxLength(MaxLengthConfiguration.NAME_LAB_MAXLENGTHS).HasColumnName(nameof(RestApiDemo.FirstName));
            builder.Property(c => c.PhoneNumber).IsRequired(false).HasMaxLength(MaxLengthConfiguration.TEL_NO_MAXLENGTHS).HasColumnName(nameof(RestApiDemo.PhoneNumber));
        }
    }
}
