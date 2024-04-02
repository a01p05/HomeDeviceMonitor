using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HomeDeviceMonitor.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Buildings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(3000)", maxLength: 3000, nullable: true),
                    Type = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    InactivatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Inactivated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    StatusId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Buildings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Street = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    No = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    City = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Code = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: false),
                    Country = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Latitude = table.Column<double>(type: "float", nullable: true),
                    Longitude = table.Column<double>(type: "float", nullable: true),
                    BuildingId = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    InactivatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Inactivated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    StatusId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Addresses_Buildings_BuildingId",
                        column: x => x.BuildingId,
                        principalTable: "Buildings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Devices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DeviceName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    DeviceDescription = table.Column<string>(type: "nvarchar(3000)", maxLength: 3000, nullable: true),
                    DeviceType = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Ip = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    Host = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Port = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    Protocol = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    Path = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Parameter = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Frequency = table.Column<int>(type: "int", nullable: true),
                    ParentDeviceId = table.Column<int>(type: "int", nullable: true),
                    BuildingId = table.Column<int>(type: "int", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    InactivatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Inactivated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    StatusId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Devices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Devices_Buildings_BuildingId",
                        column: x => x.BuildingId,
                        principalTable: "Buildings",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Devices_Devices_ParentDeviceId",
                        column: x => x.ParentDeviceId,
                        principalTable: "Devices",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Measurements",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DeviceId = table.Column<int>(type: "int", nullable: false),
                    MeasurementType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MeasurementUnit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Frequency = table.Column<int>(type: "int", nullable: true),
                    ValidRange = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Thresholds = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    InactivatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Inactivated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    StatusId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Measurements", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Measurements_Devices_DeviceId",
                        column: x => x.DeviceId,
                        principalTable: "Devices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Buildings",
                columns: new[] { "Id", "Created", "CreatedBy", "Description", "Inactivated", "InactivatedBy", "Modified", "ModifiedBy", "Name", "StatusId", "Type" },
                values: new object[] { 1, new DateTime(2024, 3, 29, 22, 58, 36, 653, DateTimeKind.Local).AddTicks(6505), null, null, null, null, null, null, "Dom test", 1, null });

            migrationBuilder.InsertData(
                table: "Devices",
                columns: new[] { "Id", "BuildingId", "Created", "CreatedBy", "DeviceDescription", "DeviceName", "DeviceType", "Frequency", "Inactivated", "InactivatedBy", "Modified", "ModifiedBy", "ParentDeviceId", "StatusId" },
                values: new object[] { 2, null, new DateTime(2024, 3, 29, 22, 58, 36, 653, DateTimeKind.Local).AddTicks(7348), null, "Sofar KTL-X", "sofar1", "Virtual", null, null, null, null, null, null, 1 });

            migrationBuilder.InsertData(
                table: "Addresses",
                columns: new[] { "Id", "BuildingId", "City", "Code", "Country", "Created", "CreatedBy", "Inactivated", "InactivatedBy", "Modified", "ModifiedBy", "No", "StatusId", "Street", "Latitude", "Longitude" },
                values: new object[] { 1, 1, "Częstochowa", "42-280", "Polska", new DateTime(2024, 3, 29, 22, 58, 36, 653, DateTimeKind.Local).AddTicks(6734), null, null, null, null, null, "81", 1, "Busolowa", 50.777651200000001, 19.038317299999999 });

            migrationBuilder.InsertData(
                table: "Devices",
                columns: new[] { "Id", "BuildingId", "Created", "CreatedBy", "DeviceDescription", "DeviceName", "DeviceType", "Frequency", "Inactivated", "InactivatedBy", "Modified", "ModifiedBy", "ParentDeviceId", "StatusId", "Host", "Ip", "Parameter", "Path", "Port", "Protocol" },
                values: new object[] { 1, 1, new DateTime(2024, 3, 29, 22, 58, 36, 653, DateTimeKind.Local).AddTicks(7134), null, null, "PVmonitor", "Real", 60, null, null, null, null, null, 1, null, "31.42.6.141", null, "public", "14180", "http" });

            migrationBuilder.InsertData(
                table: "Measurements",
                columns: new[] { "Id", "Created", "CreatedBy", "DeviceId", "Frequency", "Inactivated", "InactivatedBy", "MeasurementType", "MeasurementUnit", "Modified", "ModifiedBy", "StatusId", "Thresholds", "ValidRange" },
                values: new object[] { 1, new DateTime(2024, 3, 29, 22, 58, 36, 653, DateTimeKind.Local).AddTicks(7380), null, 2, null, null, null, null, null, null, null, 1, null, null });

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_BuildingId",
                table: "Addresses",
                column: "BuildingId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Devices_BuildingId",
                table: "Devices",
                column: "BuildingId");

            migrationBuilder.CreateIndex(
                name: "IX_Devices_ParentDeviceId",
                table: "Devices",
                column: "ParentDeviceId");

            migrationBuilder.CreateIndex(
                name: "IX_Measurements_DeviceId",
                table: "Measurements",
                column: "DeviceId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Addresses");

            migrationBuilder.DropTable(
                name: "Measurements");

            migrationBuilder.DropTable(
                name: "Devices");

            migrationBuilder.DropTable(
                name: "Buildings");
        }
    }
}
