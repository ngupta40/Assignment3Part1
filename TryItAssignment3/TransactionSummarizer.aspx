<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TransactionSummarizer.aspx.cs" Inherits="TransactionSummarizer" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body style="height: 417px">
    <form id="form1" runat="server">
    <div style="height: 139px">
    
        <asp:Label ID="Label1" runat="server" Text="Enter Input File Path with name and extesion:"></asp:Label>
&nbsp;<asp:TextBox ID="TextBox1" runat="server" style="margin-left: 24px" Width="440px"></asp:TextBox>
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" style="margin-left: 31px" Text="Click here to get transaction summary" Width="285px" />
        <br />
        <br />
        <br />
        <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
    
    </div>
    </form>
</body>
</html>
