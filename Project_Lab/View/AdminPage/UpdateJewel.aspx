<%@ Page Title="" Language="C#" MasterPageFile="~/View/MasterPage/NavbarCustomer.Master" AutoEventWireup="true" CodeBehind="UpdateJewel.aspx.cs" Inherits="Project_Lab.View.AdminPage.UpdateJewel" %>
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
            max-width: 400px;
            margin: 0 auto;
            padding: 30px;
            background-color: #ffffff;
            border-radius: 12px;
            box-shadow: 0 10px 20px rgba(0, 0, 0, 0.1);
            font-family: 'Segoe UI', sans-serif;
        }

        .form-group {
            margin-bottom: 18px;
        }

        .form-label {
            display: block;
            margin-bottom: 6px;
            font-weight: 500;
            color: #34495e;
        }

        .form-input, .form-select {
            width: 100%;
            padding: 10px 12px;
            font-size: 14px;
            border: 1px solid #ccc;
            border-radius: 8px;
            transition: border-color 0.2s ease;
        }

        .form-input:focus, .form-select:focus {
            border-color: #3498db;
            outline: none;
        }

        .form-actions {
            text-align: center;
            margin-top: 20px;
        }

        .btn-submit {
            padding: 12px 24px;
            font-size: 15px;
            font-weight: bold;
            color: white;
            background-color: #2980b9;
            border: none;
            border-radius: 8px;
            cursor: pointer;
            transition: background-color 0.2s ease;
        }

        .btn-submit:hover {
            background-color: #2471a3;
        }

        .error-message {
            margin-top: 14px;
            color: #e74c3c;
            text-align: center;
            font-weight: 500;
        }

    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1 >Update Jewel</h1>

    <div class="form-container">
        <div class="form-group">
            <asp:Label ID="NameJewellbl" runat="server" AssociatedControlID="JewelNameTB" Text="Jewel Name" CssClass="form-label" />
            <asp:TextBox ID="JewelNameTB" runat="server" CssClass="form-input" />
        </div>

        <div class="form-group">
            <asp:Label ID="CategoryLbl" runat="server" AssociatedControlID="ddlCategory" Text="Jewel Category" CssClass="form-label" />
            <asp:DropDownList ID="ddlCategory" runat="server" CssClass="form-select" AutoPostBack="true" />
        </div>

        <div class="form-group">
            <asp:Label ID="BrandLbl" runat="server" AssociatedControlID="ddlBrand" Text="Jewel Brand" CssClass="form-label" />
            <asp:DropDownList ID="ddlBrand" runat="server" CssClass="form-select" AutoPostBack="true" />
        </div>

        <div class="form-group">
            <asp:Label ID="PriceLbl" runat="server" AssociatedControlID="JewelPriceTB" Text="Jewel Price" CssClass="form-label" />
            <asp:TextBox ID="JewelPriceTB" runat="server" CssClass="form-input" />
        </div>

        <div class="form-group">
            <asp:Label ID="JewelYearLbl" runat="server" AssociatedControlID="JewelYearTB" Text="Jewel Year" CssClass="form-label" />
            <asp:TextBox ID="JewelYearTB" runat="server" CssClass="form-input" />
        </div>

        <div class="form-actions">
            <asp:Button ID="UpdateJewelBtn" runat="server" Text="💎 Update Jewel" CssClass="btn-submit" OnClick="UpdateJewelBtn_Click" />
        </div>

        <asp:Label ID="ErrorMsg" runat="server" CssClass="error-message" />
    </div>

</asp:Content>
