namespace OSTA.BLL.DTOs.AuthDTOs
{
    public class SignUpUser
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }
        public bool IsActive { get; set; } = false;
        public string Address { get; set; }
        public string RoleName { get; set; }



    }
}
