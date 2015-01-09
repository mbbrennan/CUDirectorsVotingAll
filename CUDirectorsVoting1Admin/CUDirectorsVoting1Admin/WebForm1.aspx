<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="CUDirectorsVoting1Admin.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Label ID="Label1" runat="server" Text="Year"></asp:Label>
        <asp:DropDownList ID="DropDownList1" runat="server"  ></asp:DropDownList>
  
  
    <br />
    <asp:Button ID="cmdSave" runat="server" Text="Save" OnClick="cmdSave_Click" />
    <asp:Button ID="cmdCancel" runat="server" Text="Cancel" />

</asp:Content>
