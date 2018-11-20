namespace TestProject_IOC   //create interface ICustomer for the abstraction, so that the customerbusineslayer class does not depend on Customerdatalayer class. both are loosely coupled. 
                           // dependency inversion of principle implemented. 
{
    public interface ICustomerDataAccess
    {
        string GetCustomerName(int id);
    }
}