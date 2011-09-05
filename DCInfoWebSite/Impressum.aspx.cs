using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

namespace DCInfo.Web
{
	public partial class Impressum : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			Master.Page.Title = "DataCenter Information - Impressum";
		}
	}
}