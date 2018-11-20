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

        ICustomerDataAccess _cusdataaccess;

        public CustomerBusinesLogic()
        {
            //_DataAccess = new DataAccessLayer();

            _cusdataaccess = DataAccessFactory.GetDataAccessObject();

        }

        public string GetCustomerId(int id)
        {

            //CustomerDataAccess _DataAccess = DataAccessFactory.GetDataAccessObject();


            return _cusdataaccess.GetCustomerName(id);


        }


    }

    public class CustomerDataAccess : ICustomerDataAccess            //Data Access Layer

    {
        public CustomerDataAccess()
        {
        }

        public string GetCustomerName(int id)
        {

            return "Dumpy data";


        }
    }
        public class DataAccessFactory   // Factory Pattern to Create object of Data Access Layer with inversion of control, so that the object of the data access class will create with dependency
        {

            public static ICustomerDataAccess GetDataAccessObject()
            {

                return new CustomerDataAccess();
            }


        }

        



    
}
