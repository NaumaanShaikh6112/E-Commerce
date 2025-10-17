<%@ Page Title="" Language="C#" MasterPageFile="~/User.Master" AutoEventWireup="true" CodeBehind="DeleteAccount.aspx.cs" Inherits="E_Commerce.DeleteAccount" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="d-flex justify-content-center flex-wrap gap-4">
        <asp:DataList ID="DataList1" runat="server" RepeatColumns="1" RepeatDirection="Horizontal" OnItemCommand="DataList1_ItemCommand">
            <ItemTemplate>
                <div class="card shadow-sm border-danger" style="width: 18rem;">
                    <img src='<%# Eval("acc_photo") %>' class="card-img-top rounded-circle mx-auto mt-3" style="height: 100px; width: 100px;" />
                    <div class="card-body text-center">
                        <h5 class="card-title"><%# Eval("acc_user") %></h5>
                        <ul class="list-group list-group-flush mb-3">
                            <li class="list-group-item"><b>Email ID:</b> <%# Eval("acc_email") %></li>
                            <li class="list-group-item"><b>Role:</b> <%# Eval("acc_role") %></li>
                        </ul>
                        <asp:Button ID="btnDelete" runat="server" Text="Delete Account"
                            CommandName="Delete"
                            CommandArgument='<%# Eval("id") %>'
                            CssClass="btn btn-danger w-100" />
                    </div>
                </div>
            </ItemTemplate>
        </asp:DataList>
    </div>
</asp:Content>


