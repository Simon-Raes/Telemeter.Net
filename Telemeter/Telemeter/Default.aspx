<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Telemeter.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        Login: <asp:TextBox ID="txtLogin" runat="server"></asp:TextBox><br />
        Password: <asp:TextBox ID="txtPassword" runat="server"></asp:TextBox><br />
        <asp:Button ID="btnGo" runat="server" Text="Get information" OnClick="btnGo_Click" /><br />
        <br />
        Total usage: <asp:Label ID="lblTotalUsed" runat="server" Text=""></asp:Label>
    &nbsp;(out of maximum <asp:Label ID="lblMaxOne" runat="server" Text="Label"></asp:Label>&nbsp;-&nbsp;<asp:Label ID="lblMaxTwo" runat="server" Text="Label"></asp:Label>)
        <br />
        Period: <asp:Label ID="lblFrom" runat="server" Text="Label"></asp:Label>&nbsp;-&nbsp;<asp:Label ID="lblTill" runat="server" Text="Label"></asp:Label>
        <br />
        Status:
        <asp:Label ID="lblStatus" runat="server" Text="Label"></asp:Label>
    </div>
    </form>
</body>
</html>
