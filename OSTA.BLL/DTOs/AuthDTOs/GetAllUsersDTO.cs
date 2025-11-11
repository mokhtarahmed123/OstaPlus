namespace OSTA.BLL.DTOs.AuthDTOs
{
    public class GetAllUsersDTO
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public bool IsActive { get; set; }
        public string Address { get; set; }
        public string RoleName { get; set; }
    }
}
