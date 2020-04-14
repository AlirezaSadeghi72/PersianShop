using System.Collections.Generic;

namespace Atiran.Connections.Security.Base
{
    public enum ResultSetType
    {
        Scalar = 0,
        List = 1,
    }

    public enum ResultStatus
    {
        Successful = 0,
        Error = 1,
    }

    public class MethodResult
    {
        /// <summary>
        /// Determine that if result set is scalar or list
        /// </summary>
        public ResultSetType ResultSetType { get; set; }

        /// <summary>
        /// Determine the type of result based on System.Type types
        /// </summary>
        public System.Type Type { get; set; }

        /// <summary>
        /// Determine returned status of result
        /// </summary>
        public ResultStatus Status { get; set; }

        /// <summary>
        /// Raw content of result
        /// </summary>
        public dynamic Content;

        /// <summary>
        /// List of caught exceptions in the method
        /// </summary>
        public List<Logging.Exception> Exceptions { get; set; }
    }
}
