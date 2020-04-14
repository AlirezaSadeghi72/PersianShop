namespace Atiran.Connections.Security.Logging
{
    public class Exception : System.Exception
    {
        /// <summary>
        /// Error Code
        /// </summary>
        public string  ErrorCode { get; set; }

        public Exception(string errorCode)
        {
            this.ErrorCode = errorCode;
        }
    }
}
