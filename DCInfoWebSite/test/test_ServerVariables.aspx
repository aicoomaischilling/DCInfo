<%@ Page AutoEventWireup="true" CodeFile="test_ServerVariables.aspx.cs" Inherits="DCInfo.Web.TEST.WEBTEST_test_ServerVariables"
	Language="C#" MasterPageFile="~/MasterPages/Main.master" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphMain" Runat="Server">
	<table>
		<tr><th>Key</th><th>Value</th></tr>
	<%
		int loop1, loop2;
		NameValueCollection coll;
 
		// Load ServerVariable collection into NameValueCollection object.
		coll=Request.ServerVariables; 
		// Get names of all keys into a string array. 
		String[] arr1 = coll.AllKeys; 
		for (loop1 = 0; loop1 < arr1.Length; loop1++) 
		{
	%>
		<tr><td style="vertical-align:top;">
	<%
		   Response.Write(arr1[loop1] + "<br>");
	%>
		</td><td>
	<%
		   String[] arr2=coll.GetValues(arr1[loop1]);
		   for (loop2 = 0; loop2 < arr2.Length; loop2++) {
			  Response.Write(arr2[loop2].Replace("\r\n", "<br/>") + "<br/>");
		   }
	%>
		</td></tr>
	<%
}
	%>
	</table>
	<br />
	<b>Current Session information</b>
	<br />
	<% 
		for (loop1 = 0 ; loop1 < Session.Count ; loop1++)
		{
			Response.Write(Session.Keys[loop1].ToString() + " = " + Session[loop1].ToString() + "<br/>");
		}
	%>
	<br />
	<br />
    <div id="testArea" runat="server">
    </div>
</asp:Content>

