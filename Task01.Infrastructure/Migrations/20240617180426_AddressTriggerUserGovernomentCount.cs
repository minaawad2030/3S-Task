using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Task01.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddressTriggerUserGovernomentCount : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"CREATE TRIGGER trg_UpdateGovernorateUserCount
                                    ON Addresses
                                    AFTER INSERT, UPDATE, DELETE
                                    AS
                                    BEGIN
                                        SET NOCOUNT ON;
	                                    DECLARE @governorateId bigint
	                                    Declare @usersCount bigint
                                        select @governorateId=i.GovernorateId from inserted i;
	                                    select @usersCount= COALESCE(
                                        (select c.UserCount FROM GovernorateUserCount c 
                                         WHERE c.GovernorateId = @governorateId),0);
	                                    update GovernorateUserCount set UserCount=@usersCount+1
	                                    where GovernorateId=@governorateId;
	                                    if(@@ROWCOUNT=0)
	                                    insert into GovernorateUserCount (GovernorateId,UserCount)
	                                    values(@governorateId,@usersCount+1)
	                                    select @usersCount;
                                    END;");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
