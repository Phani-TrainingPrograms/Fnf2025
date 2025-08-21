<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Ex07DisplayProducts.aspx.cs" Inherits="SampleWebFormsApp.Ex07DisplayProducts" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
        .section{
            display:inline-block; width:45%;
            vertical-align:top;
            margin-left:10px
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <h1>Example on Session and Application State Management</h1>
        <div>
            <hr />
            <div class="section">
                <asp:ListBox runat="server" ID="lstItems" Height="505px" Width="387px" AutoPostBack="True" OnSelectedIndexChanged="lstItems_SelectedIndexChanged" />
            </div>
            <div class="section">
            <h2>Details of the Selected Product</h2>
            <hr />
            <p>
                ProductID: <asp:Label ID="lblID" runat="server" />
            </p>
            <p>
                ProductName:
                <asp:Label ID="lblName" runat="server" />
            </p>
            <p>
                <asp:Image ID="imgImage" runat="server" />
            </p>
            <p>
                Product Cost:
                <asp:Label ID="lblCost" runat="server" />
            </p>
            </div>
        </div>
        <div>
            
                <asp:DataList runat="server" ID="dtList" RepeatColumns="5" RepeatDirection="Horizontal" Width="740px">
                    <HeaderTemplate>
                        <h1>List of Recently viewed Items</h1>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <div style="background-color:orangered">
                            <h2><%# Eval("ProductName") %></h2>
                            <hr />
                            <p>
                                <image src='/Images/<%# Eval("ProductImage") %>' alt="Product Image" />
                            </p>
                            <p>
                                Item is priced at <%# Eval("ProductCost") %>
                            </p>
                        </div>
                    </ItemTemplate>
                    <AlternatingItemTemplate>
                        <div style="background-color: greenyellow">
                            <h2><%# Eval("ProductName") %></h2>
                            <hr />
                            <p>
                                <image src='/Images/<%# Eval("ProductImage") %>' alt="Product Image" />
                            </p>
                            <p>
                                Item is priced at <%# Eval("ProductCost") %>
                            </p>
                        </div>
                    </AlternatingItemTemplate>
                </asp:DataList>
        </div>
        
    </form>
</body>
</html>
