namespace Application.Common.Exceptions
{
    public sealed class NoContentException : Exception
    {
        public NoContentException(string entityName) : base($"No { entityName } data found")
        {
            
        }
    }
}
