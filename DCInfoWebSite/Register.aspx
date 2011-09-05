<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Main.master" AutoEventWireup="true" CodeFile="Register.aspx.cs" Inherits="Register" %>


<asp:Content ID="Menu" ContentPlaceHolderID="cphMenu" runat="Server">
</asp:Content>
<asp:Content ID="Message" ContentPlaceHolderID="cphMessages" runat="Server">
</asp:Content>
<asp:Content ID="Content" ContentPlaceHolderID="cphMain" runat="Server">
	<asp:CreateUserWizard ID="CreateUserWizard1" runat="server" BackColor="#EFF3FB" BorderColor="#B5C7DE" BorderStyle="Solid" BorderWidth="1px" Font-Names="Verdana" Font-Size="0.8em">
		<ContinueButtonStyle BackColor="White" BorderColor="#507CD1" BorderStyle="Solid" BorderWidth="1px" Font-Names="Verdana" ForeColor="#284E98" />
		<CreateUserButtonStyle BackColor="White" BorderColor="#507CD1" BorderStyle="Solid" BorderWidth="1px" Font-Names="Verdana" ForeColor="#284E98" />
		<TitleTextStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
		<WizardSteps>
			<asp:CreateUserWizardStep ID="CreateUserWizardStep1" runat="server">
			</asp:CreateUserWizardStep>
			<asp:CompleteWizardStep ID="CompleteWizardStep1" runat="server">
			</asp:CompleteWizardStep>
		</WizardSteps>
		<HeaderStyle BackColor="#284E98" BorderColor="#EFF3FB" BorderStyle="Solid" BorderWidth="2px" Font-Bold="True" Font-Size="0.9em" ForeColor="White" HorizontalAlign="Center" />
		<NavigationButtonStyle BackColor="White" BorderColor="#507CD1" BorderStyle="Solid" BorderWidth="1px" Font-Names="Verdana" ForeColor="#284E98" />
		<SideBarButtonStyle BackColor="#507CD1" Font-Names="Verdana" ForeColor="White" />
		<SideBarStyle BackColor="#507CD1" Font-Size="0.9em" VerticalAlign="Top" />
		<StepStyle Font-Size="0.8em" />
	</asp:CreateUserWizard>
</asp:Content>


