<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ImageVerifier.aspx.cs" Inherits="ImageVerifier" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div style="height: 364px">
    
        <asp:Image ID="Image1" runat="server" Height="147px" Width="346px" />
        <asp:Button ID="refreshImage" runat="server" OnClick="refreshImage_Click" style="height: 26px; margin-left: 33px" Text="Re Generate" Width="103px" />
        <br />
        <br />
        <asp:TextBox ID="TextBox1" runat="server" style="margin-left: 42px" Width="137px"></asp:TextBox>
        <asp:Button ID="Submit" runat="server" OnClick="Submit_Click" style="margin-left: 197px" Text="Submit" Width="90px" />
        <br />
        <br />
        <br />
        <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
    
    </div>
    </form>
</body>
</html>
