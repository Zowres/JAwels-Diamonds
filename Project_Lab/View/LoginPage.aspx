<%@ Page Title="" Language="C#" MasterPageFile="~/View/MasterPage/NavbarCustomer.Master" AutoEventWireup="true" CodeBehind="LoginPage.aspx.cs" Inherits="Project_Lab.View.LoginPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .form-container {
            max-width: 400px;
            margin: 80px auto;
            padding: 40px 30px;
            background-color: #ffffff;
            border-radius: 12px;
            box-shadow: 0 4px 25px rgba(0, 0, 0, 0.08);
            font-family: 'Segoe UI', sans-serif;
        }

        .form-title {
            text-align: center;
            font-size: 28px;
            margin-bottom: 30px;
            color: #333;
        }

        .form-group {
            margin-bottom: 20px;
        }

        .form-label {
            display: block;
            margin-bottom: 6px;
            font-weight: 600;
            color: #444;
        }

        .form-input {
            width: 100%;
            padding: 10px 12px;
            font-size: 15px;
            border: 1px solid #ccc;
            border-radius: 6px;
            box-sizing: border-box;
        }

        .checkbox-group {
            display: flex;
            align-items: center;
            gap: 10px;
            font-size: 14px;
        }

        .form-button {
            width: 100%;
            padding: 12px;
            background-color: #28a745;
            border: none;
            color: white;
            font-size: 16px;
            border-radius: 8px;
            cursor: pointer;
            transition: background-color 0.3s ease;
        }

        .form-button:hover {
            background-color: #218838;
        }

        .form-error {
            display: block;
            margin-top: 15px;
            color: red;
            text-align: center;
            font-weight: bold;
        }



    </style>

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

         <div class="form-container">
            <h1 class="form-title">Login</h1>

            <div class="form-group">
                <asp:Label ID="EmailLbl" runat="server" Text="Email" CssClass="form-label" />
                <asp:TextBox ID="EmailTB" runat="server" TextMode="Email" CssClass="form-input" />
            </div>

            <div class="form-group">
                <asp:Label ID="PasswordLbl" runat="server" Text="Password" CssClass="form-label" />
                <asp:TextBox ID="PasswordTB" runat="server" TextMode="Password" CssClass="form-input" />
            </div>

            <div class="form-group checkbox-group">
                <asp:CheckBox ID="RememberMe" runat="server" />
                <label for="RememberMe">Remember Me</label>
            </div>

            <div class="form-group">
                <asp:Button ID="Login" runat="server" Text="Login" CssClass="form-button" OnClick="Login_Click" />
            </div>

            <asp:Label ID="ErrorMessage" runat="server" CssClass="form-error" />
        </div>



</asp:Content>
