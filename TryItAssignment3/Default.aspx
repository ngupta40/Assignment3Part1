<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <asp:Table ID="SvcTable" runat="server" GridLines="Both" Height="175px" Caption="Services Table" 
            Font-Names="Arial"
            BackColor="White"
            BorderColor="Black"
            BorderWidth="2"
            ForeColor="White"
            CellPadding="5"
            CellSpacing="5">
        <asp:TableHeaderRow runat="server" Font-Bold="true" BackColor="Black">
                <asp:TableHeaderCell>Service Name</asp:TableHeaderCell>
                <asp:TableHeaderCell Width ="200" HorizontalAlign ="Center">Service Description</asp:TableHeaderCell>
                <asp:TableHeaderCell Width ="50">Operation Name</asp:TableHeaderCell>
                <asp:TableHeaderCell Width ="50">Service Link</asp:TableHeaderCell>
                <asp:TableHeaderCell Width ="50">Service Testing</asp:TableHeaderCell>
                
        </asp:TableHeaderRow>
        <asp:TableRow ID="TableRow1" runat="server" BackColor="Blue">
                <asp:TableCell>Top10Words</asp:TableCell>
                <asp:TableCell Width =" 200">This service takes an input url and returns the top ten words in the website</asp:TableCell>
                <asp:TableCell Width =" 200">Method Name : Top10Words , Argument Type: url string , Return Type : String Array</asp:TableCell>
                <asp:TableCell Width =" 200">http://webstrar29.fulton.asu.edu/Page1/Service1.svc?wsdl</asp:TableCell>
        </asp:TableRow>
        <asp:TableRow ID="TableRow3" runat="server" BackColor="Blue">
                <asp:TableCell>WordFilter</asp:TableCell>
                <asp:TableCell Width =" 200">This service takes an input string and returns filtered string by removing the stop words</asp:TableCell>       
                <asp:TableCell Width =" 200">Method Name : WordFilter , Argument Type: string , Return Type : string</asp:TableCell>
                <asp:TableCell Width =" 200">http://webstrar29.fulton.asu.edu/Page1/Service1.svc?wsdl</asp:TableCell>
        </asp:TableRow>
        <asp:TableRow ID="TableRow2" runat="server" BackColor="Blue">
                <asp:TableCell>TopUsedWords</asp:TableCell>
                <asp:TableCell Width =" 200">This service takes an input different URL strings seperated by semicolon and returns most common used words amongst them</asp:TableCell>       
                <asp:TableCell Width =" 200">Method Name : TopUsedWords , Argument Type: string , Return Type : string array</asp:TableCell>
                <asp:TableCell Width =" 200">http://localhost:59295/Service1.svc/TopUsedWords?URLs=</asp:TableCell>
        </asp:TableRow>
        <asp:TableRow ID="TableRow4" runat="server" BackColor="Blue">
                <asp:TableCell>TransactionSummary</asp:TableCell>
                <asp:TableCell Width =" 200">This service takes an input string i.e. a exact file path with name and .txt extension and returns Transaction Summary</asp:TableCell>       
                <asp:TableCell Width =" 200">Method Name : TransactionSummariser , Argument Type: string , Return Type : string</asp:TableCell>
                <asp:TableCell Width =" 200">http://webstrar29.fulton.asu.edu/Page1/Service1.svc?wsdl</asp:TableCell>
        </asp:TableRow>
        <asp:TableRow ID="TableRow5" runat="server" BackColor="Blue">
                <asp:TableCell>TopNearByPlaceFinder</asp:TableCell>
                <asp:TableCell Width =" 200">This service takes an input string i.e. a zipcode and returns top nearby places</asp:TableCell>       
                <asp:TableCell Width =" 200">Method Name : TopNearByPlaceFinder , Argument Type: string , Return Type : string array</asp:TableCell>
                <asp:TableCell Width =" 200">http://webstrar29.fulton.asu.edu/Page1/Service1.svc?wsdl</asp:TableCell>
        </asp:TableRow>
                <asp:TableRow ID="TableRow6" runat="server" BackColor="Blue">
                <asp:TableCell>ImageVerifier</asp:TableCell>
                <asp:TableCell Width =" 200">This service takes an input string i.e. a zipcode and returns top nearby places</asp:TableCell>       
                <asp:TableCell Width =" 200">Method Name : TopNearByPlaceFinder , Argument Type: string , Return Type : string array</asp:TableCell>
                <asp:TableCell Width =" 200">http://webstrar29.fulton.asu.edu/Page1/Service1.svc?wsdl</asp:TableCell>
        </asp:TableRow>
    </asp:Table>
</asp:Content>