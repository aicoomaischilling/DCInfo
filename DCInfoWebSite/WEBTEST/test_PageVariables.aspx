<%@ Page Language="C#" AutoEventWireup="true" CodeFile="test_PageVariables.aspx.cs" Inherits="DCInfo.Web.TEST.WEBTEST_test_PageVariables" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
	<title>2ndToken.com</title>
	<!-- JavaScripts' -->
	<script src="<%= URI %>javascripts/prototype.js" type="text/javascript"></script>
	<script src="<%= URI %>javascripts/scriptaculous.js" type="text/javascript"></script>
	<!-- CSS -->
	<link href="<%= URI %>css/Global.css" rel="stylesheet" type="text/css" />
	<!-- JavaScript --> 
	<script type="text/javascript">
		/* 
		 * the following variables are used for basic system functionality 
		 */
		var Path2Root	= "<%= path2Root %>"; 
		var debug = "<%= debug %>"; 
		var ServerName = "<%= serverName %>";
		var ServerPort = "<%= serverPort %>"; 
		var URI = "<%= URI %>"; 
		var AJAXScriptURI = URI + "AJAX/AJAX_Command.aspx"; 
		var UserID = "<%= userID %>"; 
		/* 
 		 * than we have some base- optics to handle :o) 
		 */ 
		var baseColor = "#585858"; 
		/* 
 		 * The QueryString (either coming from POST or GET) is stored here 
		 */
		<%= createQueryString4JS() %>
		/* 
  		 * Go on from here... 
		*/	
	</script>
	<!-- diverse -->
	<link href="<%= URI %>App_Themes/favicon.ico" rel="shortcut icon" />	
</head>
<body>
    <form id="form1" runat="server">
    <div>
		<%= URI %>    
    </div>
    </form>
</body>
</html>
