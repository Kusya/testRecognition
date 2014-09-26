<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="test2nika._Default" %>

<%--http://www.asp.net/web-api/overview/creating-web-apis/using-web-api-with-aspnet-web-forms--%>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    <script src="Scripts/jquery-1.9.1.min.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(document).ready(function getTestDate()
        {
            var id = $('#inputText').val();
            $.getJSON("api/language")
                        .done(function (data) {
                            $('#TestDate').text(data);
                        })
                        .fail(function (jqXHR, textStatus, err) {
                            $('#inputText').val('Error: ' + err);
                        });
        });
</script>
</asp:Content>

   

<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    
    <p><Textarea id="inputText" rows="15" cols="18" runat="server">
       рандомный текст привет как дела что нового
    </Textarea></p>
     <p><asp:Button id="Button1" Text="button" runat="server"  onclick="ButtonClk" Height="35px" Width="165px" /></p>
    <p><asp:Literal ID="message1" runat="server" /></p>
    
   <a onclick="getTestDate()">GetApiDate</a>
    <p id="TestDate">This will the date</p>
    
  </asp:Content> 


