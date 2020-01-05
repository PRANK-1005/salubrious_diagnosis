<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Salubrious_System.Salubrious_Web.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
     <%--Latest compiled and minified CSS--%>
<link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css"/>

   <%--Optional theme --%>
<link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap-theme.min.css"/>

   <%--Latest compiled and minified JavaScript --%>
<script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>
        
   <%--Style SHeet link--%>
    <link href="../Style_Sheet/style.css" rel="stylesheet" />
</head>
<body>
    <div class="container-fluid">
    <div class="row">
    <div class="col-md-12">
    <form id="LoginForm" runat="server" class="login-form" style="background: rgba(0, 0, 0, 0.5)">
        <h1>Login</h1>
    <div class="form-field">
        <i class="fas fa-email"></i>
        <%--<input type="email" name="email" id="email" class="form-field" placeholder="EMAIL" required>--%>
        <asp:TextBox style="" type="email" name="email" id="txtemail" class="form-field" placeholder="EMAIL"  runat="server" ></asp:TextBox>

    </div>
    <div class="form-field">
        <i class="fas fa-lock"></i>
        <%--<input type="password" name="password" id="password" class="form-field" placeholder="PASSWORD" required>--%>
        <asp:TextBox type="password" name="password" id="txtpassword" class="form-field" placeholder="PASSWORD" runat="server" required></asp:TextBox>        
    </div>
  <br />
  <asp:Button  value="Login" Text="Login" class="btn" runat="server" OnClick="Login_Click" ></asp:Button>
    </form>
        </div>
 </div>
 </div>
</body>
</html>
