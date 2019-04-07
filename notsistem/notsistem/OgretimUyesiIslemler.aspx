<%@ Page Language="C#" AutoEventWireup="true" CodeFile="OgretimUyesiIslemler.aspx.cs" Inherits="OgretimUyesiIslemler" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <br />
        Bu dönem verdiğiniz dersler:<br />
        <br />
    
        <asp:Repeater ID="Repeater1" runat="server">
            <%-- ItemTamplate içerisinde herbir kaydın nasıl görüntüleneceğini tek bir şablon kayıt yapısı üzerinden
                tasarlayabiliyoruz. Mesela burada herbir kaydın bir link olarak görüntülenmesini istiyoruz.--%>
            <ItemTemplate>
                <%-- Eval() metodu ile kontrolümüze (genellikle bu kontroller koleksiyon niteliğindedir, burada da koleksiyonların
                    gösteriminde kullanılan Repeater1 kontrolü söz konusu) bağlanan veride yer alan kayıtların değerlerine erişebiliyoruz.
                    Bunun için takip edebileceğimiz yollardan biri ilgili kolon adını Eval metoduna parametre olarak yazmak. --%>
                <a href="NotGiris.aspx?dersID=<%# Eval("DersKodu") %>"><%# Eval("DersAdi") %></a> <br />
            </ItemTemplate>
        </asp:Repeater>
    
        <br />
        <br />
        <a href="Default.aspx">Çıkış</a> 

    </div>
    </form>
</body>
</html>
