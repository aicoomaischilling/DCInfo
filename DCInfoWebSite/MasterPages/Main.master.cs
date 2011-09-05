using System;
using System.Collections.Specialized;
using System.Web;
using System.Web.Security;
using System.Configuration;

using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

namespace DCInfo.Web
{
	public partial class Main : System.Web.UI.MasterPage
	{
		#region global, internal variables
		/*
		* some internal data
		*/
		protected internal string serverName = "";							// stores the current ServerName for further use
		protected internal string serverPort = "";							// stores the (current) SSLPort for further use
		protected internal bool isSSL = false;								// stores whether we running under SSL or not
		protected internal string uRIBasePath = "";							// BaseURI to the application
		protected internal string uRI = "";									// stores the URI to be used for Server Connections

		protected internal bool debug = false;								// per default - we do not debug;

		protected internal bool isAuthenticated = false;					// per default we do not believe that the current Session is authenticated

		protected internal string path2Root = "";							// stores the path to the root of the application (in case the file is below the root- folder)
		protected internal string returnAfterLogin = "";					// stores where to come back...

		protected internal NameValueCollection queryString = null;			// stores the Querystring equal if it comes from an POST or GET event
		protected internal string queryString4JS = "";						// stores the Querystring as an assotiative array for JavaScript.

		protected internal string userID = "";								// the Sessions' userID

		private string connectionString = "";								// the database connection string

		protected internal string PIWIK = "";								// PIWIK Code
		protected internal string GOOGLEAnalytics = "";						// Google Analytics Code
	    protected internal string GOOGLEMapsKey = "";                       // Google Maps Key
	    protected internal string BINGMapKey = "";                          // Bing Map Key

		#region Properties
		public string Copyright
		{
			get
			{
				if (DateTime.Now.Year.ToString().Trim() == "2011")
					return "2011";
				else
					return "2011 - " + DateTime.Now.Year;
			}
		}

		public string URI
		{
			get
			{
				return uRI;
			}
		}

		public string URIBasePath
		{
			get
			{
				return uRIBasePath;
			}
		}

		public string Piwik
		{
			get { return PIWIK; }
		}

		public string GoogleAnalytics
		{
			get
			{
				return GOOGLEAnalytics;
			}
		}

	    public string GoogleMapsKey
	    {
	        get 
            { 
                return GOOGLEMapsKey; 
            }
	    }

        public string BingMapKey
        {
            get
            {
                return BINGMapKey;
            }
        }

	    public HtmlGenericControl MAINBody
	    {
	        get 
            { 
                return MainBody;
            }
	    }
        
		#endregion
		#endregion

		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad(e);
			//Page.Header.DataBind();
		}
/*
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
                        MainBody.Attributes.Add("onload", "MapInitialize()");

                        break;
                    }
            }
        }
*/
        protected void Page_Load(object sender, EventArgs e)
        {
            #region AddEvents
            //this.PreRender += new EventHandler(this.Page_PreRender);
            #endregion

            #region ASPX Data initialization
            /* 
			 * initialize internal data
			 */

			uRIBasePath = Request.ApplicationPath + (Request.ApplicationPath.Trim().EndsWith("/") == true ? "" : "/");

			serverName = Request.ServerVariables["SERVER_NAME"].ToString();
			serverPort = Request.ServerVariables["SERVER_PORT"].ToString();
			isSSL = Request.IsSecureConnection;
			uRI = (isSSL == true) ? "https://" : "http://";
			uRI += serverName + ":" + serverPort + uRIBasePath + (Session.CookieMode == HttpCookieMode.UseCookies ? "" : "(S(" + Session.SessionID.ToString() + "))/");			

			path2Root = uRI;
			returnAfterLogin = Request["SCRIPT_NAME"].ToString();

			queryString = GetQueryString();
			queryString4JS = createQueryString4JS();

            
            if (Session["ConnectionString"] == null)
                Session["ConnectionString"] = ConfigurationManager.AppSettings["DCInfoDB"].ToString().ToLower();        // we have to initialize this first in the session.

			connectionString = Session["ConnectionString"].ToString();		// we know that Session["ConnectionString"] is set per Default in Global.asax		            

            if (Page.User.Identity != null)
            {
                Session["userID"] = Page.User.Identity.Name.ToString();
                Session["isAuthenticated"] = Page.User.Identity.IsAuthenticated;
            }

            userID = Session["userID"].ToString();                        
			isAuthenticated = (bool)Session["isAuthenticated"];				// we know that Session["isAuthenticated"] is set per DEFAULT!! in Global.asax!

			PIWIK = ConfigurationManager.AppSettings["PIWIK"].Trim();
			GOOGLEAnalytics = ConfigurationManager.AppSettings["GoogleAnalytics"].Trim();
		    GOOGLEMapsKey = ConfigurationManager.AppSettings["GoogleMapsKey"].Trim();
            BINGMapKey = ConfigurationManager.AppSettings["BingMapKey"].Trim();

			if (Request["debug"] != null)		// do we got a debug- instruction?
			{
				debug = (Request["debug"].ToString().ToLower() == "true") ? true : false;
			}
			else
			{
				debug = false;					// No? so we can expect that we do not need to :)
			}
			/*
			 * and than do the work of this page
			 */
			#endregion
		}

		#region Added functions
		#region createQueryString4JS
		public String createQueryString4JS()
		{
			NameValueCollection queryString = GetQueryString();
			String jsReturn = "";

			if (queryString.Count > 0)
			{
				// jsReturn = "<script type=\"text/javascript\">";

				jsReturn += "var QueryString = new Array();\r\n";

				for (int i = 0 ; i < queryString.Count ; i++)
				{
					if (queryString.Keys[i] != null)	// whysoever, this could happen
					{
						if (queryString.Keys[i].ToUpper() != "ASPXAUTODETECTCOOKIESUPPORT")	// due to the fact that this information is not really needed, we do not print it into the JS
						{
							jsReturn += "QueryString[" + i.ToString() + "] = new Object();\r\n";
							jsReturn += "QueryString[" + i.ToString() + "][\"" + queryString.Keys[i].ToString() + "\"] = \"" + queryString[i].ToString() + "\";\r\n";
						}
					}
				}

				//jsReturn += "</script>";
			}
			return jsReturn;
		}
		#endregion

		#region GetQueryString
		public NameValueCollection GetQueryString()
		{
			/*
			 * The following lines handle the QueryString situation equally of POST or GET method. The QueryString is stored as a NameValueCollection
			 */
			NameValueCollection queryString = null;			//

			if (Request.HttpMethod != "POST")
				queryString = Request.QueryString;
			else
				queryString = Request.Form;

			/*
			 * Since - and whysoever - it could happen that a parameter of the QueryString- Object is
			 * null and since we decided to throw an exception in this situation to warn especially the AJAX-
			 * Developer, the following check is done each time, the aspx is opened.
			 */
			for (int i = 0 ; i < queryString.Count ; i++)
				if (queryString[i] == null)
					throw new Exception("DEVELOPER ERROR: queryString[{0}] IS NULL.");	// this is a hard, dead end error ;o)

			return queryString;
		}
		#endregion
		#endregion
	}
}