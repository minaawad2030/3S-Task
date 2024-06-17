using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Task01.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class GovernoratesAndCitiesDataSeeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"SET IDENTITY_INSERT  [Governorates] ON 
                                    GO
                                    INSERT  [Governorates] ([Id], [IsDeleted], [Name]) VALUES (1, 0, N'Aswan')
                                    GO
                                    INSERT  [Governorates] ([Id], [IsDeleted], [Name]) VALUES (2, 0, N'Luxor')
                                    GO
                                    SET IDENTITY_INSERT  [Governorates] OFF
                                    GO
                                    SET IDENTITY_INSERT  [Cities] ON 
                                    GO
                                    INSERT  [Cities] ([Id], [GovernorateId], [IsDeleted], [Name]) VALUES (1, 1, 0, N'Aswan')
                                    GO
                                    INSERT  [Cities] ([Id], [GovernorateId], [IsDeleted], [Name]) VALUES (2, 1, 0, N'Edfu')
                                    GO
                                    INSERT  [Cities] ([Id], [GovernorateId], [IsDeleted], [Name]) VALUES (3, 1, 0, N'Komombo')
                                    GO
                                    INSERT  [Cities] ([Id], [GovernorateId], [IsDeleted], [Name]) VALUES (4, 1, 0, N'Daraw')
                                    GO
                                    INSERT  [Cities] ([Id], [GovernorateId], [IsDeleted], [Name]) VALUES (5, 2, 0, N'Ensa')
                                    GO
                                    INSERT  [Cities] ([Id], [GovernorateId], [IsDeleted], [Name]) VALUES (6, 2, 0, N'Armnt')
                                    GO
                                    SET IDENTITY_INSERT  [Cities] OFF
                                    GO");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
