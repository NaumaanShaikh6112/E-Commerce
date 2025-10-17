<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="E_Commerce.Login" %>

<!DOCTYPE html>
<html lang="en">
<head runat="server">
    <meta charset="utf-8" />
    <title>Login - E-Commerce</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/css/bootstrap.min.css" rel="stylesheet" />
    <style>
        .login-container {
            max-width: 500px;
            margin: 80px auto;
            padding: 30px;
            background-color: #fff;
            border-radius: 10px;
            box-shadow: 0 0 10px rgba(0,0,0,0.1);
        }

        .form-switch {
            text-align: center;
            margin-top: 20px;
        }
    </style>
</head>
<body style="background-color: #f8f9fa;">
    <form id="form1" runat="server">
        <div class="login-container">
            <h3 class="text-center mb-4">Login</h3>
            <div class="mb-3">
                <label for="txtUserEmail" class="form-label">UserEmail</label>
                <asp:TextBox ID="txtUserEmail" runat="server" CssClass="form-control" PlaceHolder="Enter your Email" />
            </div>
            <div class="mb-3">
                <label for="txtPassword" class="form-label">Password</label>
                <asp:TextBox ID="txtPassword" runat="server" CssClass="form-control" TextMode="Password" PlaceHolder="Enter your password" />
            </div>
            <asp:Button ID="btnLogin" runat="server" Text="Login" CssClass="btn btn-primary w-100" OnClick="btnLogin_Click" />

            <!-- Modal Trigger -->
            <div class="form-switch text-center mt-3">
                <span>Don't have an account?</span>
                <a href="#" class="btn btn-link" data-bs-toggle="modal" data-bs-target="#exampleModal">Create New Account
                </a>
            </div>
        </div>

        <!-- Registration Modal -->
        <div class="modal fade" id="exampleModal" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
            <div class="modal-dialog">
                <div class="modal-content">
                    <div class="modal-header">
                        <h5 class="modal-title" id="exampleModalLabel">Create New Account</h5>
                        <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                    </div>
                    <div class="modal-body">
                        <div class="mb-3">
                            <label for="txtNewUsername" class="form-label">Username</label>
                            <asp:TextBox ID="txtNewUsername" runat="server" CssClass="form-control" PlaceHolder="Choose a username" />
                        </div>
                        <div class="mb-3">
                            <label for="txtEmail" class="form-label">Email ID</label>
                            <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" TextMode="Email" PlaceHolder="Enter your email address" />
                        </div>
                        <div class="mb-3">
                            <label for="txtNewPassword" class="form-label">Password</label>
                            <asp:TextBox ID="txtNewPassword" runat="server" CssClass="form-control" TextMode="Password" PlaceHolder="Create a password" />
                        </div>
                        <div class="mb-3">
                            <label for="FileUpload1" class="form-label">Profile Image</label>
                            <asp:FileUpload ID="FileUpload1" runat="server" CssClass="form-control" />
                            <small class="form-text text-muted">Upload your profile photo (JPG, PNG, or JPEG).</small>
                        </div>
                    </div>
                    <div class="modal-footer">
                        <asp:Button ID="btnSignup" runat="server" Text="Sign Up" CssClass="btn btn-success" OnClick="btnSignup_Click" />
                    </div>
                </div>
            </div>
        </div>
    </form>

    <!-- Bootstrap JS -->
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/js/bootstrap.bundle.min.js"></script>
</body>
</html>
