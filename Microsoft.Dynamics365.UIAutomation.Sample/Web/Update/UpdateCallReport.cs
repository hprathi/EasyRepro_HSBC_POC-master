// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license.

using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Dynamics365.UIAutomation.Api;
using Microsoft.Dynamics365.UIAutomation.Browser;
using System;
using System.Security;

namespace Microsoft.Dynamics365.UIAutomation.Sample.Web.Update
{
    [TestClass]
    public class UpdateCallReport
    {
        private readonly SecureString _username = System.Configuration.ConfigurationManager.AppSettings["OnlineUsername"].ToSecureString();
        private readonly SecureString _password = System.Configuration.ConfigurationManager.AppSettings["OnlinePassword"].ToSecureString();
        private readonly Uri _xrmUri = new Uri(System.Configuration.ConfigurationManager.AppSettings["OnlineCrmUrl"].ToString());

        [TestMethod]
        public void WEBTestUpdateCallReport()
        {
            using (var xrmBrowser = new Api.Browser(TestSettings.Options))
            {
                xrmBrowser.LoginPage.Login(_xrmUri, _username, _password);
                xrmBrowser.GuidedHelp.CloseGuidedHelp();
                xrmBrowser.Navigation.OpenAdvancedFind();
                xrmBrowser.Entity.SwitchToPopupWindow();
                xrmBrowser.Entity.SetValue(new OptionSet { Name = "slctPrimaryEntity", Value = "Meetings and Call Reports" });
                //xrmBrowser.Entity.SwitchToDefaultContent();
                xrmBrowser.CommandBar.ClickCommandbyClass("ms-crm-ImageStrip-Results_32");
                xrmBrowser.Entity.SwitchToContentFrame();
                xrmBrowser.Entity.SwitchToResultsFrame();
                xrmBrowser.CommandBar.ClickCommandbyLink("TestReport");
                xrmBrowser.Entity.SwitchToPopupWindow();
                xrmBrowser.Entity.SwitchToContentFrame();
                xrmBrowser.Entity.SetValue(new OptionSet { Name = "hsbc_securityclassification", Value = "Class B" });
                xrmBrowser.Entity.Save();
                xrmBrowser.ThinkTime(3000);

            }
        }
    }
}