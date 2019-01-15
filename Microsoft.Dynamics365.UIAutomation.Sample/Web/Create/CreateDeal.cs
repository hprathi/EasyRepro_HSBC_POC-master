// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license.

using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Dynamics365.UIAutomation.Api;
using Microsoft.Dynamics365.UIAutomation.Browser;
using System;
using System.Security;

namespace Microsoft.Dynamics365.UIAutomation.Sample.Web
{
    [TestClass]
    public class CreateDeal
    {

        private readonly SecureString _username = System.Configuration.ConfigurationManager.AppSettings["OnlineUsername"].ToSecureString();
        private readonly SecureString _password = System.Configuration.ConfigurationManager.AppSettings["OnlinePassword"].ToSecureString();
        private readonly Uri _xrmUri = new Uri(System.Configuration.ConfigurationManager.AppSettings["OnlineCrmUrl"].ToString());

        [TestMethod]
        public void WEBTestCreateNewDeal()
        {
            using (var xrmBrowser = new Api.Browser(TestSettings.Options))
            {
                xrmBrowser.LoginPage.Login(_xrmUri, _username, _password);
                xrmBrowser.GuidedHelp.CloseGuidedHelp();

                xrmBrowser.ThinkTime(500);
                xrmBrowser.Navigation.OpenMenu();
                xrmBrowser.ThinkTime(200);
                xrmBrowser.Navigation.OpenSubAreabyID("hsbc_deal");
                xrmBrowser.ThinkTime(2000);
                xrmBrowser.Grid.SwitchView("Active Deals");

                xrmBrowser.ThinkTime(1000);
                xrmBrowser.CommandBar.ClickCommand("New");

                xrmBrowser.ThinkTime(5000);
                xrmBrowser.Entity.SetValue("hsbc_name", "Test API Deal");
                xrmBrowser.Entity.SetValue(new LookupItem { Name = "hsbc_clientname", Value = "A Datum Corporation" });
                xrmBrowser.Entity.SetValue(new LookupItem { Name = "hsbc_originatingcountry", Value = "India" });
                xrmBrowser.Entity.SetValue(new OptionSet { Name = "hsbc_securityclassification", Value = "Class A" });
                xrmBrowser.Entity.SetValue(new OptionSet { Name = "hsbc_dealtype", Value = "DEAL_TYPE_BUY" });
                xrmBrowser.Entity.SetValue(new LookupItem { Name = "hsbc_dealtemplate", Value = "Deal Template 1" });
                xrmBrowser.Entity.SetValue("hsbc_expecteddecisiondate", DateTime.Parse("11/1/1980")); 

                xrmBrowser.CommandBar.ClickCommand("Save & Close");
                xrmBrowser.ThinkTime(2000);
            }
        }
    }
}