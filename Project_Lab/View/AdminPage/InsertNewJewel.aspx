<%@ Page Title="" Language="C#" MasterPageFile="~/View/MasterPage/NavbarCustomer.Master" AutoEventWireup="true" CodeBehind="InsertNewJewel.aspx.cs" Inherits="Project_Lab.View.AdminPage.InsertNewJewel" %>
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

        .form-container {
            max-width: 500px;
            margin: 60px auto;
            padding: 40px;
            background-color: #ffffff;
            border-radius: 12px;
            box-shadow: 0 4px 20px rgba(0, 0, 0, 0.1);
            font-family: 'Segoe UI', sans-serif;
        }

        .form-group {
            margin-bottom: 16px;
        }

        .form-label {
            display: block;
            margin-bottom: 6px;
            font-weight: 600;
            color: #555;
        }

        .form-input, .form-select {
            width: 100%;
            padding: 10px 12px;
            border: 1px solid #ccc;
            border-radius: 6px;
            font-size: 14px;
            transition: border-color 0.2s;
        }

        .form-input:focus, .form-select:focus {
            border-color: #007bff;
            outline: none;
        }

        .form-actions {
            margin-top: 20px;
        }

        .btn-submit, .btn-cancel {
            padding: 10px 16px;
            font-size: 14px;
            font-weight: 600;
            border: none;
            border-radius: 6px;
            cursor: pointer;
            margin-right: 10px;
            transition: background-color 0.2s ease;
        }

        .btn-submit {
            background-color: #28a745;
            color: white;
        }

        .btn-submit:hover {
            background-color: #218838;
        }

        .btn-cancel {
            background-color: #dc3545;
            color: white;
        }

        .btn-cancel:hover {
            background-color: #c82333;
        }

        .error-message {
            margin-top: 12px;
            color: red;
            font-style: italic;
            font-weight: 500;
        }

    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1 >Insert New Jewel</h1>

    <div class="form-container">
        <div class="form-group">
            <asp:Label ID="NameJewellbl" runat="server" AssociatedControlID="JewelNameTB" Text="Jewel Name" CssClass="form-label"></asp:Label>
            <asp:TextBox ID="JewelNameTB" runat="server" CssClass="form-input"></asp:TextBox>
        </div>

        <div class="form-group">
            <asp:Label ID="CategoryLbl" runat="server" AssociatedControlID="ddlCategory" Text="Jewel Category" CssClass="form-label"></asp:Label>
            <asp:DropDownList ID="ddlCategory" runat="server" AutoPostBack="true" CssClass="form-select"></asp:DropDownList>
        </div>

        <div class="form-group">
            <asp:Label ID="BrandLbl" runat="server" AssociatedControlID="ddlBrand" Text="Jewel Brand" CssClass="form-label"></asp:Label>
            <asp:DropDownList ID="ddlBrand" runat="server" AutoPostBack="true" CssClass="form-select"></asp:DropDownList>
        </div>

        <div class="form-group">
            <asp:Label ID="PriceLbl" runat="server" AssociatedControlID="JewelPriceTB" Text="Jewel Price" CssClass="form-label"></asp:Label>
            <asp:TextBox ID="JewelPriceTB" runat="server" CssClass="form-input"></asp:TextBox>
        </div>

        <div class="form-group">
            <asp:Label ID="JewelYearLbl" runat="server" AssociatedControlID="JewelYearTB" Text="Jewel Year" CssClass="form-label"></asp:Label>
            <asp:TextBox ID="JewelYearTB" runat="server" CssClass="form-input"></asp:TextBox>
        </div>

        <div class="form-actions">
            <asp:Button ID="SubmitJewel" runat="server" Text="💎 Insert Jewel" CssClass="btn-submit" OnClick="SubmitJewel_Click" />
            <asp:Button ID="CancelInsert" runat="server" Text="✖ Cancel" CssClass="btn-cancel" OnClick="CancelInsert_Click" />
        </div>

        <asp:Label ID="ErrorMsg" runat="server" CssClass="error-message"></asp:Label>
    </div>


</asp:Content>
