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
    public class UpdateDeal
    {

        private readonly SecureString _username = System.Configuration.ConfigurationManager.AppSettings["OnlineUsername"].ToSecureString();
        private readonly SecureString _password = System.Configuration.ConfigurationManager.AppSettings["OnlinePassword"].ToSecureString();
        private readonly Uri _xrmUri = new Uri(System.Configuration.ConfigurationManager.AppSettings["OnlineCrmUrl"].ToString());

        [TestMethod]
        public void WEBTestUpdateDeal()
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
                xrmBrowser.Grid.Search("Test API Deal");
                xrmBrowser.Grid.OpenRecord(0);

                xrmBrowser.ThinkTime(5000);
                xrmBrowser.Entity.SetValue("hsbc_name", "Test API Deal Updated");


                xrmBrowser.Entity.Save();
                xrmBrowser.ThinkTime(2000);
            }
        }
    }
}