<%@ Page Title="Sql View" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="CsvToSql.About" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %></h2>
    <h3>.<asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="GUID" DataSourceID="SqlDataSource3" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
        <Columns>
            <asp:BoundField DataField="GUID" HeaderText="GUID" ReadOnly="True" SortExpression="GUID" />
            <asp:BoundField DataField="Date" HeaderText="Date" SortExpression="Date" />
            <asp:BoundField DataField="Double" HeaderText="Double" SortExpression="Double" />
            <asp:BoundField DataField="Int" HeaderText="Int" SortExpression="Int" />
            <asp:BoundField DataField="String" HeaderText="String" SortExpression="String" />
        </Columns>
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:DBConnectionString %>" SelectCommand="SELECT * FROM [ExampleTable] ORDER BY [Date]"></asp:SqlDataSource>
    </h3>
    <p>&nbsp;</p>
</asp:Content>
