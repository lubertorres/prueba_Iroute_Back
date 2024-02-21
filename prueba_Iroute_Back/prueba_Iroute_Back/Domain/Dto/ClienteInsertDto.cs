namespace prueba_Iroute_Back.Domain.Dto
{
    public class ClienteInsertDto
    {
        public string Identification { get; set; } = null!;

        public string Name { get; set; } = null!;

        public string? SecondName { get; set; }

        public string LastName { get; set; } = null!;

        public string Email { get; set; } = null!;
    }
}
