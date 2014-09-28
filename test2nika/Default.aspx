<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="test2nika._Default" %>

<%--http://www.asp.net/web-api/overview/creating-web-apis/using-web-api-with-aspnet-web-forms--%>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    <script src="Scripts/jquery-1.9.1.min.js" type="text/javascript"></script>
    <script type="text/javascript">
        function getTestDate() {
            var id = $('#inputText').val();

            $.getJSON("language/GetLynx", { text: id })
                .done(function (data) {
                    $('#languages').empty(); // Clear the table body.

                   //  Loop through the list of products.
                    $.each(data, function (key, val) {
                        // Add a table row for the product.
                        var row = $('<tr><td>' + val.Name + '</td><td>' + val.Percentage + '</td></tr>');
                         row  // Append the name.
                            .appendTo($('#languages'));
                    });
                })
                .fail(function(jqXHR, textStatus, err) {
                    $('#inputText').val('Error: ' + err);
                });
        }
    </script>
</asp:Content>

   

<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <asp:RichText runat="server" ToolTip="sdlkflksd" ></asp:RichText>
    <p><Textarea id="inputText"  rows="15" cols="18" runat="server" ClientIDMode="Static">
       рандомный текст привет как дела что нового
    </Textarea></p>
     <p><asp:Button id="Button1" Text="button" runat="server"   Height="35px" Width="165px" /></p>
    <p><asp:Literal ID="message1" runat="server" /></p>
     <h2>languges</h2>
    <table>
    <thead>
        <tr><th>Name</th><th>Percent</th></tr>
    </thead>
    <tbody id="languages">
    </tbody>
    </table>
   <a onclick="getTestDate()">GetApiDate</a>
    <p id="TestDate">This will the date</p>
    
  </asp:Content> 


