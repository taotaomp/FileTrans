using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPGet
{
    public class IPNotRightException:Exception
    {
        public IPNotRightException():base("IP格式不对啊老哥")
        {

        }
    }
}
