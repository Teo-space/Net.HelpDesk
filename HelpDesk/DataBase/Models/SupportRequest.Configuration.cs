namespace DataBase.Models
{
	public class SupportRequestConfiguration : IEntityTypeConfiguration<SupportRequest>
	{
		public void Configure(EntityTypeBuilder<SupportRequest> builder)
		{
			builder.ToTable("Jobs");

			builder.HasKey(x => x.Id);
			builder.HasIndex(x => x.Id);
			builder.Property(x => x.Id).ValueGeneratedOnAdd();

			builder.Property(x => x.CreatorId).IsRequired();

			builder.Property(x => x.Created).IsRequired();
			builder.Property(x => x.Name).IsRequired();
			builder.Property(x => x.Description).IsRequired();
			builder.Property(x => x.Category).IsRequired();
			builder.Property(x => x.Category).IsRequired().HasDefaultValue(Status.Pending);

		}
	}

}
