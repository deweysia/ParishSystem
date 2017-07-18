using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParishSystem
{
    class ComboboxContent
    {
          int id;
          string content;

        public ComboboxContent(int id, string content)
        {
            this.id = id;
            this.content = content;
        }
        public override string ToString()
        {
            return content;
        }

        public int ID
        {
            get
            {
                return id;
            }
        }
            

}
}
