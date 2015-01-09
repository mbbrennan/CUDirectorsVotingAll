<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Main.aspx.cs" Inherits="WebApplication3.Main" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:DropDownList ID="DropDownList1" runat="server" DataSourceID="SqlDataSource2" DataTextField="_Year" DataValueField="_Year" AutoPostBack="true"></asp:DropDownList>
    <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:CUDirConnectionString %>" SelectCommand="SELECT [_Year] FROM [_Year]"></asp:SqlDataSource>
    <asp:TextBox ID="txtID" runat="server" ReadOnly="true"></asp:TextBox>

    <asp:TextBox ID="txtLastname" runat="server"></asp:TextBox>
    <asp:TextBox ID="txtFirstname" runat="server"></asp:TextBox>
       <asp:Button ID="Button1" runat="server" Text="insert" OnClick="Insert" />
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1" AllowSorting="True" DataKeyNames="id">
        <Columns>
            <asp:CommandField ShowEditButton="True" ShowDeleteButton="True" />
            <asp:BoundField DataField="Id" HeaderText="ID" SortExpression="Id" />
            <asp:BoundField DataField="Lastname" HeaderText="Lastname" SortExpression="Lastname" />
            <asp:BoundField DataField="Firstname" HeaderText="Firstname" SortExpression="Firstname" />
        </Columns>
    
        </asp:GridView>
 

    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:CUDirConnectionString %>" 
        SelectCommand="SELECT [id], [Lastname], [Firstname] FROM [Candidates] WHERE YEARRUNNING= @YEARRUNNING"
        InsertCommand="INSERT INTO Candidates ([YEARRUNNING],[Lastname], [Firstname]) VALUES ( @yearrunning, @LASTNAME, @FIRSTNAME)"
        UpdateCommand="UPDATE Candidates SET lastName = @lastName, Firstname= @firstname WHERE id = @Id"
        DeleteCommand="DELETE FROM Candidates WHERE Id = @Id">
     
        <SelectParameters>
            <asp:ControlParameter Name="YEARRUNNING" ControlID="DropDownList1" Type="String" />
        </SelectParameters>
           
        <InsertParameters>
            <asp:ControlParameter Name="Lastname" ControlID="txtLastname" Type="String" />
            <asp:ControlParameter Name="Firstname" ControlID="txtFirstname" Type="String" />
            <asp:ControlParameter Name="YEARRUNNING" ControlID="DropDownList1" Type="String" />

        </InsertParameters>

        <UpdateParameters>
            <asp:Parameter Name="Id" Type="Int32" />
            <asp:Parameter Name="LastName" Type="String" />
            <asp:Parameter Name="Firstname" Type="String" />
        </UpdateParameters>
        
        <DeleteParameters>
            <asp:Parameter Name="Id" Type="Int32" />
        </DeleteParameters>
</asp:SqlDataSource>
</asp:Content>
