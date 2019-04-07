using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class OgretimUyesiGiris : System.Web.UI.Page
{
    string baglantiYolu = ConfigurationManager.ConnectionStrings["baglantiYolum"].ToString();

    DataSet OgretimUyesiBilgisiCek()
    {
        SqlConnection baglanti = new SqlConnection(baglantiYolu);
        SqlCommand komut = new SqlCommand();
        komut.Connection = baglanti;
        komut.CommandText = "select Adi, Soyadi from OgretimUyesi where SicilNo=@pNo and Sifre=@pSifre";
        komut.Parameters.AddWithValue(@"pNo", TextBox1.Text);
        komut.Parameters.AddWithValue(@"pSifre", TextBox2.Text);
        DataSet donenVeri = new DataSet();
        SqlDataAdapter adaptor = new SqlDataAdapter();
        adaptor.SelectCommand = komut;
        adaptor.Fill(donenVeri);
        return donenVeri;
    }
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        DataSet ogretimUBilgisi = OgretimUyesiBilgisiCek();
        if (ogretimUBilgisi.Tables[0].Rows.Count > 0)
        {
            Session["OUGirisYetkisi"] = true;
            Session["OUAd"] = ogretimUBilgisi.Tables[0].Rows[0]["Adi"].ToString();
            Session["OUSoyad"] = ogretimUBilgisi.Tables[0].Rows[0]["Soyadi"].ToString();
            Session["SicilNo"] = TextBox1.Text;
            Response.Redirect("OgretimUyesiIslemler.aspx");
        }
        else
            Response.Write("Yanlış kullanıcı adı veya şifre");
    }
}