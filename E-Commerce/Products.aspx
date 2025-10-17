<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMaster.Master" AutoEventWireup="true" CodeBehind="Products.aspx.cs" Inherits="E_Commerce.Products" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    ADD PRODUCT TITLE
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  <h2 class="mt-2">Add New Product</h2>
<div class="mb-3">
    <label for="txtProductName" class="form-label">Product Name</label>
    <asp:TextBox ID="txtProductName" runat="server" CssClass="form-control" />
</div>
<div class="mb-3">
    <label for="txtPrice" class="form-label">Price</label>
    <asp:TextBox ID="txtPrice" runat="server" CssClass="form-control" />
</div>
</asp:Content>
