namespace Ordenacao.Infra.CrossCutting.Commons.Exceptions
{
    public class OrdererException : Exception
    {
        public OrdererException(string mensagem)
            : base(mensagem) 
        { }
    }
}
