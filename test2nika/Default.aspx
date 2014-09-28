<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="test2nika._Default" %>

<%--http://www.asp.net/web-api/overview/creating-web-apis/using-web-api-with-aspnet-web-forms--%>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">

    <script src="Scripts/jquery-1.9.1.min.js" type="text/javascript"></script>
    <script type="text/javascript">
        var toolTipHtml = 'Хз';
        function getTestDate(selectedText) {
            $.getJSON("language/GetLanguage", { text: selectedText })
                .done(function (data) {
                    if (data == null) {
                        alert("Некорректно выбрано слово!");
                        return;
                    };
                    $('#languages').empty(); // Clear the table body.
                    $('.tooltip').remove();
                    toolTipHtml = '<table><thead><tr><th>Name</th><th>Percent</th></tr></thead><tbody id="languages"></tbody>';
                    $.each(data, function(key, val) {
                        var row = $('<tr><td>' + val.Name + '</td><td>' + val.Percentage + '</td></tr>');
                        row.appendTo($('#languages'));
                        toolTipHtml = toolTipHtml + '<tr><td>' + val.Name + '</td><td>' + val.Percentage + '</td></tr>';
                    });
                    simple_tooltip("#inputText", "tooltip");
                })
                .fail(function(jqXHR, textStatus, err) {
                    $('#inputText').val('Error: ' + err);
                });
        }

        function ShowSelection() {
            var textComponent = document.getElementById('inputText');
            var selectedText;
            // IE version
            if (document.selection != undefined) {
                textComponent.focus();
                var sel = document.selection.createRange();
                selectedText = sel.text;
            }
            // Mozilla version
            else if (textComponent.selectionStart != undefined) {
                var startPos = textComponent.selectionStart;
                var endPos = textComponent.selectionEnd;
                selectedText = textComponent.value.substring(startPos, endPos);
            }
            return selectedText;
        }

        function GetTooltip() {
            var selectedText = ShowSelection();
            getTestDate(selectedText);
        }

        function simple_tooltip(target_items, name){
            $(target_items).each(function(i){
                $("body").append("<div class='"+name+"' id='"+name+i+"'>"+toolTipHtml+"</div>");
                var my_tooltip = $("#"+name+i);

                $(this).removeAttr("title").mouseover(function(){
                    my_tooltip.css({opacity:0.8, display:"none"}).fadeIn(400);
                }).mousemove(function(kmouse){
                    my_tooltip.css({left:kmouse.pageX+15, top:kmouse.pageY+15});
                }).mouseout(function(){
                    my_tooltip.fadeOut(400);
                });
            });
        }
    </script>
    <style>
        .tooltip {
            position: absolute;
            z-index: 999;
            left: -9999px;
            background-color: #dedede;
            padding: 5px;
            border: 1px solid #fff;
            width: 250px;
        }

            .tooltip p {
                margin: 0;
                padding: 0;
                color: #fff;
                background-color: #222;
                padding: 2px 7px;
            }

    </style>
</asp:Content>
   

<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <p><Textarea id="inputText"  rows="15" cols="30" onselect="GetTooltip()" title="area tool">
       рандомный текст привет как дела что нового
    </Textarea></p>
  </asp:Content> 


