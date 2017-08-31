<%@ Page Language="C#" AutoEventWireup="true" CodeFile="WordFilter.aspx.cs" Inherits="WordFilter" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div style="height: 461px">
        Enter string to be filtered :
        <asp:TextBox ID="inputTxt" runat="server" Height="16px"></asp:TextBox>
    
        <asp:Button ID="btnFilter" runat="server" OnClick="btnFilter_Click" style="margin-left: 38px" Text="Get Filtered String" Width="153px" />
        <br />
        <br />
        <br />
        <asp:Label ID="lblOutput" runat="server" Text="OutputString"></asp:Label>
    
    </div>
    </form>
</body>
</html>
