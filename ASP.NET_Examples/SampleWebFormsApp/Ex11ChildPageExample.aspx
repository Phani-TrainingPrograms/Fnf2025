<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Ex11ChildPageExample.aspx.cs" Inherits="SampleWebFormsApp.Ex11ChildPageExample" %>
<asp:Content runat="server" ContentPlaceHolderID="mainContent">
    <h1>Welcome to Child Pages</h1>
    <hr />
    <p>
        Child Pages cannot have any direct HTML Elements in it. The elements must always be within the Content control. 
    </p>
    <p>
        Please explore other pages and see how it behaves....
    </p>
</asp:Content>
