<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Product.aspx.cs" Inherits="Pages_Product" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table>
        <tr>
            <td rowspan="4">
                <asp:Image ID="imgProduct" runat="server" CssClass="detailsImage"></asp:Image>
            </td>
           <td><h2>
               <asp:Label ID="lblTitle" runat="server" Text="Label"></asp:Label>
               <hr style="height: -12px"/>
               &nbsp;</h2></td>            
        </tr>
         <tr>
            <td>
                <asp:Label ID="lblDescription" runat="server" CssClass="detailsDescription" Text="Label"></asp:Label>
            </td>
           <td>
               <asp:Label ID="lblPrice" runat="server" CssClass="detailsPrice" Text="Label"></asp:Label> </td><br />
             Quantity:
             <asp:DropDownList ID="ddlAmount" runat="server"></asp:DropDownList><br />
             <asp:Label ID="lblResult" runat="server" Text=""></asp:Label>
        </tr>
         <tr>
            <td>Product Number: 
                <asp:Label ID="lblItemNumber" runat="server" Text="Label"></asp:Label></td>
                     
        </tr>
         <tr>
            <td>
                <asp:Label ID="Label1" runat="server" Text="Available" CssClass="productPrice"></asp:Label>
                <asp:Button ID="btnAdd" runat="server" CssClass="button" OnClick="btnAdd_Click" Text="Add Product" />
            </td>
                    
        </tr>
    </table>
</asp:Content>

