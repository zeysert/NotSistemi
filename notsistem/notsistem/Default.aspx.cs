using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //Sitemize giriş yapmak isteyenler için 2 türlü rol müvcut (Öğrenci, Öğretim Üyesi). Burada sitemizi ziyaret eden kişilerin yetkilerini false
        //olarak ayarlıyoruz. Bu yetki bilgilerine diğer sayfalardan erişim için de bunları Session nesneleri içinde tutuyoruz. Bundan sonra, Login
        //sayfalarında kullanıcı adı ve şifresi doğrulanan ziyaretçilerin yetkileri rollerine göre bu session nesneleri üzerinden true ya çekilecek
        //ve her sayfanın Page_Load eventinde bu yetki kontorlü yapılacak: yetki varsa işlemler gerçekleştirilecek, yoksa ziyaretçi ilgili login
        //sayfasına yönlendirilecek.Ayrıca siteden çıkış yapan ziyaretçi default.aspx sayfasına yönlendirilecek ve böylece yetkisi de sıfırlanmış olacak.
        
        Session["OGirisYetkisi"] = false;
        Session["OUGirisYetkisi"] = false;
    }
}