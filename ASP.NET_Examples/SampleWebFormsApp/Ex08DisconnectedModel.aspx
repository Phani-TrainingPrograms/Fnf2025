<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Ex08DisconnectedModel.aspx.cs" Inherits="SampleWebFormsApp.Ex08DisconnectedModel" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <h1>Employee Database</h1>
        <div>
            <asp:Repeater runat="server" ID="rpEmployees" OnItemCommand="rpEmployees_ItemCommand">
                <HeaderTemplate>
                    <table border="1">
                        <tr>
                            <th>Employee ID</th>
                            <th>Employee Name</th>
                            <th>Employee Address</th>
                            <th>Employee Salary</th>
                            <th>Dept id</th>
                            <th>Options</th>
                        </tr>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr>
                        <td><%# Eval("EmpId") %></td>
                        <td><%# Eval("EmpName") %></td>
                        <td><%# Eval("EmpAddress") %></td>
                        <td><%# Eval("EmpSalary") %></td>
                        <td><%# Eval("DeptID") %></td>
                        <td>
                            <asp:LinkButton Text="Edit" runat="server" CommandName="Edit" CommandArgument='<%# Eval("EmpId") %>'/>
                            <asp:LinkButton Text="Delete" runat="server" CommandName="Delete" CommandArgument='<%# Eval("EmpId") %>'/>
                        </td>
                    </tr>
                </ItemTemplate>
                <FooterTemplate>
                    </table>
                </FooterTemplate>
            </asp:Repeater>
        </div>
        <div>
            <asp:Label runat="server" ID="lblError" ForeColor="Red" BorderColor="Green" BorderStyle="Dotted" Height="149px" Width="679px"/>
        </div>
    </form>
</body>
</html>
