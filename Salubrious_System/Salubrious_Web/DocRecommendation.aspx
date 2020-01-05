<%@ Page Title="" Language="C#" MasterPageFile="~/Salubrious_Web/SalubriousMasterPage.Master" AutoEventWireup="true" CodeBehind="DocRecommendation.aspx.cs" Inherits="Salubrious_System.Salubrious_Web.DocRecommendation" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
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

                //source: 'FetchDiseasesHandlers.ashx'
                source : '../Salubrious_CommonLayer/FetchDiseasesHandler.ashx'
               
            })
        })
            
    </script>

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
                     <asp:Label ID="lblDiseaseName" runat="server" Text="Please enter the Disease name:"></asp:Label>
                     <asp:TextBox ID="txtDiseaseName" ClientIDMode="Static" runat="server" Class="form-control" style="border-radius:5px;background-color:transparent;color:white"></asp:TextBox>
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
      
        <asp:HiddenField ID="deseaseID" runat="server"/>
</asp:Content>
