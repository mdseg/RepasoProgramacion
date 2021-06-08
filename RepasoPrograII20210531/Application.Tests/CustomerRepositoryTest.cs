using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Application.Repositories;
using Application.Models;

namespace Application.Tests
{
    [TestClass]
    public class CustomerRepositoryTest
    {
        /// <summary>
        ///A test for Create
        ///</summary>
        [TestMethod()]
        public void CreateSuccessfullyTest()
        {
            //Arrange
            RepositoryBase<Customer> repository = new CustomerRepositorySQL();

            int millisecond = DateTime.Now.Millisecond;

            Customer entityToCreate = new Customer()
            {
                LastName = "TestCustomerLastName" + millisecond,
                Name = "TestCustomerName" + millisecond
            };
            //Notar que entityToCreate.Id es null en este momento


            //Act
            repository.Create(entityToCreate);

            Customer entityToValidate =
                repository.GetById(entityToCreate.Id);

            //Assert
            Assert.IsNotNull(entityToValidate);
            Assert.IsTrue(entityToValidate.Id > 0);
        }

        ///// <summary>
        /////A test for GetAll
        /////</summary>
        [TestMethod()]
        public void GetAllTest()
        {
            //Arrange
            RepositoryBase<Customer> target = new CustomerRepositorySQL();
            List<Customer> expected = target.GetAll();
            List<Customer> actual;
            bool output = false;
            //Act
            actual = target.GetAll();

            for(int i = 0; i < expected.Count;i++)
            {
                if(expected[i] != actual[i])
                {
                    output = true;
                    break;
                }
            }

            //Assert
            Assert.AreEqual(false, output);

        }
        ///// <summary>
        /////A test for GetById
        /////</summary>
        [TestMethod()]
        public void GetByIdTest()
        {
            //Arrange
            RepositoryBase<Customer> target = new CustomerRepositorySQL();
            long entityId = 1;
            Customer expected = target.GetById(entityId); // TODO: Inicializar de manera apropiada 
            Customer actual;

            //Act
            actual = target.GetById(entityId);
            

            //Assert
            Assert.AreEqual(expected.LastName, actual.LastName);

        }
        ///// <summary>
        /////A test for Remove
        /////</summary>
        [TestMethod()]
        public void RemoveTest()
        {
            //Arrange
            RepositoryBase<Customer> target = new CustomerRepositorySQL();
            Customer entity = null;// TODO: Inicializar de manera apropiada
            entity.Id = 1;
            
            target.Remove(entity);
            Customer actual;

            target.GetById(1);
            

            //Act

            //Assert
            Assert.Inconclusive("A method that does not return a value cannot be verified.");

        }
        ///// <summary>
        /////A test for Update
        /////</summary>
        [TestMethod()]
        public void UpdateTest()
        {
            //Arrange
            CustomerRepository target = null; // TODO: Inicializar de manera apropiada 
            Customer entity = null; // TODO: Inicializar de manera apropiada 

            //Act
            target.Update(entity);

            //Assert
            Assert.Inconclusive("A method that does not return a value cannot be verified.");

        }
    }
}
