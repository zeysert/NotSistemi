<%@ Page Language="C#" AutoEventWireup="true" CodeFile="NotGiris.aspx.cs" Inherits="NotGiris" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <br />
        <asp:Label ID="Label10" runat="server" Text=" "></asp:Label>
        <br />
    
        <%-- GridView satırlarındaki kontrollerden gelebilecek tetiklemelerle ilgili kontrollerin tanımlamış olduğumuz komutlarını yönetmek üzere
            Gridview açılış tagine özellik olarak OnRowCommand="Button1_RowCommand" ekliyoruz. Kolon düzenlemelerini ItemTemplate ile biz yapacağımız için
             AutoGenerateColumns="False" diyoruz.  --%>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" OnRowCommand="Button1_RowCommand">
            <Columns>
                <%-- GridView kontrolünde kayıtları istediğimiz şekilde göstermek için öncelikle TemplateField ekliyoruz.
                    Bunun içerisinde de Repeaterdakine benzer şekilde ItemTemplate tanımlıyoruz. (Gridviewe başlık satırı eklemek istersek HaederTamplate de ekliyoruz.) --%>
                <asp:TemplateField>
                    <HeaderTemplate>
                        <asp:Label ID="Label4" runat="server" Width="70px" Text="OgrenciNo"></asp:Label>
                        <asp:Label ID="Label5" runat="server" Width="60px" Text="Ad"></asp:Label>
                        <asp:Label ID="Label6" runat="server" Width="60px" Text="Soyad"></asp:Label>
                        <asp:Label ID="Label7" runat="server" Width="60px" Text="Vize"></asp:Label>
                        <asp:Label ID="Label8" runat="server" Width="60px" Text="Final"></asp:Label>
                        <asp:Label ID="Label9" runat="server" Width="60px" Text="Güncelle"></asp:Label>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label1" runat="server" Width="70px" Text='<%# Eval("OgrenciNo") %>'></asp:Label>
                        <asp:Label ID="Label2" runat="server" Width="60px" Text='<%# Eval("Ad") %>'></asp:Label>
                        <asp:Label ID="Label3" runat="server" Width="60px" Text='<%# Eval("Soyad") %>'></asp:Label>
                        <asp:TextBox ID="TextBox1" runat="server" Width="60px" Text='<%# Eval("Vize") %>'></asp:TextBox>
                        <asp:TextBox ID="TextBox2" runat="server" Width="60px" Text='<%# Eval("Final") %>'></asp:TextBox>
                        <%--Herbir kayıt için butona tıklandığında gerçekleştirilmesini istediğimiz olayları yönetebilmek için butona özellik olarak
                             CommandName ekliyoruz. Bu özelliğe verdiğimiz değer üzerinden OnRowCommand eventinde buton tıklandığında gerçekleştirilecek 
                            işlemleri yönetebileceğiz.Bu komut ile .cs kod sayfamıza taşımak istediğimiz kaçıncı satırda bulunduğumuz bilgisini CommandArgument ile taşıyoruz   --%>
                        <asp:Button ID="Button1" runat="server" Width="60px" Text="Güncelle" CommandName="NotGuncelle" CommandArgument="<%# Container.DataItemIndex %>" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    
    </div>
    </form>
</body>
</html>
