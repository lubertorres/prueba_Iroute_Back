using System;



namespace prueba_Iroute_Back.Aplication.Exceptions
{
    public class ClienteNoExisteException : Exception
    {
        public ClienteNoExisteException() : base("El cliente no existe.")
        {
        }

        public ClienteNoExisteException(string message) : base(message)
        {
        }

        public ClienteNoExisteException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
