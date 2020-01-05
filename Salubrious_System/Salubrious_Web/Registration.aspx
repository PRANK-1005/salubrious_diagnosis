<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Registration.aspx.cs" Inherits="Salubrious_System.Salubrious_Web.Registration" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
 
<link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css"/>

<!-- Optional theme -->
<link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap-theme.min.css"/>

<!-- Latest compiled and minified JavaScript -->
<script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>

<%--<link rel="stylesheet" href="style.css" />--%>
    <link href="../Style_Sheet/style.css" rel="stylesheet" />
</head>
<body>
    <div class="container-fluid">
    <div class="row">
    <div class="col-md-12">
    <form id="RegistrationForm" class="login-form"  runat="server" data-toggle ="validator" style="background: rgba(0, 0, 0, 0.5)">
         <h1>Register</h1>

    <div class="form-row">
    <div class="form-field col-md-5">

      <asp:TextBox type="text" name="firstname" id="txtfirstname" class="form-field" placeholder="FIRST NAME" runat="server" required></asp:TextBox>
    </div>

      <div class="col-md-2"></div>

    <div class="form-field col-md-5">
      <asp:TextBox type="text" name="lastname" id="txtlastname" class="form-field" placeholder="LAST NAME" runat="server" required></asp:TextBox>
    </div>
  </div>

    <div class="form-field col-md-12">
        <i class="fas fa-email"></i>
        <asp:TextBox type="email" name="email" id="txtemail" class="form-field" placeholder="EMAIL" runat="server" required></asp:TextBox>
    </div>


  <div class="form-row">
    <div class="form-field col-md-5">
      <asp:TextBox type="date" name="date" id="date" class="form-field" required runat="server" placeholder="DOB"  onfocus="(this.type='date')" onblur="(this.type='text')"></asp:TextBox>
        <%--<input placeholder="Date" class="textbox-n" type="text" onfocus="(this.type='date')" onblur="(this.type='text')" id="date">--%>
    </div>

      <div class="col-md-2"></div>

      <div class="form-field col-md-5">
          <%--<i class="fas fa-email"></i>--%>
      <%--<asp:TextBox type="email" name="email" id="email" class="form-field" placeholder="EMAIL" required runat="server"></asp:TextBox>--%>    
   <asp:DropDownList ID="ddlgender" runat="server" class="form-field" style="background-color: transparent;border-color:transparent;color:white">
    <asp:ListItem Enabled="true" Text="Select Gender" Value="-1" style="color:black"></asp:ListItem>
    <asp:ListItem Text="Male" Value="Male" style="color:black"></asp:ListItem>
    <asp:ListItem Text="Female" Value="Female" style="color:black"></asp:ListItem>
    <asp:ListItem Text="Others" Value="Others" style="color:black"></asp:ListItem>
  </asp:DropDownList>
    </div>
        
  </div>

    
  <div class="form-row">
    <div class="form-field col-md-5">
      <asp:TextBox type="password" name="password" id="txtpassword" class="form-field" placeholder="PASSWORD" runat="server" required></asp:TextBox>
    </div>

      <div class="col-md-2"></div>

      <div class="form-field col-md-5">
      <asp:TextBox type="password" name="confirm_pwd" id="txtconfirmpwd" class="form-field" placeholder="CONFIRM PASSWORD" runat="server" data-match="#txtpassword" data-match-error="Whoops, these don't match" required></asp:TextBox>
      </div>
  </div>



    <div class="form-field col-md-12">
        <asp:TextBox type="text" name="address" id="txtaddress" class="form-field" placeholder="ADDRESS" runat="server" required></asp:TextBox>
    </div>


    <div class="form-field col-md-12">    
        <%--<label for="password">Password</label>--%>
        <asp:TextBox type="text" name="contact" id="txtcontact" class="form-field" pattern="[0-9]{3}[0-9]{3}[0-9]{4}" placeholder="CONTACT NO" runat="server" required></asp:TextBox>
    </div>
  <br />
  <asp:Button type="submit" value="Register" class="btn" runat="server" Text="Register" OnClick="btn_Register_User" ></asp:Button>
</form>   
</div>
 </div>
 </div>
</body>
</html>
