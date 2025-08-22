<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Ex09EditEmployee.aspx.cs" Inherits="SampleWebFormsApp.Ex09EditEmployee" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <h2>Edit Employee</h2>
        <hr />
        <div>
            <p>Enter the ID: <asp:TextBox runat="server" ID="txtId" Enabled="false"/></p>
            <p>Enter the Name: <asp:TextBox runat="server" ID="txtName"/></p>
            <p>Enter the Address: <asp:TextBox runat="server" ID="txtAddress"/></p>
            <p>Enter the Salary: <asp:TextBox runat="server" ID="txtSalary"/></p>
            <p>Enter the DeptId: <asp:TextBox runat="server" ID="txtDept"/></p>
            <p>
                <asp:Button ID="btnSave" Text="Save" runat="server" OnClick="btnSave_Click" />
            &nbsp;
                <asp:Button ID="btnBack" runat="server" OnClick="btnBack_Click" Text="Back" />
            </p>
        </div>
        <asp:Label ID="lblError" runat="server" BorderColor="#00CC00" BorderStyle="Dotted" ForeColor="Red" Height="126px" Width="438px"></asp:Label>
    </form>
</body>
</html>
