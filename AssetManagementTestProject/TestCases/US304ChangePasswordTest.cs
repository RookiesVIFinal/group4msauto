using AssetManagementTestProject.TestSetup;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagementTestProject.TestCases
{
    public class US304ChangePasswordTest : NUnitWebTestSetup
    {
        [TestCase(Constant.NEW_STAFF_USER_NAME_3, Constant.NEW_STAFF_PASSWORD_3, Constant.CHANGED_NEW_STAFF_PASSWORD_3)]
        public void ChangePWSuccsessfullyForTheFirstTimeLogIn(string userName, string password, string newPassword)
        {
            LoginPage.Login(userName, password);
            Asserter.AssertElementIsDisplayed(ChangePw1stTime.AskChangePwFirstLogin());
            ChangePw1stTime.ChangePwFirstTimeLogIn(newPassword);
            Asserter.AssertUrlEquals(DriverBaseAction.GetUrl(), ChangePw1stTime.ReturnExpectedChangePw1stTimeUrl());
        }
    }
}
