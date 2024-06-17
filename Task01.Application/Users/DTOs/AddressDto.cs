namespace Task01.Application.Users.DTOs
{
    public class AddressDto
    {
        public int GovernorateId { get; set; }
        public int CityId { get; set; }
        public string Street { get; set; }
        public string BuildingNumber { get; set; }
        public string FlatNumber { get; set; }
    }
}
