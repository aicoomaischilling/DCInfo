<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Main.master" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

<asp:Content ID="Menu" ContentPlaceHolderID="cphMenu" runat="Server">
</asp:Content>

<asp:Content ID="Message" ContentPlaceHolderID="cphMessages" runat="Server">
	<asp:ValidationSummary ID="DCInfoLoginValidationSummary" runat="server" ValidationGroup="DCInfoLogin" BorderColor="Red" BorderStyle="Solid" BorderWidth="2px" Font-Bold="True" Font-Names="Arial, Helvetica" ForeColor="Red" />	
</asp:Content>

<asp:Content ID="Content" ContentPlaceHolderID="cphMain" Runat="Server">
	<table style="margin: 10px 0px 10px 0px;">
		<tr>
			<td>Login with a DCInfo account</td><td style="width: 30px"></td><td>Login with OpenID</td>
		</tr>
		<tr>
			<td>
				<asp:Login ID="DCInfoLogin" runat="server" EnableTheming="true"/>
				</asp:Login>				
			</td>
			<td style="width: 30px"></td>
			<td>
				<h1>Coming soon</h1>
			</td>
		</tr>
		<tr>
			<td style="background: #DDDDDD; border: 2px; border-color: Black; text-align: center;">
				<a href="Recovery.aspx">Forgot your username/password?</a><br/><br/>
				Need a DCInfo account?<br/>
				<a href="Register.aspx">Create Account</a>
			</td>
		</tr>
	</table>	
</asp:Content>

