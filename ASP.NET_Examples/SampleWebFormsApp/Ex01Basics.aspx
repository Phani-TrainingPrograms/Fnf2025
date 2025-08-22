<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site1.Master" CodeBehind="Ex01Basics.aspx.cs" Inherits="SampleWebFormsApp.Ex01Basics" %>

<asp:Content runat="server" ContentPlaceHolderID="mainContent">
    <div>
        <%Response.Write("Welcome to ASP.NET");%><br />
        <%="Shorter form of writing Response.Write"%><br />
        <%="The Current time in the server is " + DateTime.Now %>
    </div>
</asp:Content>   
