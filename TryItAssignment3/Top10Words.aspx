<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Top10Words.aspx.cs" Inherits="Top10Words" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div style="height: 503px">
    
        Input URL<asp:TextBox ID="urlInput" runat="server" style="margin-left: 0px; margin-top: 0px" Width="353px"></asp:TextBox>
        <asp:Button ID="btnTopTen" runat="server" OnClick="btnTopTen_Click" style="margin-left: 19px" Text="Get most used words" Width="151px" />
        <asp:ListBox ID="Top10WordList" runat="server" Height="200px" style="margin-left: 68px" Width="200px"></asp:ListBox>
    
    </div>
    </form>
</body>
</html>
