<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="managementOfProductTypes.aspx.cs" Inherits="Pages_management_managementOfProductTypes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <p>
    Name:
</p>
<p>
    <asp:TextBox ID="txtboxName" runat="server"></asp:TextBox>
</p>
<p>
    <asp:Button ID="btnSubmit" runat="server" OnClick="btnSubmit_Click" Text="Submit" />
</p>
<p>
    <asp:Label ID="lblResults" runat="server"></asp:Label>
</p>
</asp:Content>

