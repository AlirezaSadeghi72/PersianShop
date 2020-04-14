using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atiran.Connections.Services
{
    public class UsersLineService
    {
        public int UserID { get; set; }
        public string UserFirstName { get; set; }
        public string UserLastName { get; set; }
        public string UserLine { get; set; }

        public UsersLineService()
        {

        }

        public UsersLineService(int UserID, string UserFirstName, string UserLastName, string UserLine)
        {
            this.UserID = UserID;
            this.UserFirstName = UserFirstName;
            this.UserLastName = UserLastName;
            this.UserLine = UserLine;
        }
    }
}
