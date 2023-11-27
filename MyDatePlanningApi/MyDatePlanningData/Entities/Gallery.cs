﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyDatePlanningData.Entities
{
    public class Gallery
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public required int PlaceId { get; set; }
        public required string Description { get; set; }
        [ForeignKey(nameof(PlaceId))]
        public Place? Place { get; set; }
        public required int UserId { get; set; }
        [ForeignKey(nameof(UserId))]
        public User? User { get; set; }
        public required string Picture { get; set; }
        public bool IsActive { get; set; } = true;
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime? UpdatedDate { get; set; }
    }
}
