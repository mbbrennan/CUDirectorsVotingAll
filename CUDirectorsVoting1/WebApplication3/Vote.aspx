<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Vote.aspx.cs" Inherits="WebApplication3.Vote" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" >
        <Columns>
              <asp:TemplateField>
            <ItemTemplate>
                <asp:CheckBox ID="chkRow" runat="server" Checked='<%#(String.IsNullOrEmpty(Eval("candidateid").ToString()) ? false : true)%>'/>
                 
            </ItemTemplate>
        </asp:TemplateField>

            <asp:BoundField DataField="Id" HeaderText="Id" InsertVisible="False" ReadOnly="True" SortExpression="Id" />
            <asp:BoundField DataField="YearRunning" HeaderText="YearRunning" SortExpression="YearRunning" />
            <asp:BoundField DataField="Lastname" HeaderText="Lastname" SortExpression="Lastname" />
            <asp:BoundField DataField="Firstname" HeaderText="Firstname" SortExpression="Firstname" />
            <asp:BoundField DataField="Bio" HeaderText="Bio" SortExpression="Bio" />

           


           

        </Columns>
    </asp:GridView>
    <br />
    <asp:Button ID="cmdVote1" runat="server" Text="Vote" OnClick="cmdVote1_Click" />
    <asp:Button ID="cmdCancel" runat="server" Text="Cancel" />
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:CUDirConnectionString %>" SelectCommand="SELECT [Id], [YearRunning], [Lastname], [Firstname], [Bio] FROM [Candidates]"></asp:SqlDataSource>

</asp:Content>
