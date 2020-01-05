<%@ Page Title="" Language="C#" MasterPageFile="~/Salubrious_Web/SalubriousMasterPage.Master" AutoEventWireup="true" CodeBehind="TestsAddition.aspx.cs" Inherits="Salubrious_System.Salubrious_Web.TestsAddition" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

     <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css" integrity="sha384-BVYiiSIFeK1dGmJRAkycuHAHRg32OmUcww7on3RYdg4Va+PmSTsz/K68vbdEjh4u" crossorigin="anonymous"/>
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/font-awesome/4.7.0/css/font-awesome.min.css"/>
    <link href="https://fonts.googleapis.com/css?family=Droid+Sans" rel="stylesheet"/>

      <script src='http://code.jquery.com/jquery-latest.js'></script>
      <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js" integrity="sha384-Tc5IQib027qvyjSMfHjOMaLkfuWVxZxUPnCJA7l2mCWNIpG9mGCD8wGNIcPD7Txa" crossorigin="anonymous"></script>
      <script src="https://cdnjs.cloudflare.com/ajax/libs/Chart.js/2.6.0/Chart.bundle.js"></script>
    <link href="../Style_Sheet/DoctorRecommendation.css" rel="stylesheet" />

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="welcome">
        <div class="container-fluid" style="margin-top:5%">
          <div class="row">
            <div class="col-md-2">
                </div>
              <div class="col-md-8">              
                  <div class="input-group mb-3">
                   <div>
                       <asp:Label ID="lblTestName" runat="server" Text="Test name:"></asp:Label>
                     <asp:TextBox ID="txtTestName" runat="server" Class="form-control" style="border-radius:5px;background-color:transparent;color:white"></asp:TextBox>
                       <br /><br /><br />
                       <asp:Label ID="lblTestCost" runat="server" Text="Test Cost name:"></asp:Label>
                       <asp:TextBox ID="txtTestCost" runat="server" Class="form-control" style="border-radius:5px;background-color:transparent;color:white"></asp:TextBox>
                       <br /><br />
                     <asp:Button ID="btnTestAdd" runat="server" Text="Add Test" OnClick="btnTestAdd_Click" class="btn btn-warning col-md-4"  style="margin-top:5%;"/>
                  </div>
                      </div>
                  </div>
              </div>
            </div>  
</div>
</asp:Content>
