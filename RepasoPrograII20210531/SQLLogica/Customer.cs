using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLLogica
{
    public class Customer
    {
        private int id;
        private string name;
        private string lastName;
        private int 

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string LastName { get => lastName; set => lastName = value; }

        public Customer(int id, string name, string lastName)
        {
            this.Id = id;
            this.Name = name;
            this.LastName = lastName;
        }

        public Customer(string name, string lastName)
        {
            this.Name = name;
            this.LastName = lastName;
        }

        public string Leer()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("Id: {0} - Name: {1} - LastName: {2}", this.Id, this.Name, this.LastName);
            return sb.ToString();
        }

        public override string ToString()
        {
            return this.Leer();
        }

        public static int SortById(Customer p1, Customer p2)
        {
            int output = 0;
            if(!(p1 is null || p2 is null))
            {
                if(p1.Id > p2.Id)
                {
                    output = 1;
                }
                else if(p1.Id < p2.Id)
                {
                    output = -1;
                }
            }
            return output;
        }

    }
}
