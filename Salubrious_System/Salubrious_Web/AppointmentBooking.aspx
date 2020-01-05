<%@ Page Title="" Language="C#" MasterPageFile="~/Salubrious_Web/SalubriousMasterPage.Master" AutoEventWireup="true" CodeBehind="AppointmentBooking.aspx.cs" Inherits="Salubrious_System.Salubrious_Web.AppointmentBooking" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <meta charset="utf-8" />
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css" integrity="sha384-BVYiiSIFeK1dGmJRAkycuHAHRg32OmUcww7on3RYdg4Va+PmSTsz/K68vbdEjh4u" crossorigin="anonymous"/>
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/font-awesome/4.7.0/css/font-awesome.min.css"/>
    <link href="https://fonts.googleapis.com/css?family=Droid+Sans" rel="stylesheet"/>

      <script src='http://code.jquery.com/jquery-latest.js'></script>
      <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js" integrity="sha384-Tc5IQib027qvyjSMfHjOMaLkfuWVxZxUPnCJA7l2mCWNIpG9mGCD8wGNIcPD7Txa" crossorigin="anonymous"></script>
      <script src="https://cdnjs.cloudflare.com/ajax/libs/Chart.js/2.6.0/Chart.bundle.js"></script>
      
    <script src="../Scripts/jquery-ui.min.js"></script>
    <link href="../Content/jquery-ui.min.css" rel="stylesheet" />
    <link href="../Style_Sheet/Home.css" rel="stylesheet" />

   <script type="text/javascript">
        $(document).ready(function () {
            $('#gvtestName').autocomplete({
                source: function (request, response) {
                    $.ajax({
                        url: '../GetTestDetails.asmx/testDetails',
                        method: 'post',
                        contentType: 'application/json;charset=utf-8',
                        data: JSON.stringify({ term: request.term }),
                        dataType: 'json',
                        success: function (data) {
                            response($.map(data.d, function (item) {
                                $('#hdnTestId').val(item.value);
                                return {
                                    label: item.label
                                    }
                            }))
                        }
                        ,
                        error: function (err) {
                            alert(err)
                        }
                    })
                },
                select: function (event, ui) {

                    $('#gvtestName').val(ui.item.label)
                    $('#btnTestName').click();
                   
                    
                }
            })
        })

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager runat="server" ClientIDMode="Static" ID="scriptmanager" EnablePageMethods="true">

    </asp:ScriptManager>
     <div class="welcome">
        <div class="container-fluid" style="margin-top:5%">
          <div class="row" style="padding:2%">
           <div class="col-md-6">
               <asp:TextBox class="form-control"  runat="server" placeholder="Patient Name" ID="Textbox1" style="background-color:transparent"></asp:TextBox>
           </div> 
          
          <div class="col-md-6">
               <asp:TextBox class="form-control" runat="server" placeholder="Patient Contact Number" ID="Textbox2" style="background-color:transparent"></asp:TextBox>
           </div> 


          </div>

          
          <div class="row" style="padding:2%">
           <div class="col-md-6">
               <asp:TextBox class="form-control" runat="server" placeholder="Patient Address" ID="Textbox3" style="background-color:transparent"></asp:TextBox>
           </div>
           <div class="col-md-6">
             
            <asp:DropDownList ID="DropDownList1" runat="server" class="form-control" style="background-color:transparent">  
            <asp:ListItem Value="">Please Select Gender</asp:ListItem>  
            <asp:ListItem>Male</asp:ListItem>  
            <asp:ListItem>Female</asp:ListItem>  
            </asp:DropDownList>  
        
           
           </div>
          </div>

          <div class="row">
           <div class="col-md-12">
               <table class="table table-bordered">
          <thead>
    <tr class="table-primary">
      
      <th scope="col">
          <div class="row">
          <div class="col-md-4">
          <asp:Label runat="server" ID="lblTestName">Select the Tests</asp:Label>
          </div>
          <div class="col-md-4">
          <asp:TextBox runat="server" ID="txtTestName" ClientIDMode="Static" style="color:black" CssClass="form-control"></asp:TextBox>
          </div>
          <div class="col-md-4">
          <asp:Button runat="server" ClientIDMode="Static" ID="btnTestName" Text="+" style="color:black; height: 36px;" CssClass="btn btn-warning" OnClick ="btnAddTestName_Click" ></asp:Button>
          </div>
          </div>
          </th>
     
    
    </tr>
  </thead>
  <tbody>

                          <asp:GridView ID ="gvappointmentTests" runat="server" width="100%" CssClass="table-condensed" AutoGenerateColumns="False" BackColor="LightGoldenrodYellow" BorderColor="Tan" BorderWidth="1px" CellPadding="2" ForeColor="Black" GridLines="None">
                        <AlternatingRowStyle BackColor="PaleGoldenrod" />
                        <Columns>
                            <asp:TemplateField HeaderText="SN">
                                <ItemTemplate>
                                    <asp:TextBox runat="server" ID="sn"></asp:TextBox>
                                </ItemTemplate>

                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Test Name">
                                <ItemTemplate>
                                    <asp:TextBox runat="server" ClientIDMode="Static" ID="gvtestName"></asp:TextBox>
                                </ItemTemplate>

                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Test Cost">
                                <ItemTemplate>
                                    <asp:Label runat="server" ClientIDMode="Static" ID="gvlblTestCost" Text='<%#Eval("test_cost")%>'></asp:Label>
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
  </tbody>
</table>
           </div>
          </div>
          

        </div>
      </div>
    <asp:HiddenField  ID ="hdnTestId" ClientIDMode="Static" runat="server" />
</asp:Content>
