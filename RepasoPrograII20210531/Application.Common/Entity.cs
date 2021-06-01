using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Application.Common
{
   
    public class Entity
    {
        private long id;

        public long Id {
            get
            {
                return this.id;
            }
            set
            {
                this.id = value;
            }
        }

        public static int CompararEntityPorId(Entity e1, Entity e2)
        {
            int output = 0;
            if (!(e1 is null || e2 is null))
            {
                if (e1.Id > e2.Id)
                {
                    output = 1;
                }
                else if (e1.Id < e2.Id)
                {
                    output = -1;
                }                
            }
            return output;
        }
    }
}
