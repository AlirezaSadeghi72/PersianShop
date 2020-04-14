using System.Collections.Generic;
using System.Data;
using System;
using System.Text;
using System.Globalization;
using Atiran.Connections.Operaions.UserOp;

namespace Atiran.Connections.Security
{
    public sealed class Authentication
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public Authentication()
        {
            
        }

        #region Properties

        /// <summary>
        /// Gets and sets the landing form
        /// </summary>
        private static string _defaultForm;
        public static string DefaultForm
        {
            get
            {
                if (string.IsNullOrEmpty(_defaultForm))
                {
                    //TODO: It could be read from a configuration file (FormMap.xml)
                    return "Default";
                }

                return _defaultForm;
            }
        }

        /// <summary>
        /// Gets and sets the login form
        /// </summary>
        private static string _loginForm;
        public static string LoginForm
        {
            get
            {
                if (string.IsNullOrEmpty(_loginForm))
                {
                    //TODO: It could be read from a configuration file (FormMap.xml)
                    return "Login";
                }

                return _loginForm;
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Validates a user name and password against credentials for an application.
        /// </summary>
        /// <param name="username">The user name</param>
        /// <param name="password">The password for the user</param>
        /// <returns>true if the user name and password are valid; otherwise, false</returns>
        public static SecurityResult Authenticate(string username, string password)
        {
            UserService userService = new UserService();
            SecurityResult result = null;

            if (!userService.UserExists(username))
            {
                result = new SecurityResult()
                {
                    Status = Connections.Security.Base.ResultStatus.Error,
                    Type = System.Type.GetType("System.Boolean"),       
                    ResultSetType = Connections.Security.Base.ResultSetType.Scalar,
                    Content = false,
                    Exceptions = new List<Connections.Security.Logging.Exception>()
                    {
                        new Connections.Security.Logging.Exception("ERR_USER_NOT_EXISTS"),
                    },
                }; 
            }       
            else if(!userService.UsernamePasswordMatches(username, password))
            {
                result = new SecurityResult()
                {
                    Status = Connections.Security.Base.ResultStatus.Error,
                    Type = System.Type.GetType("System.Boolean"),
                    ResultSetType = Connections.Security.Base.ResultSetType.Scalar,
                    Content = false,
                    Exceptions = new List<Connections.Security.Logging.Exception>()
                    {
                        new Connections.Security.Logging.Exception("ERR_PASSWORD_IS_NOT_CORRECT"),
                    },
                };
            }
            //if user exists, is not locked and password is correct
            else
            {

                result = new SecurityResult()
                {
                    Status = Connections.Security.Base.ResultStatus.Successful,
                    Type = System.Type.GetType("System.Boolean"),
                    ResultSetType = Connections.Security.Base.ResultSetType.Scalar,
                    Content = true,
                    Exceptions = null,
                };
            }

            return result;
        }

        /// <summary>
        /// Sign out from application
        /// </summary> 
        public static void SignOut()
        {

        }

        /// <summary>
        /// Adds a new user to the data store.
        /// </summary>
        /// <param name="username">The user name for the new user</param>
        /// <param name="password">The password for the new user</param>
        /// <returns>A sys_users object for the newly created user</returns>
        
        public static Connections.AtiranAccModel.User CreateUser(string username, string password)
        {
            return null;
        }

        #endregion
    }
}
