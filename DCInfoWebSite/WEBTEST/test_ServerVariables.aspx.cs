using System;

namespace DCInfo.Web.TEST
{
	public partial class WEBTEST_test_ServerVariables : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			testArea.InnerHtml = "Environment.UserDomainName... " + Environment.UserDomainName + @"\" + Environment.UserInteractive;
			testArea.InnerHtml += "<br /> Environment.UserName:" + Environment.UserName;
			testArea.InnerHtml += "<br /> User.Identity.Name:" + User.Identity.Name.ToString();

		}
	}
}
