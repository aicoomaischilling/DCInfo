using System;
using System.Collections.Specialized;

namespace DCInfo.Web.TEST
{
	public partial class WEBTEST_test_PageVariables : System.Web.UI.Page
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

		#region Properties
		public string Copyright
		{
			get
			{
				if (DateTime.Now.Year.ToString().Trim() == "2007")
					return "2007";
				else
					return "2007 - " + DateTime.Now.Year;
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
		#endregion
		#endregion

		protected void Page_Load(object sender, EventArgs e)
		{
			#region ASPX Data initialization
			/* 
		 * initialize internal data
		 */		 
			uRIBasePath = Request.ApplicationPath + (Request.ApplicationPath.Trim().EndsWith("/") == true ? "" : "/");

			serverName = Request.ServerVariables["SERVER_NAME"].ToString();
			serverPort = Request.ServerVariables["SERVER_PORT"].ToString();
			isSSL = Request.IsSecureConnection;
			uRI = (isSSL == true) ? "https://" : "http://";
			uRI += serverName + ":" + serverPort + uRIBasePath + "(S(" + Session.SessionID.ToString() + "))/";

			path2Root = uRI;
			returnAfterLogin = Request["SCRIPT_NAME"].ToString();

			queryString = GetQueryString();
			queryString4JS = createQueryString4JS();

			connectionString = Session["ConnectionString"].ToString();		// we know that Session["ConnectionString"] is set per Default in Global.asax
			userID = Session["userID"].ToString();
			isAuthenticated = (bool)Session["isAuthenticated"];				// we know that Session["isAuthenticated"] is set per DEFAULT!! in Global.asax!

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
				jsReturn = "<script type=\"text/javascript\">";

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

				jsReturn += "</script>";
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
