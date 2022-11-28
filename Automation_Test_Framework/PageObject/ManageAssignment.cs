using Core_Framework.DriverCore;
using OpenQA.Selenium;

namespace TheRookiesApp.PageObject;

public class ManageAssignment : WebDriverBase
{
    public ManageAssignment(IWebDriver driver) : base(driver)
    {

    }

    //    public void EditEmployeesInfo(EmployeesDAO employees)
    //    {
    //        SendKeys_(txtFirstName, employees.FirstName);
    //        SendKeys_(txtLastName, employees.LastName);
    //        SendKeys_(txtEmail, employees.Email);
    //        SendKeys_(txtAge, employees.Age);
    //        SendKeys_(txtSalary, employees.Salary);
    //        SendKeys_(txtDepartment, employees.Department);

    //    }

    //    public void ClearEmployeeInfo()
    //    {
    //        Clear(txtFirstName);
    //        Clear(txtLastName);
    //        Clear(txtEmail);
    //        Clear(txtAge);
    //        Clear(txtSalary);
    //        Clear(txtDepartment);
    //    }
}
