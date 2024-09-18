namespace ClothingStoreWebAPI.Contracts.Responses
{
    public record BasicInformation
    {
        public string FirstName { get; set; }
        public string LastName { get;  set; }
        public string UserName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Email { get; set; }
        public bool IsEmailVerified { get; set; }
        public string PhoneNumber { get; set; }
    }
}
