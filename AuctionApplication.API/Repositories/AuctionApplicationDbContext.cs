using AuctionApplication.Entities;
using Microsoft.EntityFrameworkCore;

namespace AuctionApplication.Repositories;

public class AuctionApplicationDbContext(DbContextOptions options) : DbContext(options)
{
    public DbSet<Auction> Auctions { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Offer> Offers { get; set; }
}