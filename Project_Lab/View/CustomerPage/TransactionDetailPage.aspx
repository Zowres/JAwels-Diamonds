<%@ Page Title="" Language="C#" MasterPageFile="~/View/MasterPage/NavbarCustomer.Master" AutoEventWireup="true" CodeBehind="TransactionDetailPage.aspx.cs" Inherits="Project_Lab.View.CustomerPage.TransactionDetailPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .grid-container {
            display: flex;
            justify-content: center;
            margin-top: 30px;
        }
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
        .gridview-table {
            width: 100%;
            border-collapse: collapse;
            font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif;
            font-size: 16px;
            box-shadow: 0 4px 8px rgba(0, 0, 0, 0.1);
    
        }

        .gridview-table th {
            background-color: #007bff;
            color: white;
            padding: 12px;
            text-align: left;
        }

        .gridview-table td {
            padding: 12px;
            border-bottom: 1px solid #ddd;
        }

        .gridview-table tr:hover {
            background-color: #f9f9f9;
        }

    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Transaction Detail Page</h1>

    <div class="grid-container">
        <asp:GridView ID="TransactionGV" CssClass="gridview-table" runat="server" AutoGenerateColumns="false">
            <Columns>
                <asp:BoundField DataField="TransactionId" HeaderText="Transaction Id" SortExpression="TransactionId"></asp:BoundField>
                <asp:BoundField DataField="JewelName" HeaderText="Jewel Name" SortExpression="JewelName"></asp:BoundField>
                <asp:BoundField DataField="Quantity" HeaderText="Quantity" SortExpression="Quantity"></asp:BoundField>
            </Columns>

        </asp:GridView>
    </div>

</asp:Content>
