<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="Salubrious_System.Salubrious_Web.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css" integrity="sha384-BVYiiSIFeK1dGmJRAkycuHAHRg32OmUcww7on3RYdg4Va+PmSTsz/K68vbdEjh4u" crossorigin="anonymous"/>
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/font-awesome/4.7.0/css/font-awesome.min.css"/>
    <link href="https://fonts.googleapis.com/css?family=Droid+Sans" rel="stylesheet"/>

      <script src='http://code.jquery.com/jquery-latest.js'></script>
      <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js" integrity="sha384-Tc5IQib027qvyjSMfHjOMaLkfuWVxZxUPnCJA7l2mCWNIpG9mGCD8wGNIcPD7Txa" crossorigin="anonymous"></script>
      <script src="https://cdnjs.cloudflare.com/ajax/libs/Chart.js/2.6.0/Chart.bundle.js"></script>
    
    <script src="../Scripts/jquery-ui.min.js"></script>
    <link href="../Content/jquery-ui.min.css" rel="stylesheet" />
    <link href="../Style_Sheet/DoctorRecommendation.css" rel="stylesheet" />
    


    <script type="text/javascript">
        $(document).ready(function () {
            $('#txtDiseaseName').autocomplete({
                source: '../Salubrious_CommonLayer/FetchDiseasesHandler.ashx'
               
            })
        })
            
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <aside class="side-nav" id="show-side-navigation1">
      <i class="fa fa-bars close-aside hidden-sm hidden-md hidden-lg" data-close="show-side-navigation1"></i>
      <div class="heading">
        <div class="info">
          <h3><a href="#">Diagnosis Intelligent System</a></h3>
          <!--<p>Lorem ipsum dolor sit amet consectetur.</p>-->
        </div>
      </div>
      <div class="search">
        <input type="text" placeholder="Type here"><i class="fa fa-search"></i>
      </div>
      <ul class="categories">
        <li><i class="fa fa-home fa-fw" aria-hidden="true"></i><a href="#"> Book an appointment</a>
        </li>
        <li><i class="fa fa-support fa-fw"></i><a href="#">Question & Answer</a>
        </li>
        <li><i class="fa fa-envelope fa-fw"></i><a href="#"> View the app status</a>
        </li>
        <li><i class="fa fa-users fa-fw"></i><a href="#"> Doctor's recommendation</a>
        </li>
        <li><i class="fa fa-bolt fa-fw"></i><a href="#">Diet Plan</a>
        </li>
        <li><i class="fa fa-bolt fa-fw"></i><a href="#">BMI Calculator</a>
        </li>
        </ul>
    </aside>


    <section id="contents">
      <nav class="navbar navbar-default">
        <div class="container-fluid">
          <div class="navbar-header">
            <button type="button" class="navbar-toggle collapsed" data-toggle="collapse" data-target="#bs-example-navbar-collapse-1" aria-expanded="false">
              <i class="fa fa-align-right"></i>
            </button>
            <a class="navbar-brand" href="#">my<span class="main-color">Dashboard</span></a>
          </div>
          <div class="collapse navbar-collapse navbar-right" id="bs-example-navbar-collapse-1">
            <ul class="nav navbar-nav">
              <li class="dropdown">
                <a href="#" class="dropdown-toggle" data-toggle="dropdown" role="button" aria-haspopup="true" aria-expanded="false">My profile <span class="caret"></span></a>
                <ul class="dropdown-menu">
                  <li><a href="#"><i class="fa fa-user-o fw"></i> My account</a></li>
                  <li><a href="#"><i class="fa fa-envelope-o fw"></i> My inbox</a></li>
                  <li><a href="#"><i class="fa fa-question-circle-o fw"></i> Help</a></li>
                  <li role="separator" class="divider"></li>
                  <li><a href="#"><i class="fa fa-sign-out"></i> Log out</a></li>
                </ul>
              </li>
              <li><a href="#"><i class="fa fa-comments"></i><span>23</span></a></li>
              <li><a href="#"><i class="fa fa-bell-o"></i><span>98</span></a></li>
              <li><a href="#"><i data-show="show-side-navigation1" class="fa fa-bars show-side-btn"></i></a></li>
            </ul>
          </div>
        </div>
      </nav>


      <div class="welcome">
        <div class="container-fluid" style="margin-top:5%">
          <div class="row">
            <div class="col-md-2">
                </div>
              <div class="col-md-8">              
                  <div class="input-group mb-3">
                   <div>
                     <asp:Label ID="lblDiseaseName" runat="server" Text="Please enter the Disease name:"></asp:Label>
                     <asp:TextBox ID="txtDiseaseName" runat="server" Class="form-control" style="border-radius:5px;background-color:transparent;color:white"></asp:TextBox>
                       <br /><br />
                     <asp:Button ID="btnDoctDetails" runat="server" Text="Search" OnClick="DoctDetails_Click" class="btn btn-warning col-md-4" style="margin-top:5%;"/>
                  </div>
                    
                    <div class="col-md-12" style="margin-top:15%">
                    
                    <asp:GridView ID ="gvDoctDetails" runat="server" width="100%" CssClass="table-condensed" AutoGenerateColumns="False" BackColor="LightGoldenrodYellow" BorderColor="Tan" BorderWidth="1px" CellPadding="2" ForeColor="Black" GridLines="None" OnRowCommand="gvDoctDetails_RowCommand">
                        <AlternatingRowStyle BackColor="PaleGoldenrod" />
                        <Columns>
                            <asp:TemplateField HeaderText="Doctor Name">
                                <ItemTemplate>
                                    <asp:Label runat="server" ID="gvlblDoctorName" Text='<%#Eval("doctor_name")%>'></asp:Label>
                                </ItemTemplate>

                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Doctor Specialisation">
                                <ItemTemplate>
                                    <asp:Label runat="server" ID="gvlblDoctorSpec" Text='<%#Eval("doctor_specialisation")%>'></asp:Label>
                                </ItemTemplate>

                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Hospital Name">
                                <ItemTemplate>
                                    <asp:Label runat="server" ID="gvlblDoctorHospital" Text='<%#Eval("doctor_working_hospital")%>'></asp:Label>
                                </ItemTemplate>

                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Doctor Contact No.">
                                <ItemTemplate>
                                    <asp:Label runat="server" ID="gvlblDoctorContact" Text='<%#Eval("doctor_contact")%>'></asp:Label>
                                </ItemTemplate>

                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="City">
                                <ItemTemplate>
                                    <asp:Label runat="server" ID="gvlblDoctorCity" Text='<%#Eval("doctor_city")%>'></asp:Label>
                                </ItemTemplate>

                            </asp:TemplateField>
                            

                           <asp:TemplateField HeaderText="City">
                                <ItemTemplate>
                                    <%--<asp:LinkButton ID="Link" runat="server" PostBackUrl="generatePDF.aspx">View</asp:LinkButton>--%>
                                    <asp:Button ID="btnDownload" Text="View" runat="server" CommandName="Select" CommandArgument="<%#Container.DataItemIndex%>" />
                                </ItemTemplate>

                            </asp:TemplateField>
                        </Columns>
                        <FooterStyle BackColor="Tan" />
                        <HeaderStyle BackColor="Tan" Font-Bold="True" />
                        <PagerStyle BackColor="PaleGoldenrod" ForeColor="DarkSlateBlue" HorizontalAlign="Center" />
                        <SelectedRowStyle BackColor="DarkSlateBlue" ForeColor="GhostWhite" />
                        <SortedAscendingCellStyle BackColor="#FAFAE7" />
                        <SortedAscendingHeaderStyle BackColor="#DAC09E" />
                        <SortedDescendingCellStyle BackColor="#E1DB9C" />
                        <SortedDescendingHeaderStyle BackColor="#C2A47B" />
                    </asp:GridView>
                    </div>
                    </div>
         
            </div>
          </div>
        </div>
      </div>
      
</section>
        <asp:HiddenField ID="deseaseID" runat="server"/>
    </form>
</body>
</html>
