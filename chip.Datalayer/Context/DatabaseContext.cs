using chipchop.Datalayer.Models;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;

namespace chipchop.Datalayer.Context;

public class DatabaseContext : DbContext
{
    public DbSet<Role> Roles { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Content> Contents { get; set; }
    public DbSet<Group> Groups { get; set; }
    public DbSet<Factor> Factors { get; set; }
    public DbSet<FactorDetail> FactorDetails { get; set; }
    public DbSet<UserInfo> UserInfos { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        //base.OnConfiguring(optionsBuilder);
        optionsBuilder.UseSqlServer(@"Data Source=.; 
                               Initial Catalog=ChipChopDb;
                               Trusted_Connection=SSPI;
                               Encrypt=false;
                               TrustServerCertificate=True");
    }

    protected override async void OnModelCreating(ModelBuilder modelBuilder)
    {
        var admin = new Role()
        {
            Id = Guid.NewGuid(),
            RoleName = "admin",
            RoleTitle = "مدیر"
        };
        modelBuilder.Entity<Role>().HasData(admin);

        //base.OnModelCreating(modelBuilder);


        //add frist user

        var user = new User()
        {
            Id = Guid.NewGuid(),
            RoleId = admin.Id,
            UserName = "09020123456",
            Password = await GetHash("123456789")
        };

        modelBuilder.Entity<User>().HasData(user);

        /*var group = new List<Group>()
        {
            new Group() {Id = 1, GroupName=""},
            new Group() {Id = 2,GroupName=""},
            new Group() {Id = 3,GroupName=""}
        };
        modelBuilder.Entity<Group>().HasData(group);*/
    }

    public async Task<string> GetHash(string key)
    {
        MD5 code = MD5.Create();
        byte[] Input = ASCIIEncoding.Default.GetBytes(key);
        byte[] Output = code.ComputeHash(Input);

        var hashkey = Convert.ToBase64String(Output);
        return await Task.FromResult(hashkey);
    }
}