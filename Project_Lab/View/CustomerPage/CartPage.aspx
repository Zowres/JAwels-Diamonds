<%@ Page Title="" Language="C#" MasterPageFile="~/View/MasterPage/NavbarCustomer.Master" AutoEventWireup="true" CodeBehind="CartPage.aspx.cs" Inherits="Project_Lab.View.CustomerPage.CartPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <style>
    h1 {
        text-align: center;
        font-size: 2.5rem;
        font-weight: bold;
        margin-top: 40px;
        color: #343a40;
        font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif;
        position: relative;
    }
    h1::after {
        content: '';
        display: block;
        width: 80px;
        height: 4px;
        background-color: #007bff;
        margin: 10px auto 0;
        border-radius: 2px;
    }

    .cart-grid-container {
        display: flex;
        justify-content: center;
        margin-top: 40px;
    }

    .styled-cart-gridview {
        width: 100%;
        border-collapse: collapse;
        font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif;
        font-size: 16px;
        box-shadow: 0 4px 8px rgba(0, 0, 0, 0.1);
    }

    .styled-cart-gridview th {
        background-color: #007bff;
        color: white;
        padding: 12px;
        text-align:left;
    }

    .styled-cart-gridview td {
        padding: 10px;
        border-bottom: 1px solid #dee2e6;
    }

    .styled-cart-gridview tr:nth-child(even) {
        background-color: #f8f9fa;
    }

    .styled-cart-gridview tr:hover {
        background-color: #e9ecef;
    }

    .quantity-box {
        padding: 4px;
        border-radius: 4px;
        border: 1px solid #ccc;
        text-align: center;
    }

    .btnAct {
        padding: 8px 12px;
        background-color: #28a745;
        color: white;
        border: none;
        border-radius: 4px;
        cursor: pointer;
    }

    .btnAct:hover {
        background-color: #218838;
    }


    p {
        font-size: 16px;
        margin: 20px auto;
        text-align: center;
    }

    .ddlPaymentMethodC {
        padding: 6px;
        border-radius: 5px;
        font-size: 15px;
    }

    .btnClearCartC, .btnCheckoutC {
        display: block;
        margin: 15px auto;
        padding: 10px 20px;
        font-size: 16px;
        background-color: #17a2b8;
        border: none;
        border-radius: 6px;
        color: white;
        cursor: pointer;
    }

    .btnClearCartC:hover, .btnCheckoutC:hover {
        background-color: #138496;
    }

    .lblMessageC {
        text-align: center;
        display: block;
        margin-top: 10px;
        font-weight: bold;
    }
</style>


</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Cart Page</h1>

    <div class="cart-grid-container">

        <asp:GridView ID="CartGridView" runat="server" CssClass="styled-cart-gridview" AutoGenerateColumns="False" OnRowDeleting="OnRowDeleting" OnRowEditing="OnRowEditing" OnRowCancelingEdit="CartGridView_RowCancelingEdit">
            <Columns>
                <asp:BoundField DataField="JewelId" HeaderText="Jewel ID" SortExpression="JewelId"></asp:BoundField>
                <asp:BoundField DataField="JewelName" HeaderText="Jewel Name" SortExpression="JewelName"></asp:BoundField>
                <asp:BoundField DataField="JewelPrice" HeaderText="Jewel Price" SortExpression="JewelPrice"></asp:BoundField>
                <asp:BoundField DataField="Brand" HeaderText="Brand Name" SortExpression="Brand"></asp:BoundField>

                <asp:TemplateField HeaderText="Quantity">
                    <ItemTemplate>
                        <asp:TextBox ID="txtQuantity" runat="server" Text='<%# Bind("Quantity") %>' Width="60px" CssClass="quantity-box" />
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:BoundField DataField="Subtotal" HeaderText="Subtotal" />
                <asp:CommandField ShowCancelButton="False" ShowDeleteButton="True" ShowEditButton="True" ButtonType="Button" ShowHeader="True" HeaderText="Actions" EditText="Update"></asp:CommandField>
            </Columns>
        </asp:GridView>


    </div>

        <hr />
        <br />
        <br />
        <br />
        <p>
            Total Price: <asp:Label ID="lblTotal" runat="server" Font-Bold="true" />
        </p>

        <p>
            Payment Method:
            <br />
            <asp:DropDownList ID="ddlPaymentMethod" runat="server" CssClass="ddlPaymentMethodC">
                <%--ini nanti diganti dari backend--%>
                <asp:ListItem Text="-- Select Payment Method --" Value="" />
                <asp:ListItem Text="Visa" Value="Visa" />
                <asp:ListItem Text="Bank Transfer" Value="BankTransfer" />
                <asp:ListItem Text="Credit Card" Value="CreditCard" />
            </asp:DropDownList>
        </p>

        <br />
        <br />
        <asp:Button ID="btnClearCart" runat="server" CssClass="btnClearCartC" Text="Clear Cart" onclick="btnClearCart_Click" />
        <br />
        <asp:Button ID="btnCheckout" runat="server" CssClass="btnCheckoutC" Text="Proceed to Checkout" onclick="btnCheckout_Click" />
        <br />
        <asp:Label ID="lblMessage" CssClass="lblMessageC" runat="server" ForeColor="Red" />



</asp:Content>
