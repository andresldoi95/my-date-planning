using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyDatePlanningData.Entities
{
    public class Place
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public required string Name { get; set; }
        public string? Description { get; set; }
        public string? Address { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Website { get; set; }
        public string? Email { get; set; }
        public string? Instagram { get; set; }
        public string? Facebook { get; set; }
        public string? Twitter { get; set; }
        public string? TikTok { get; set; }
        public string? YouTube { get; set; }
        public string? Picture { get; set; }
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }
        public bool IsActive { get; set; } = true;
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime? UpdatedDate { get; set; }
        public int? CreatedBy { get; set; }
        [ForeignKey(nameof(CreatedBy))]
        public User? Creator { get; set; }
        public int? UpdatedBy { get; set; }
        [ForeignKey(nameof(UpdatedBy))]
        public User? Updater { get; set; }
        public int? PlaceTypeId { get; set; }
        [ForeignKey(nameof(PlaceTypeId))]
        public PlaceType? PlaceType { get; set; }
    }
}
