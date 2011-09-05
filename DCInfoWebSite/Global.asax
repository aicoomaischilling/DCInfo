<%@ Application Language="C#" %>
<script RunAt="server">

    void Application_Start(object sender, EventArgs e) 
    {
        // Code that runs on application startup

    }
    
    void Application_End(object sender, EventArgs e) 
    {
        //  Code that runs on application shutdown

    }
        
    void Application_Error(object sender, EventArgs e) 
    { 
        // Code that runs when an unhandled error occurs

    }

    void Session_Start(object sender, EventArgs e) 
    {
		Session.Add("WWWServer", "");
		Session.Add("SqlServer", "");
		Session.Add("DBName", "");
		
		// the ConnectionString to the DB is stored in the Session here
		//Session.Add("ConnectionString", ConfigurationSettings.AppSettings["ConnectionString_Development"].ToString() + Environment.MachineName.ToString());		
        Session.Add("ConnectionString", "");
		
		Session.Add("isAuthenticated", false);							// @ Session_Start, no one is seen as Authenticated
		Session.Add("ReturnAfterLogin", "");							// and usually, the currently working ASPX should set this parameter itself!

		Session.Add("userName", "");									// believe it or not - we do not know the username yet too ;)
		Session.Add("userID", "");										// and the userID is not known too.
		Session.Add("AUTH_USER", "");

    }

    void Session_End(object sender, EventArgs e) 
    {
        // Code that runs when a session ends. 
        // Note: The Session_End event is raised only when the sessionstate mode
        // is set to InProc in the Web.config file. If session mode is set to StateServer 
        // or SQLServer, the event is not raised.

    }
       
</script>
