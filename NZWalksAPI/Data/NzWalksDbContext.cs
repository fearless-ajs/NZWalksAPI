﻿using Microsoft.EntityFrameworkCore;
using NZWalksAPI.Models.Domain;

namespace NZWalksAPI.Data;

public class NzWalksDbContext: DbContext
{
    public NzWalksDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
    {
        
    }
    
    // Create properties based on the available entities
    public DbSet<Difficulty> Difficulties { get; set; }
    
    public DbSet<Region> Regions { get; set; }
    
    public DbSet<Walk> Walks { get; set; }
    
    // To create migrations
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        // Seed data for Difficulties
        // Easy, Medium, Hard
        var difficulties = new List<Difficulty>()
        {
            new Difficulty()
            {
                Id = Guid.Parse("c29ff782-3cf4-4f3d-9e31-8e5af3e29f71"),
                Name = "Easy"
            },
            new Difficulty()
            {
                Id = Guid.Parse("c75bae1c-ec61-4773-bc57-a4f8dfe1901a"),
                Name = "Medium"
            },
            new Difficulty()
            {
                Id = Guid.Parse("bf4274f5-f8d1-427f-8fa8-aacc43f1d824"),
                Name = "Hard"
            },
        };

        // Seed difficulties to the database
        modelBuilder.Entity<Difficulty>().HasData(difficulties);
        
        
        // Seed data for Regions
        var regions = new List<Region>
        {
            new Region
            {
                Id = Guid.Parse("f7248fc3-2585-4efb-8d1d-1c555f4087f6"),
                Name = "Auckland",
                Code = "AKL",
                RegionImageUrl = "https://images.pexels.com/photos/5169056/pexels-photo-5169056.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1"
            },
            new Region
            {
                Id = Guid.Parse("6884f7d7-ad1f-4101-8df3-7a6fa7387d81"),
                Name = "Northland",
                Code = "NTL",
                RegionImageUrl = null
            },
            new Region
            {
                Id = Guid.Parse("14ceba71-4b51-4777-9b17-46602cf66153"),
                Name = "Bay Of Plenty",
                Code = "BOP",
                RegionImageUrl = null
            },
            new Region
            {
                Id = Guid.Parse("cfa06ed2-bf65-4b65-93ed-c9d286ddb0de"),
                Name = "Wellington",
                Code = "WGN",
                RegionImageUrl = "https://images.pexels.com/photos/4350631/pexels-photo-4350631.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1"
            },
            new Region
            {
                Id = Guid.Parse("906cb139-415a-4bbb-a174-1a1faf9fb1f6"),
                Name = "Nelson",
                Code = "NSN",
                RegionImageUrl = "https://images.pexels.com/photos/13918194/pexels-photo-13918194.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1"
            },
            new Region
            {
                Id = Guid.Parse("f077a22e-4248-4bf6-b564-c7cf4e250263"),
                Name = "Southland",
                Code = "STL",
                RegionImageUrl = null
            },
        };

        // Seed regions to the database
        modelBuilder.Entity<Region>().HasData(regions);
    }
}