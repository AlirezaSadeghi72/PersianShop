using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atiran.Connections.AtiranAccModel
{
    public partial class AccModelEntities : DbContext
    {
        public AccModelEntities(String connString) : base(connString)
        {

        }
    }
}
