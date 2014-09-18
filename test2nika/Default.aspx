<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="test2nika._Default" %>

<%--http://www.asp.net/web-api/overview/creating-web-apis/using-web-api-with-aspnet-web-forms--%>

<asp:content runat="server" ContentPlaceHolderID="MainContent">
    <script src="Scripts/jquery-1.9.1.min.js"></script>
   <p><Textarea id="inputText" rows="15" cols="18" runat="server">
       рандомный текст
    </Textarea></p>
     <p><asp:Button id="Button1" Text="button" runat="server"  onclick="ButtonClk" Height="35px" Width="165px" /></p>
    <p><asp:Literal ID="message1" runat="server" /></p>
    
   <a onclick="getTestDate()">GetApiDate</a>
    <p id="forTestDate">This will the date</p>
    
    
    <script type="text/javascript">

        function getTestDate() {
            $.getJSON("api/test",
                function (data) {
                    $('#forTestDate').empty(); // Clear the table body.

                    // Loop through the list of products.
                    $.each(data, function (key, val) {
                        // Add a table row for the product.
                        var row = '<td>' + val + '</td><td>' + 1 + '</td>';
                        $('<tr/>', { text: row })  // Append the name.
                            .appendTo($('#forTestDate'));
                    });
                });
        }
</script>
   
</asp:content>

