using BookstoreApi.Core.Domain;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace BookstoreApi.Persistence.EntityConfigurations
{
    public class BookConfiguration : EntityTypeConfiguration<Book>
    {
        public BookConfiguration()
        {

            HasKey(b => b.Id);

            Property(b => b.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);


            Property(c => c.Description)
                .IsRequired()
                .HasMaxLength(2000);

            Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(255);

            HasRequired(c => c.PublishingHouse)
            .WithMany(a => a.Books)
            .HasForeignKey(c => c.PublishingHouseId)
            .WillCascadeOnDelete(false);

            HasRequired(c => c.Cover)
                .WithRequiredPrincipal(c => c.Book);

            HasMany(c => c.Authors)
            .WithMany(t => t.Books)
            .Map(m =>
            {
                m.ToTable("BookAuthors");
                m.MapLeftKey("BookId");
                m.MapRightKey("AuthorId");
            });
        }
    }
}