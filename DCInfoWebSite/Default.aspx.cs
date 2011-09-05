using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

namespace DCInfo.Web
{
	public partial class Default : System.Web.UI.Page
	{
        protected void Page_PreRender(object sender, EventArgs e)
        {
#if DEBUG
            //Response.Write(string.Format("PreRender:<br/> Page Name: {0}", Page.ToString().ToLower()));
#endif

            switch (this.Page.ToString().ToLower())
            {
                case "asp.default_aspx":
                case "asp.test_test_googlemaps_aspx":
                    {
                        ((Main)this.Master).MAINBody.Attributes.Add("onload", "MapInitialize()");

                        break;
                    }
            }
        }
		protected void Page_Load(object sender, EventArgs e)
		{            
            #region AddEvents
            this.PreRender += new EventHandler(this.Page_PreRender);
            #endregion
			Master.Page.Title = "DataCenter Information";
		}
	}
}
