using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;//Dataset vb. ADO.net nesnelerine erişim için ekliyoruz
using System.Data.SqlClient;//MSSQLSERVER ile ilgili ADO.net nesnelerine erişim için ekliyoruz
using System.Configuration;//Configuration sınıflarına erişim için ekliyoruz.(Web.config te oluşturduğumuz ConnectionStringimize erişmek istiyoruz)

public partial class OgrenciGiris : System.Web.UI.Page
{
    //Web.Config dosyamızda oluşturduğumuz ConnectioStringe name özelliğine atadığımız değer üzerinden erişiyoruz.
    string baglantiYolu = ConfigurationManager.ConnectionStrings["baglantiYolum"].ToString();

    protected void Page_Load(object sender, EventArgs e)
    {
                
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        SqlConnection baglanti = new SqlConnection(baglantiYolu);
        SqlCommand komut = new SqlCommand();
        komut.Connection = baglanti;
        komut.CommandText = "select Ad, Soyad from Ogrenci where OgrenciNo=@pNo and Sifre=@pSifre";
        komut.Parameters.AddWithValue(@"pNo", TextBox1.Text);
        komut.Parameters.AddWithValue(@"pSifre", TextBox2.Text);
        DataSet donenVeri = new DataSet();
        SqlDataAdapter adaptor = new SqlDataAdapter();
        adaptor.SelectCommand = komut;
        adaptor.Fill(donenVeri);

        //donenVeri'de en azından 1 veri varsa bu kullanıcı adı ve şifreye sahip bir kullanıcı var anlamına geliyor.
        if (donenVeri.Tables[0].Rows.Count > 0)
        {
            //Dİğer sayfalarda kullanmak üzere session nesnelerimize ilgili değerleri atıyoruz.
            Session["OGirisYetkisi"] = true;
            Session["OAd"] = donenVeri.Tables[0].Rows[0]["Ad"].ToString();
            Session["OSoyad"] = donenVeri.Tables[0].Rows[0]["Soyad"].ToString();
            Session["ONo"] = TextBox1.Text;
            //Ziyaretçiyi OgrenciIslemler.aspx sayfasına yönlendiriyoruz.
            Response.Redirect("OgrenciIslemler.aspx");
        }
        else
            Response.Write("Yanlış kullanıcı adı veya şifre");
    }
}