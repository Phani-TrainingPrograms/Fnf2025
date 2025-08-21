<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Ex03CalcProgram.aspx.cs" Inherits="SampleWebFormsApp.Ex03CalcProgram" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>Calc Program</h1>
            <hr />
            <div>
                <p>Enter the First Value:<asp:TextBox ID="txtFirstValue" runat="server" TextMode="Number"></asp:TextBox>
                </p>
                <p>Enter the Second Value:<asp:TextBox ID="txtSecondValue" runat="server" TextMode="Number"></asp:TextBox>
                </p>
                <p>Select the Options:<asp:DropDownList ID="dpOptions" runat="server" Height="26px" Width="202px" AutoPostBack="True" OnSelectedIndexChanged="dpOptions_SelectedIndexChanged">
                    <asp:ListItem>Add</asp:ListItem>
                    <asp:ListItem>Subtract</asp:ListItem>
                    <asp:ListItem>Multiply</asp:ListItem>
                    <asp:ListItem>Divide</asp:ListItem>
                    </asp:DropDownList>
                </p>
                <p>
                    <asp:Button Text="Get Result" runat="server" ID="btnResult" OnClick="btnResult_Click" /> </p>
                <p>
                    The Result is: <asp:Label Text="" runat="server" ID="lblDisplay" />
                </p>
            </div>
        </div>
    </form>
</body>
</html>
