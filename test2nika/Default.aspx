<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="test2nika._Default" %>



<asp:content runat="server" ContentPlaceHolderID="MainContent">     
   <p><Textarea id="inputText" rows="15" cols="18" runat="server">
       рандомный текст
    </Textarea></p>
     <p><asp:Button id="Button1" Text="button" runat="server"  onclick="ButtonClk" Height="35px" Width="165px" /></p>
    <p><asp:Literal ID="message1" runat="server" /></p>

   
</asp:content>
