<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Ex05StateManagement.aspx.cs" Inherits="SampleWebFormsApp.Ex05StateManagement" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>User Registration</h2>
            <hr />
            <p>Enter the Name: <asp:TextBox runat="server" ID="txtName"/></p>
            <p>Enter the Email: <asp:TextBox runat="server" ID="txtEmail" TextMode="Email"/></p>
            <p>Enter the Date of Birth: <asp:TextBox runat="server" ID="txtDob" TextMode="Date"/></p>
            <p>
                <asp:Button Text="Save Info" runat="server" ID="btnSave" OnClick="btnSave_Click"/>
            </p>
        </div>
    </form>
</body>
</html>
