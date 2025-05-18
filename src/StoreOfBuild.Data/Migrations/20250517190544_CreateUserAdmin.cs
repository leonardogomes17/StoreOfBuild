using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StoreOfBuild.Data.Migrations
{
    /// <inheritdoc />
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20250517190544_CreateUserAdmin")]
    public partial class CreateUserAdmin : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"insert into [dbo].[AspNetRoles] (Id, ConcurrencyStamp, Name, NormalizedName ) values ('4303DAEC-FCB9-459A-AF26-63CFC0978D76', '22df0f14-70e9-406a-a708-729fc49e46bb', 'Admin', 'ADMIN')");
            migrationBuilder.Sql(@"insert into [dbo].[AspNetRoles] (Id, ConcurrencyStamp, Name, NormalizedName ) values ('8EB8C41A-CD91-46A4-9682-F58E89EE3639', '22df0f14-70e9-406a-a708-729fc49e46b1', 'Manager', 'MANAGER')");
            migrationBuilder.Sql(@"insert into [dbo].[AspNetRoles] (Id, ConcurrencyStamp, Name, NormalizedName ) values ('806C13A8-3D5B-4D14-8E41-F2555402C875', '22df0f14-70e9-406a-a708-729fc49e46b2', 'Operation', 'OPERATION')");

            migrationBuilder.Sql(@"insert into [AspNetUsers] (Id,
                            UserName, 
                            NormalizedUserName, 
                            Email, 
                            NormalizedEmail, 
                            EmailConfirmed, 
                            PasswordHash,
                            SecurityStamp,
                            ConcurrencyStamp,
                            PhoneNumber,
                            PhoneNumberConfirmed,
                            TwoFactorEnabled,
                            LockoutEnd,
                            LockoutEnabled,
                            AccessFailedCount) values ('324f86a0-5f33-4ff2-ae72-0897814f63a2', 'admin@admin.com', 'ADMIN@ADMIN.COM', 
                            'admin@admin.com', 'ADMIN@ADMIN.COM', 1, 'AQAAAAEAACcQAAAAEIIWoviAu641wICvbFTecu/e8tUNiQXxYQ9JaEUXLYmdcSrSS6OnOmJg1U6kxQgGbQ==', null, null, null, 0, 0, null, 0, 0)");

            migrationBuilder.Sql(@"insert into [AspNetUserRoles] values ('324f86a0-5f33-4ff2-ae72-0897814f63a2','4303DAEC-FCB9-459A-AF26-63CFC0978D76')");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
