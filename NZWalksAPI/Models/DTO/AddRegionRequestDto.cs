using System.ComponentModel.DataAnnotations;

namespace NZWalksAPI.Models.DTO;

public class AddRegionRequestDto
{
    [Required]
    [MinLength(3, ErrorMessage = "Code has to be a minimum of 3 characters")]
    [MaxLength(3, ErrorMessage = "Code has to be a miximum of 3 characters")]
    public string Code { get; set; }
      
    [Required]
    [MinLength(2, ErrorMessage = "Name has to be a minimum of 2 characters")]
    [MaxLength(100, ErrorMessage = "Name has to be a miximum of 100 characters")]
    public string Name { get; set; }
        
    public string? RegionImageUrl { get; set; }
}