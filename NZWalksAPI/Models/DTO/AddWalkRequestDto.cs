using System.ComponentModel.DataAnnotations;

namespace NZWalksAPI.Models.DTO
{
    public class AddWalkRequestDto
    {
        [Required]
        [MinLength(2, ErrorMessage = "Name has to be a minimum of 2 characters")]
        [MaxLength(1000, ErrorMessage = "Name has to be a miximum of 1000 characters")]
        public string Name { get; set; }
        
        [Required]
        [MaxLength(1000)]
        public string Description { get; set; }
        
        [Required]
        [Range(0,50)]
        public double LengthInKm { get; set; }
        
        public string? WalkImageUrl { get; set; }
        
        [Required]
        public Guid DifficultyId { get; set; }
        
        [Required]
        public Guid RegionId { get; set; }

    }
}

