using ContactsApp.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ContactsApp.DAL.Configurations
{
    class PhoneConfig : IEntityTypeConfiguration<Phone>
    {
        public void Configure(EntityTypeBuilder<Phone> builder)
        {
            builder.Property(p => p.Type)
                .IsRequired()
                .HasMaxLength(25);

            builder.Property(p => p.Number)
                .IsRequired()
                .HasMaxLength(25);

            builder.Property(p => p.ContactId)
                .IsRequired();

            builder.HasOne(p => p.Contact)
                .WithMany(c => c.Phones)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
