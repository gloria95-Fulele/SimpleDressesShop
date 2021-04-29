<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Register.aspx.cs" Inherits="Pages_Account_Register" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <p>
    <asp:Literal ID="litStatus" runat="server"></asp:Literal>
</p>
<p>
    Email Address:</p>
<p>
    <asp:TextBox ID="txtUserName" runat="server" CssClass="inputs"></asp:TextBox>
</p>
<p>
    Password:</p>
<p>
    <asp:TextBox ID="txtPassword" runat="server" CssClass="inputs" TextMode="Password"></asp:TextBox>
</p>
<p>
    Confrim Password:</p>
<p>
    <asp:TextBox ID="txtConfirmPass" runat="server" CssClass="inputs" TextMode="Password"></asp:TextBox>
</p>
<p>
    <asp:Button ID="btnRegister" runat="server" CssClass="button" OnClick="Button1_Click" Text="Register" />
</p>
<p>
    &nbsp;</p>
</asp:Content>

