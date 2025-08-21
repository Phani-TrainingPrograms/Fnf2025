<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Ex01Basics.aspx.cs" Inherits="SampleWebFormsApp.Ex01Basics" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <%Response.Write("Welcome to ASP.NET");%><br />
            <%="Shorter form of writing Response.Write"%><br />
            <%="The Current time in the server is " + DateTime.Now %>
        </div>
    </form>
</body>
</html>
