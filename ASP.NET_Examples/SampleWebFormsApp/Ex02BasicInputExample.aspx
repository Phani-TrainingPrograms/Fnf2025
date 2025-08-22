<%@ Page Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Ex02BasicInputExample.aspx.cs" Inherits="SampleWebFormsApp.Ex02BasicInputExample" %>
<asp:Content ContentPlaceHolderID="mainContent" runat="server">

        <div>
            <h1 class="auto-style1" style="background-color: #0066FF">Welcome to ASP.NET Programming....</h1>
            <p style="background-color: #CCFFFF">
                ASP.NET is a Rapid Application Development tool for developing Web Apps at an industrial Scale. It is fast to develop and execute.
            </p>
            <p style="background-color: #CCFFFF">
                Lets try an example of a basic input demo.....</p>
        </div>
        <p style="background-color: #CCFFFF">
            &nbsp;</p>
        <h2>Enter UR Registration Details:</h2>
        <p>
            Enter the Name:
            <asp:TextBox ID="txtName" runat="server" BorderStyle="Dotted" Height="49px"  Width="370px"></asp:TextBox>
        </p>
        <p>
            Enter the Email Address: <asp:TextBox ID="txtEmail" runat="server" Height="48px" TextMode="Email" Width="454px"></asp:TextBox>
        </p>
        <p>
            &nbsp;</p>
        <p>
            Enter the Salary:
            <asp:TextBox ID="txtSalary" runat="server" Height="52px" TextMode="Number" Width="296px"></asp:TextBox>
        </p>
        <p>
            <asp:Button ID="btnSubmit" runat="server" Height="55px" OnClick="btnSubmit_Click" Text="Submit" Width="189px" />
        </p>
        <asp:Label ID="lblDisplay" runat="server" BorderColor="#FF3300" BorderStyle="Dotted" Height="172px" Width="618px"></asp:Label>
</asp:Content>
