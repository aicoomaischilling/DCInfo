<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Main.master" AutoEventWireup="true" CodeFile="Recovery.aspx.cs" Inherits="Recovery" %>


<asp:Content ID="Menu" ContentPlaceHolderID="cphMenu" runat="Server">
</asp:Content>

<asp:Content ID="Message" ContentPlaceHolderID="cphMessages" runat="Server">
</asp:Content>

<asp:Content ID="Content" ContentPlaceHolderID="cphMain" Runat="Server">
	<asp:PasswordRecovery ID="PasswordRecovery" runat="server">
	</asp:PasswordRecovery>
</asp:Content>


