using Atiran.Connections.Security.Base;

namespace Atiran.Connections.Security
{
    public class SecurityResult : MethodResult
    {
        public bool IsAuthenticated
        {
            get { return (bool)Content; }
        }
    }
}
