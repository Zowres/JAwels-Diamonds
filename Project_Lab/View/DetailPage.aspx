<%@ Page Title="" Language="C#" MasterPageFile="~/View/MasterPage/NavbarCustomer.Master" AutoEventWireup="true" CodeBehind="DetailPage.aspx.cs" Inherits="Project_Lab.View.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <style>
        .jewel-detail-container {
            max-width: 600px;
            margin: 50px auto;
            padding: 30px;
            background-color: #fefefe;
            border-radius: 12px;
            box-shadow: 0 4px 20px rgba(0, 0, 0, 0.1);
            font-family: 'Segoe UI', sans-serif;
        }

        .jewel-title {
            text-align: center;
            font-size: 32px;
            margin-bottom: 30px;
            color: #333;
        }

        .jewel-info p {
            font-size: 18px;
            margin: 12px 0;
            color: #555;
        }

        .jewel-value {
            font-weight: normal;
            color: #000;
        }

        .jewel-actions {
            margin-top: 30px;
            text-align: center;
        }

        .action-button {
            padding: 10px 20px;
            font-size: 16px;
            margin: 8px;
            border: none;
            border-radius: 6px;
            cursor: pointer;
            color: white;
            transition: background-color 0.3s ease;
        }

        .action-button.update {
            background-color: #17a2b8;
        }

        .action-button.update:hover {
            background-color: #138496;
        }

        .action-button.delete {
            background-color: #dc3545;
        }

        .action-button.delete:hover {
            background-color: #c82333;
        }

        .action-button.add {
            background-color: #28a745;
        }

        .action-button.add:hover {
            background-color: #218838;
        }

    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="jewel-detail-container">
        <h1 class="jewel-title">Jewel Details</h1>

        <div class="jewel-info">
            <p><strong>Name:</strong> <asp:Label ID="JewelName" runat="server" Text="" CssClass="jewel-value" /></p>
            <p><strong>Category:</strong> <asp:Label ID="CategoryName" runat="server" Text="" CssClass="jewel-value" /></p>
            <p><strong>Brand:</strong> <asp:Label ID="JewelBrandName" runat="server" Text="" CssClass="jewel-value" /></p>
            <p><strong>Country of Origin:</strong> <asp:Label ID="JewelCountry" runat="server" Text="" CssClass="jewel-value" /></p>
            <p><strong>Class:</strong> <asp:Label ID="JewelClass" runat="server" Text="" CssClass="jewel-value" /></p>
            <p><strong>Price:</strong> <asp:Label ID="JewelPrice" runat="server" Text="" CssClass="jewel-value" /></p>
            <p><strong>Release Year:</strong> <asp:Label ID="JewelYear" runat="server" Text="" CssClass="jewel-value" /></p>
        </div>

        <div class="jewel-actions">
            <asp:Button ID="UpdateJewel" runat="server" Text="Update Jewel" CssClass="action-button update" Visible="false" OnClick="UpdateJewel_Click" />
            <asp:Button ID="DeleteJewel" runat="server" Text="Delete Jewel" CssClass="action-button delete" Visible="false" OnClick="DeleteJewel_Click" />
            <asp:Button ID="AddToCart" runat="server" Text="Add to Cart" CssClass="action-button add" Visible="false" OnClick="AddToCart_Click" />
        </div>
    </div>

</asp:Content>
