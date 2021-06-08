using Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLLogica
{
    public class CustomerDAO
    {
        public void Guardar(Customer customer)
        {
            ConnectionHandler.InsertCustomer(customer);
        }

        public List<Customer> Leer()
        {
            List<Customer> output = new List<Customer>();
            output = ConnectionHandler.GetAll();
            return output;
        }

        public Customer LeerPorID(int id)
        {
            Customer output = ConnectionHandler.GetById(id);
            return output;
        }

        public int Modificar(Customer customer)
        {
            int output = 0;
            output = ConnectionHandler.EditCustomer(customer);
            return output;
        }

        public int Borrar(int id)
        {
            int output = 0;
            output = ConnectionHandler.Delete(id);
            return output;
        }

        
    }
}
