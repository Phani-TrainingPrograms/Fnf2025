<%@ Page Language="C#" Trace="true" AutoEventWireup="true" CodeBehind="Ex04DatabaseAccess.aspx.cs" Inherits="SampleWebFormsApp.Ex04DatabaseAccess" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
        .section{
            display:inline-block;
            width:47%;
            margin-left:5px;
        }    
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>Department Manager</h1>
            <hr />
            <div class="section">
                <p style="vertical-align:top">
                    List of Departments:
                    <asp:ListBox runat="server" ID ="lstDepartments" Height="447px" Width="456px">

                    </asp:ListBox> 
                </p>
            </div>
            <div class="section">
                <h2>New Employee Details</h2>
                <hr />
                <p>
                    Enter the EmpName: <asp:TextBox runat="server" ID="txtName"/>
                </p>
                <p>
                    Enter the Emp Email:
                    <asp:TextBox runat="server" ID="txtEmail" />
                </p>
                <p>
                    Enter the Emp Salary:
                    <asp:TextBox runat="server" ID="txtSalary" TextMode="Number" />
                </p>
                <p>
                    <asp:Button Text="Save Changes" runat="server" ID="btnSave" OnClick="btnSave_Click"/>
                </p>
            </div>
        </div>
    </form>
</body>
</html>
