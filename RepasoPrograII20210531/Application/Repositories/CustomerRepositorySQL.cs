using Application.DataAcces;
using Application.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Repositories
{
    public class CustomerRepositorySQL : RepositoryBase<Customer>
    {
        public override void Create(Customer entity)
        {
            String connectionStr = @"Data Source=.;Initial Catalog=Repaso;Integrated Security=True";
            int columnasAfectadas = 0;

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionStr))
                {
                    connection.Open();

                    SqlCommand command = new SqlCommand();
                    command.CommandType = System.Data.CommandType.Text;
                    command.Connection = connection;

                    command.CommandText = "INSERT INTO [Customer] ([Name], [LastName], [Age])" + "Values (@name, @lastName, @age)";
                    command.Parameters.AddWithValue("@name", entity.Name);
                    command.Parameters.AddWithValue("@lastName", entity.LastName);
                    command.Parameters.AddWithValue("@age", entity.Age);

                    columnasAfectadas = command.ExecuteNonQuery();
                }
            }
            catch (Exception e)
            {

            }
        }

        public override List<Customer> GetAll()
        {
            List<Customer> customers = new List<Customer>();

            try
            {
                String connectionStr = @"Data Source=.;Initial Catalog=Repaso;Integrated Security=True";
                SqlConnection connection = new SqlConnection(connectionStr);



                connection.Open();

                SqlCommand command = new SqlCommand();
                command.CommandType = System.Data.CommandType.Text;
                command.Connection = connection;

                command.CommandText = string.Format("SELECT * FROM Customer");

                SqlDataReader dataReader = command.ExecuteReader();

                while (dataReader.Read() != false)
                {

                    Customer customer = new Customer(dataReader["name"].ToString(), dataReader["lastName"].ToString(), Convert.ToInt32(dataReader["age"]));
                    customer.Id = Convert.ToInt32(dataReader["id"]);
                    customers.Add(customer);
                }
                dataReader.Close();
                connection.Close();

            }
            catch (Exception e)
            {

            }
            return customers;
        }

        public override Customer GetById(long entityId)
        {
            Customer customer = null;
            String connectionStr = @"Data Source=.;Initial Catalog=Repaso;Integrated Security=True";

            SqlConnection connection = new SqlConnection(connectionStr);
            connection.Open();

            SqlCommand command = new SqlCommand();
            command.CommandType = System.Data.CommandType.Text;
            command.Connection = connection;

            command.CommandText = string.Format($"SELECT * FROM Customer WHERE id = {entityId}");

            SqlDataReader dataReader = command.ExecuteReader();

            if (dataReader.Read() == false)
            {
                throw new Exception("Customer no encontrada");
            }

            customer = new Customer(dataReader["name"].ToString(), dataReader["lastName"].ToString(), Convert.ToInt32(dataReader["age"]));
            customer.Id = Convert.ToInt32(dataReader["id"]);
            dataReader.Close();
            connection.Close();
            return customer;
        }

        public override void Remove(Customer entity)
        {
            String connectionStr = @"Data Source=.;Initial Catalog=Repaso;Integrated Security=True";
            int columnasAfectadas = 0;

            try
            {
                SqlConnection connection = new SqlConnection(connectionStr);
                connection.Open();

                SqlCommand command = new SqlCommand();
                command.CommandType = System.Data.CommandType.Text;
                command.Connection = connection;

                command.CommandText = string.Format($"DELETE FROM Customer WHERE ID = {entity.Id}");

                columnasAfectadas = command.ExecuteNonQuery();

                connection.Close();
            }
            catch (Exception e)
            {

            }

        }

        public override void Update(Customer entity)
        {
            String connectionStr = @"Data Source=.;Initial Catalog=Repaso;Integrated Security=True";
            int columnasAfectadas = 0;
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionStr))
                {
                    connection.Open();

                    SqlCommand command = new SqlCommand();
                    command.CommandType = System.Data.CommandType.Text;
                    command.Connection = connection;

                    command.CommandText = $"UPDATE [Customer] SET Name = @name, LastName = @lastName, Age = @age WHERE Id = {entity}";

                    command.Parameters.AddWithValue("@name", entity.Name);
                    command.Parameters.AddWithValue("@lastName", entity.LastName);
                    command.Parameters.AddWithValue("@Age", entity.Age);

                    columnasAfectadas = command.ExecuteNonQuery();

                }
            }
            catch (Exception e)
            {

            }

        }

        public List<Customer> LoadFromFile(string path)
        {

            CustomerSerializer customerSerializer = new CustomerSerializer();
            customers.AddRange(customerSerializer.Read(path));
            return customers;
        }

        public bool SaveToFile(List<Customer> customers)
        {
            CustomerSerializer customerSerializer = new CustomerSerializer();
            return customerSerializer.Save(customers);
        }
    }
}
