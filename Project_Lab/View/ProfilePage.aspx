<%@ Page Title="" Language="C#" MasterPageFile="~/View/MasterPage/NavbarCustomer.Master" AutoEventWireup="true" CodeBehind="ProfilePage.aspx.cs" Inherits="Project_Lab.View.ProfilePage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .form-container {
            max-width: 500px;
            margin: 80px auto;
            padding: 40px 30px;
            background-color: #ffffff;
            border-radius: 12px;
            box-shadow: 0 4px 25px rgba(0, 0, 0, 0.08);
            font-family: 'Segoe UI', sans-serif;
        }

        .form-title {
            text-align: center;
            font-size: 30px;
            margin-bottom: 30px;
            color: #333;
        }

        .form-subtitle {
            font-size: 22px;
            margin-bottom: 20px;
            color: #444;
        }

        .divider {
            margin: 30px 0;
            border: none;
            height: 1px;
            background-color: #ddd;
        }

        .form-group {
            margin-bottom: 20px;
        }

        .form-label {
            display: block;
            font-weight: 600;
            margin-bottom: 6px;
            color: #444;
        }

        .form-value {
            display: block;
            font-size: 16px;
            color: #333;
            margin-top: 2px;
        }

        .form-input {
            width: 100%;
            padding: 10px 12px;
            font-size: 15px;
            border: 1px solid #ccc;
            border-radius: 6px;
            box-sizing: border-box;
        }

        .form-button {
            width: 100%;
            padding: 12px;
            background-color: #007bff;
            border: none;
            color: white;
            font-size: 16px;
            border-radius: 8px;
            cursor: pointer;
            transition: background-color 0.3s ease;
        }

        .form-button:hover {
            background-color: #0056b3;
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
    <h1 class="form-title">Profile</h1>

    <div class="form-container">

        <div class="form-group">
            <asp:Label ID="Label1" runat="server" Text="Username:" CssClass="form-label" />
            <asp:Label ID="usernamelbL" runat="server" CssClass="form-value" />
        </div>

        <div class="form-group">
            <asp:Label ID="Label2" runat="server" Text="Email:" CssClass="form-label" />
            <asp:Label ID="emailLbl" runat="server" CssClass="form-value" />
        </div>

        <div class="form-group">
            <asp:Label ID="Label3" runat="server" Text="Gender:" CssClass="form-label" />
            <asp:Label ID="genderLbl" runat="server" CssClass="form-value" />
        </div>

        <div class="form-group">
            <asp:Label ID="Label4" runat="server" Text="Role:" CssClass="form-label" />
            <asp:Label ID="roleLbl" runat="server" CssClass="form-value" />
        </div>

        <hr class="divider" />

        <h2 class="form-subtitle">Change Password</h2>

        <div class="form-group">
            <asp:Label ID="oldPasswordLbl" runat="server" Text="Old Password" CssClass="form-label" />
            <asp:TextBox ID="oldPasswordTB" runat="server" TextMode="Password" CssClass="form-input" />
        </div>

        <div class="form-group">
            <asp:Label ID="newPasswordLbl" runat="server" Text="New Password" CssClass="form-label" />
            <asp:TextBox ID="newPasswordTB" runat="server" TextMode="Password" CssClass="form-input" />
        </div>

        <div class="form-group">
            <asp:Label ID="confirmPasswordLbl" runat="server" Text="Confirm Password" CssClass="form-label" />
            <asp:TextBox ID="confirmPasswordTB" runat="server" TextMode="Password" CssClass="form-input" />
        </div>

        <div class="form-group">
            <asp:Button ID="changePasswordBtn" runat="server" Text="Submit" CssClass="form-button" OnClick="changePasswordBtn_Click" />
        </div>

        <asp:Label ID="LblerrorMsg" runat="server" CssClass="form-error" />
    </div>

</asp:Content>
