<%@ Page Title="" Language="C#" MasterPageFile="~/View/MasterPage/NavbarCustomer.Master" AutoEventWireup="true" CodeBehind="HandleOrderPage.aspx.cs" Inherits="Project_Lab.View.AdminPage.HandleOrderPage" %>
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

        .gridview-table {
            width: 100%;
            border-collapse: collapse;
            font-family: 'Segoe UI', sans-serif;
            box-shadow: 0 0 8px rgba(0, 0, 0, 0.05);
        }

        .gridview-table th, .gridview-table td {
            padding: 12px 16px;
            border-bottom: 1px solid #ddd;
            text-align: left;
        }

        .gridview-table th {
            background-color: #f1f1f1;
            font-weight: 600;
            color: #333;
        }

        .gridview-table tr:hover {
            background-color: #f9f9f9;
        }

        .btn-ship, .btn-confirm {
            background-color: #007bff;
            color: white;
            padding: 6px 12px;
            margin-right: 6px;
            border: none;
            border-radius: 5px;
            cursor: pointer;
            font-weight: 500;
            font-size: 13px;
        }

        .btn-confirm {
            background-color: #28a745;
        }

        .btn-ship:hover {
            background-color: #0056b3;
        }

        .btn-confirm:hover {
            background-color: #218838;
        }

        .status-label {
            color: #d9534f;
            font-style: italic;
            font-size: 13px;
            margin-left: 8px;
        }

    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h1>Handle Order Page</h1>
    <br />

    <asp:GridView ID="HandleOrderGV" runat="server" AutoGenerateColumns="False" 
        CssClass="gridview-table" OnRowDataBound="HandleOrderGV_RowDataBound" 
        OnRowCommand="HandleOrderGV_RowCommand" GridLines="None">
    
        <Columns>
            <asp:BoundField DataField="TransactionId" HeaderText="Transaction ID" />
            <asp:BoundField DataField="UserId" HeaderText="User ID" />
            <asp:BoundField DataField="TransactionStatus" HeaderText="Status" />

            <asp:TemplateField HeaderText="Actions">
                <ItemTemplate>
                    <asp:Button ID="btnShip" runat="server" Text="🚚 Ship" CssClass="btn-ship"
                        CommandName="ShipPackage" CommandArgument='<%# Eval("TransactionId") %>' />

                    <asp:Button ID="btnConfirm" runat="server" Text="✔ Confirm" CssClass="btn-confirm"
                        CommandName="Confirm" CommandArgument='<%# Eval("TransactionId") %>' />

                    <asp:Label ID="confirmUserLbl" runat="server" CssClass="status-label" 
                        Text="⏳ Waiting for user confirmation..." Visible="false" />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>


</asp:Content>
