namespace OSTA.BLL.DTOs.AuthDTOs
{
    public class GetUser
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }

        public string Email { get; set; }
        public string Address { get; set; }
        public bool IsActive { get; set; }
        public string RoleName { get; set; }


    }
}
