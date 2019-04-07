using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class OgrenciIslemler : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //Ziyaretçimizin bu sayfayı görüntüleyebilmesi için öncelikle öğrenci giriş sayfasında yetkisini alabilmiş olması lazım.
        //Bu durumu kontrol ediyoruz. Yetkisi varsa OgrenciGiris.aspx te aldığımız ve Session nesneleri ile saklayarak tüm site genelinde 
        //kullanabileceğimiz Ad Soyad bilgileri ile onu karşılıyoruz.
        if ((bool)Session["OGirisYetkisi"] == true)
            Response.Write("Merhaba " + Session["OAd"].ToString() + " " + Session["OSoyad"].ToString());
        else
            Response.Redirect("OgrenciGiris.aspx");
    }
}