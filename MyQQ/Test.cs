
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyQQ
{
    class Test
    {

        public void test()
        {
            var json = DynamicJson.Serialize(new { Id = "", Name = "" });
            var data = DynamicJson.Parse(json);
            
        }

    }
}
