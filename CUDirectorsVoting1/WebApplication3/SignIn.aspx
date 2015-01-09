<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="SignIn.aspx.cs" Inherits="WebApplication3.SignIn" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Label ID="Label1" runat="server" Text="Member ID:"></asp:Label> <asp:TextBox ID="txtMemberID" runat="server"></asp:TextBox>

    <br />
    <asp:Label ID="Label2" runat="server" Text="PIN:"></asp:Label> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp; <asp:TextBox ID="txtPIN" runat="server"></asp:TextBox>
    <br />
    <br />
    <asp:Button ID="cmdLogin" runat="server" Text="Login" OnClick="cmdLogin_Click" />
&nbsp;&nbsp;&nbsp;
    <asp:Button ID="cmdCancel" runat="server" Text="Cancel" />
</asp:Content>
