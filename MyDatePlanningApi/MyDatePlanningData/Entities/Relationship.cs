using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyDatePlanningData.Entities
{
    public class Relationship
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int? UserId { get; set; }
        [ForeignKey(nameof(UserId))]
        public User? User { get; set; }
        public int? CoupleId { get; set; }
        [ForeignKey(nameof(CoupleId))]
        public User? Couple { get; set; }
        public bool IsActive { get; set; } = true;
        public bool IsConfirmed { get; set; } = false;
        public DateOnly? AnniversaryDate { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime? UpdatedDate { get; set; }
    }
}
