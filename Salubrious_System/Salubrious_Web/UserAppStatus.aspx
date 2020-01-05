<%@ Page Title="" Language="C#" MasterPageFile="~/Salubrious_Web/SalubriousMasterPage.Master" AutoEventWireup="true" CodeBehind="UserAppStatus.aspx.cs" Inherits="Salubrious_System.Salubrious_Web.UserAppStatus" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css" integrity="sha384-BVYiiSIFeK1dGmJRAkycuHAHRg32OmUcww7on3RYdg4Va+PmSTsz/K68vbdEjh4u" crossorigin="anonymous"/>
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/font-awesome/4.7.0/css/font-awesome.min.css"/>
    <link href="https://fonts.googleapis.com/css?family=Droid+Sans" rel="stylesheet"/>

      <script src='http://code.jquery.com/jquery-latest.js'></script>
      <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js" integrity="sha384-Tc5IQib027qvyjSMfHjOMaLkfuWVxZxUPnCJA7l2mCWNIpG9mGCD8wGNIcPD7Txa" crossorigin="anonymous"></script>
      <script src="https://cdnjs.cloudflare.com/ajax/libs/Chart.js/2.6.0/Chart.bundle.js"></script>
    <link href="../Style_Sheet/Home.css" rel="stylesheet" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <div class="welcome">
        <div class="container-fluid" style="margin-top:5%">
       
          <div class="row">
              
              <div class="col-md-3">
                  <asp:Label runat="server" ID="lblFrmDate">From Date</asp:Label>
                  <asp:TextBox runat="server" ID="txtFrmDate" class="form-control" TextMode="Date" style="background-color:transparent;color:white"></asp:TextBox>
              </div>
              
            <div class="col-md-3">
                 <asp:Label runat="server" ID="lblToDate">To Date</asp:Label>
                  <asp:TextBox runat="server" ID="txtToDate" class="form-control" TextMode="Date" style="background-color:transparent;color:white"></asp:TextBox>
            </div>
            <div class="col-md-3">
            <asp:Label runat="server" ID="lblAppStatus">Status</asp:Label>
            <asp:DropDownList ID="ddlappstatus" runat="server" class="form-control" style="background-color:transparent">  
            <asp:ListItem Value="">Please Select Status</asp:ListItem>  
            <asp:ListItem>Pending </asp:ListItem>  
            <asp:ListItem>In-Progess</asp:ListItem> 
            <asp:ListItem>Closed</asp:ListItem>      
            </asp:DropDownList>  
            </div>
            <div class="col-md-3">
                <asp:Button runat="server" ID="btnSearch" Text="Search" class="btn btn-warning" style="margin-top:7%" OnClick="btnSearch_Click"></asp:Button>
            </div>
           
        </div>

            <br />
            <b>------------ OR ----------------</b>
            <br /><br />

       <div class="row">
           <div class="col-md-3">
                <asp:Label runat="server" ID="lblAppID">Appointment ID</asp:Label>s
                  <asp:TextBox runat="server" ID="txtAppID" class="form-control" style="background-color:transparent;color:white" placeholder="Please enter Appointment ID"></asp:TextBox>
           </div>
           <div class="col-md-3">
                <asp:Button runat="server" ID="btnAppIDSearch" Text="Search" class="btn btn-warning" style="margin-top:7%" OnClick="btnAppIDSearch_Click"></asp:Button>
            </div>
       </div>

       <asp:GridView ID="gvUserDashboard" runat="server"></asp:GridView>

        </div>
        </div>
</asp:Content>
