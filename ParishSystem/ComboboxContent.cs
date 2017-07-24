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
          string content2;

        public ComboboxContent(int id, string content)
        {
            this.id = id;
            this.content = content;
        }
        public ComboboxContent(int id, string content,string content2)
        {
            this.id = id;
            this.content = content;
            this.content2 = content2;
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
        public string Content2
        {
            get
            {
                return content2;
                
            }
        }


    }
}
