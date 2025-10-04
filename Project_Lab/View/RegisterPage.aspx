<%@ Page Title="" Language="C#" MasterPageFile="~/View/MasterPage/NavbarCustomer.Master" AutoEventWireup="true" CodeBehind="RegisterPage.aspx.cs" Inherits="Project_Lab.View.RegisterPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .form-container {
            max-width: 500px;
            margin: 60px auto;
            padding: 40px;
            background-color: #ffffff;
            border-radius: 12px;
            box-shadow: 0 4px 20px rgba(0, 0, 0, 0.1);
            font-family: 'Segoe UI', sans-serif;
        }

        .form-title {
            text-align: center;
            font-size: 30px;
            margin-bottom: 30px;
            color: #333;
        }

        .form-group {
            margin-bottom: 20px;
        }

        .form-label {
            display: block;
            margin-bottom: 8px;
            font-weight: 600;
            color: #444;
        }

        .form-input {
            width: 100%;
            padding: 10px 12px;
            font-size: 16px;
            border: 1px solid #ccc;
            border-radius: 6px;
            box-sizing: border-box;
        }

        .form-radio {
            margin-top: 6px;
            font-size: 15px;
        }

        .form-calendar {
            margin-top: 10px;
            border: 1px solid #ddd;
            padding: 8px;
            border-radius: 8px;
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
            transition: background-color 0.3s;
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


    <div class="form-container">
        <h1 class="form-title">Register</h1>

        <div class="form-group">
            <asp:Label ID="EmailLbl" runat="server" Text="Email" CssClass="form-label" />
            <asp:TextBox ID="emailTB" runat="server" TextMode="Email" CssClass="form-input" />
        </div>

        <div class="form-group">
            <asp:Label ID="UsernameLbl" runat="server" Text="Username" CssClass="form-label" />
            <asp:TextBox ID="UsernameTB" runat="server" CssClass="form-input" />
        </div>

        <div class="form-group">
            <asp:Label ID="PasswordLbl" runat="server" Text="Password" CssClass="form-label" />
            <asp:TextBox ID="PasswordTB" runat="server" TextMode="Password" CssClass="form-input" />
        </div>

        <div class="form-group">
            <asp:Label ID="ConfirmPasswordLbl" runat="server" Text="Confirm Password" CssClass="form-label" />
            <asp:TextBox ID="CPasswordTB" runat="server" TextMode="Password" CssClass="form-input" />
        </div>

        <div class="form-group">
            <asp:Label ID="GenderLbl" runat="server" Text="Gender" CssClass="form-label" />
            <asp:RadioButtonList ID="GenderRBL" runat="server" CssClass="form-radio">
                <asp:ListItem>Male</asp:ListItem>
                <asp:ListItem>Female</asp:ListItem>
            </asp:RadioButtonList>
        </div>

        <div class="form-group">
            <asp:Label ID="DobLbl" runat="server" Text="Date of Birth" CssClass="form-label" />
            <asp:Calendar ID="DobCalender" runat="server" CssClass="form-calendar" />
        </div>

        <div class="form-group">
            <asp:Button ID="RegisterBtn" runat="server" Text="Register" CssClass="form-button" OnClick="RegisterBtn_Click" />
        </div>

        <asp:Label ID="ErrorMessage" runat="server" CssClass="form-error" />
    </div>



</asp:Content>


