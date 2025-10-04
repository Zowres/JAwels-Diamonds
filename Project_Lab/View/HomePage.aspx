<%@ Page Title="" Language="C#" MasterPageFile="~/View/MasterPage/NavbarCustomer.Master" AutoEventWireup="true" CodeBehind="HomePage.aspx.cs" Inherits="Project_Lab.View.HomePage" %>
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


        
        .btn-view {
            background-color: #28a745;
            color: white;
            padding: 8px 14px;
            border: none;
            border-radius: 4px;
            cursor: pointer;
            font-weight: 600;
            transition: background-color 0.3s ease;
        }

        .btn-view:hover {
            background-color: #218838;
        }
</style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Home page</h1>
    <br />
    <br />
    <div class="grid-container">
        <asp:GridView ID="JewelGridView" CssClass="gridview-table" runat="server" AutoGenerateColumns="False" OnRowCommand="JewelGridView_RowCommand">
            <Columns>
                <asp:BoundField DataField="JewelId" HeaderText="Jewel ID" SortExpression="JewelId"></asp:BoundField>
                <asp:BoundField DataField="JewelName" HeaderText="Jewel Name" SortExpression="JewelName"></asp:BoundField>
                <asp:BoundField DataField="JewelPrice" HeaderText="Jewel Price" SortExpression="JewelPrice"></asp:BoundField>
            
                <asp:TemplateField HeaderText="Action">
                    <ItemTemplate>
                        <asp:Button ID="ViewDetailButton" runat="server"
                            Text="View Detail"
                            CommandName="ViewDetail"
                            CommandArgument='<%# Eval("JewelId") %>' 
                            CssClass="btn-view"/>
                    </ItemTemplate>
                </asp:TemplateField>


            </Columns>    
            
        </asp:GridView>
    </div>
    <br />

    






</asp:Content>
