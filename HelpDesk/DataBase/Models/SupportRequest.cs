using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataBase.Models
{
	public class SupportRequest
	{
		public Guid Id { get; set; }


		public Guid CreatorId { get; set; }
        public string CreatorName { get; set; }
        public string CreatorEmail { get; set; }
        public DateTime Created { get; set; }


		public string Name { get; set; }
		public string Description { get; set; }
		public Category Category { get; set; }



		public Status Status { get; set; }
		public DateTime? InWork { get; set; }
		public DateTime? Done { get; set; }


		public Guid? PerformerId { get; set; }
        public Guid PerformerName { get; set; }


    }


}
