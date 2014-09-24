<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="test2nika._Default" %>

<%--http://www.asp.net/web-api/overview/creating-web-apis/using-web-api-with-aspnet-web-forms--%>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    <script src="Scripts/jquery-1.9.1.min.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(document).ready(
        function getTestDate() {
            $.getJSON("api/test",
                function (data) {
                    $('#forTestDate').empty(); // Clear the table body.

                    // Loop through the list of products.
                    $.each(data, function (key, val) {
                        // Add a table row for the product.
                        var row = $("<tr><td>" + val.Name + "</td><td>" + val.Price + "</td></tr>");

                         row  // Append the name.
                            .appendTo($('#forTestDate'));
                    });
                });
        });
</script>
</asp:Content>

   

<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h2>Products</h2>
    <table>
    <thead>
        <tr><th>Name</th><th>Price</th></tr>
    </thead>
    <tbody id="forTestDate" >
    </tbody>
    </table>
    <p><Textarea id="inputText" rows="15" cols="18" runat="server">
       рандомный текст
    </Textarea></p>
     <p><asp:Button id="Button1" Text="button" runat="server"  onclick="ButtonClk" Height="35px" Width="165px" /></p>
    <p><asp:Literal ID="message1" runat="server" /></p>
    
   <a onclick="getTestDate()">GetApiDate</a>
    <p id="forTestDate">This will the date</p>
    
  </asp:Content> 


