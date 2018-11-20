using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static TestProject_IOC.CustomerDataAccess;


namespace TestProject_IOC
{
    class Program
    {
        static void Main(string[] args)
        {
            // The code provided will print ‘Hello World’ to the console.
            // Press Ctrl+F5 (or go to Debug > Start Without Debugging) to run your app.
            Console.WriteLine("Hello World!");
            Console.ReadKey();

            // Go to http://aka.ms/dotnet-get-started-console to continue learning how to build a console app! 
        }
    }

    public class CustomerBusinesLogic    // business Logic Layer
    {
        //DataAccessLayer _DataAccess;

        //ICustomerDataAccess _cusdataaccess;

        ICustomerDataAccess _dataaccess;
        
        public CustomerBusinesLogic(ICustomerDataAccess _custdataaccess) //CustomerBusinessLogic includes constructor with one parameter of type ICustomerDataAccess
        {

            _dataaccess = _custdataaccess;

        }


        public CustomerBusinesLogic()
        {
            //_DataAccess = new DataAccessLayer();

            // _cusdataaccess = DataAccessFactory.GetDataAccessObject();

            _dataaccess = new CustomerDataAccess();

        }

        public string GetCustomerId(int id)
        {

            //CustomerDataAccess _DataAccess = DataAccessFactory.GetDataAccessObject();


            //return _cusdataaccess.GetCustomerName(id);

            return _dataaccess.GetCustomerName(id);

        }


    } //End of CustomerBusinessLayer Class


    public class CustomerDataAccess : ICustomerDataAccess            //Data Access Layer

    {
        public CustomerDataAccess()
        {
        }

        public string GetCustomerName(int id)
        {

            return "Dumpy data";


        }

    } //End of CustomerDataAccess



    public class CustomerService               // create new class to initiate the object of customerbusinesslayer using constructor injection
    {                                          // CustomerService class creates and injects CustomerDataAccess object into CustomerBusinessLogic class. Thus, CustomerBusinessLogic class need not create an object of CustomerDataAccess using new keyword or using factory class. The calling class (CustomerService) creates and sets appropriate DataAccess class to the CustomerBusinessLogic class. This way CustomerBusinessLogic and CustomerDataAccess class become more loosely coupled classes.
        CustomerBusinesLogic _CustomerBL;

        public CustomerService()
        {

            _CustomerBL = new CustomerBusinesLogic(new CustomerDataAccess()); //initiating object customerbusineslayer class


        }

        public string GetCustomerName(int id)
        {
            return _CustomerBL.GetCustomerId(id);

        }

    } // End of CustomerDataAccess




    /*  public class DataAccessFactory   // Factory Pattern to Create object of Data Access Layer with inversion of control, so that the object of the data access class will create with dependency
      {

          public static ICustomerDataAccess GetDataAccessObject()
          {

              return new CustomerDataAccess();
          }


      } */






}
