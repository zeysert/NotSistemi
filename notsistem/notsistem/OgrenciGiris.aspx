<%@ Page Language="C#" AutoEventWireup="true" CodeFile="OgrenciGiris.aspx.cs" Inherits="OgrenciGiris" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    Öğrenci Girişi<br />
        <br />
        Kullanıcı Adı:<asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        <br />
        <br />
        Şifre:<asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
        <br />
        <br />
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Giriş" />
    </div>
    </form>
</body>
</html>
