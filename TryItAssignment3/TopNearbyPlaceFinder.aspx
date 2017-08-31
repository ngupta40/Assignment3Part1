<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TopNearbyPlaceFinder.aspx.cs" Inherits="TopNearbyPlaceFinder" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div style="height: 525px">
    
        <asp:Label ID="Label1" runat="server" Text="Enter Zip Code:"></asp:Label>
        <asp:TextBox ID="TextBox1" runat="server" style="margin-left: 20px"></asp:TextBox>
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" style="margin-left: 42px" Text="Click here to find top near by places" Width="236px" />
        <br />
        <br />
        <br />
        <asp:ListBox ID="ListBox1" runat="server" Height="142px" Width="254px"></asp:ListBox>
    
    </div>
    </form>
</body>
</html>
