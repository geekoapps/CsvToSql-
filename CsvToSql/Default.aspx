<%@ Page Title="Uploader" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="CsvToSql._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <p>
            <asp:FileUpload id="FileUploadControl" runat="server" />
            <asp:Button runat="server" id="UploadButton" text="Upload" onclick="UploadButton_Click" />
            <br />

        </p>
        <p>
            &nbsp;</p>
        <p>
            <br />
            <asp:Label runat="server" id="StatusLabel" text="Upload status: " />

        </p>
        <p>
            &nbsp;</p>
        <p>
            Result:</p>
        <p>
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="GUID" DataSourceID="SqlDataSource1">
                <Columns>
                    <asp:BoundField DataField="GUID" HeaderText="GUID" ReadOnly="True" SortExpression="GUID" />
                    <asp:BoundField DataField="Date" HeaderText="Date" SortExpression="Date" />
                    <asp:BoundField DataField="Double" HeaderText="Double" SortExpression="Double" />
                    <asp:BoundField DataField="Int" HeaderText="Int" SortExpression="Int" />
                    <asp:BoundField DataField="String" HeaderText="String" SortExpression="String" />
                </Columns>
            </asp:GridView>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:DBConnectionString %>" SelectCommand="SELECT * FROM [ExampleTable] ORDER BY [Date]"></asp:SqlDataSource>

        </p>
    </div>

</asp:Content>
