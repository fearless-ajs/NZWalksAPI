using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NZWalksAPI.CustomActionFilters;
using NZWalksAPI.Models.Domain;
using NZWalksAPI.Models.DTO;
using NZWalksAPI.Repositories;

namespace NZWalksAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegionsController(IRegionRepository regionRepository, IMapper mapper) : ControllerBase
    {
        // GET ALL REGIONS
        [HttpGet]
        [Authorize(Roles = "Reader")]
        public async Task<IActionResult> GetAll()
        {
            // Get Data from the database - Domain models 
            var regionsDomain = await regionRepository.GetAllAsync();
            
            // Mao Domain Models to DTOs(Change the model into a DTO as response)
            var regionsDto = mapper.Map<List<RegionDto>>(regionsDomain);
            
            // Return DTOs
            return Ok(regionsDto);
        }
        
        // GET SINGLE REGION BY ID
        [HttpGet]
        [Route("{id:Guid}")]
        [Authorize(Roles = "Reader")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            // Get Region Domain Model from Databse
            //var region = dbContext.Regions.Find(id);
            var regionDomain = await regionRepository.GetByIdAsync(id);
            if (regionDomain == null)
            {
                return NotFound();
            }
            
            // Map/Convert Region Domain Model to Region DTO
            var regionDto = mapper.Map<RegionDto>(regionDomain);
    
            // Return DTO back to client
            return Ok(regionDto);
        }
        
        // Create New Region
        [HttpPost]
        [ValidateModel]
        [Authorize(Roles = "Writer")]
        public async Task<IActionResult> Create([FromBody] AddRegionRequestDto addRegionRequestDto)
        {
            // Map or Convert DTO to Domain Model
            var regionDomainModel = mapper.Map<Region>(addRegionRequestDto);
            
            // Use Domain Model to create Region
            regionDomainModel = await regionRepository.CreateAsync(regionDomainModel);
            
            // Map Domain Model back to DTO
            var regionDto = mapper.Map<RegionDto>(regionDomainModel);
            
            return CreatedAtAction(nameof(GetById), new { id = regionDto.Id }, regionDto);
        }
        
        // Update Region
        [HttpPut]
        [Route("{id:Guid}")]
        [ValidateModel]
        [Authorize(Roles = "Writer")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateRegionRequestDto updateRegionRequestDto)
        { 
            // Map DTO to Domain Model
            var regionDomainModel = mapper.Map<Region>(updateRegionRequestDto);
            
            // Check if region exists
            regionDomainModel = await regionRepository.UpdateAsync(id, regionDomainModel);

            if (regionDomainModel == null)
            {
                return NotFound();
            }
            
            // Map Domain Model back to DTO
            var regionDto = mapper.Map<RegionDto>(regionDomainModel);
            
            // Return DTO
            return Ok(regionDto);
        }

        // Delete a region
        [HttpDelete]
        [Route("{id:Guid}")]
        [Authorize(Roles = "Writer")]
        public async Task<IActionResult> Update([FromRoute] Guid id)
        {
            // Check if region exists
            var regionDomainModel = await regionRepository.DeleteAsync(id);

            if (regionDomainModel == null)
            {
                return NotFound();
            }
            
            // Return deleted Region back
            // map Domain Model to DTO
            var regionDto = mapper.Map<RegionDto>(regionDomainModel);
            
            // Return the DTO
            return Ok(regionDto);
        }
    }
}

