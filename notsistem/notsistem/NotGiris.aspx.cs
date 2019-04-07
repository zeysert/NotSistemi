using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class NotGiris : System.Web.UI.Page
{
    string baglantiYolu = ConfigurationManager.ConnectionStrings["baglantiYolum"].ToString();
    DataSet DersDetayCek()
    {
        SqlConnection baglanti = new SqlConnection(baglantiYolu);
        SqlCommand komut = new SqlCommand();
        komut.Connection = baglanti;
        komut.CommandText = "select Ogrenci.OgrenciNo, Ad, Soyad, Vize, Final, DersAdi from Ogrenci, OgrenciDers, Ders where Ogrenci.OgrenciNo=OgrenciDers.OgrenciNo and OgrenciDers.DersKodu=Ders.DersKodu and Ders.DersKodu=@pKod and Ders.SicilNo=" + Session["SicilNo"].ToString();
        komut.Parameters.AddWithValue(@"pKod", Request.QueryString["dersID"]);
        SqlDataAdapter adaptor = new SqlDataAdapter();
        adaptor.SelectCommand = komut;
        DataSet donenVeri = new DataSet();
        adaptor.Fill(donenVeri);
        return donenVeri;
    }
    void Guncelle( )
    {
        
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if ((bool)Session["OUGirisYetkisi"] == true)
        {            
            if (IsPostBack == false)
            {
                DataSet dersDetayBilgisi = DersDetayCek();
                //URL ile başka sayfadan transfer edilen bilgiyi Request.QueryString ile alıyoruz.
                Label10.Text = Request.QueryString["dersID"].ToString()+" "+ dersDetayBilgisi.Tables[0].Rows[0]["DersAdi"].ToString();
                GridView1.DataSource = dersDetayBilgisi.Tables[0];
                GridView1.DataBind();
            }
        }
        else
            Response.Redirect("OgretimUyesiGiris.aspx");
    }

    protected void Button1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        //Source kısmında butona tanımladığımız Command özelliklerine e üzerinden erişebiliriz.
        if(e.CommandName=="NotGuncelle")
        {
            //Kaçıncı satırda olduğumuz bilgisini CommandArgument ile taşımıştık.
            int satirIndeksi = Convert.ToInt32(e.CommandArgument);
            GridViewRow satir = GridView1.Rows[satirIndeksi];

            //GridView satırındaki kolonlara erişim için FindKontrol(kontrolün ID'si) metodunu kullanıyoruz.
            string guncelVize = ((TextBox)satir.FindControl("TextBox1")).Text;
            string guncelFinal = ((TextBox)satir.FindControl("TextBox2")).Text;
            string ogrenciNo = ((Label)satir.FindControl("Label1")).Text;

            SqlConnection baglanti = new SqlConnection(baglantiYolu);
            SqlCommand komut = new SqlCommand();
            komut.Connection = baglanti;
            komut.CommandText = "update OgrenciDers set Vize=@pVize, Final=@pFinal where OgrenciNo=@pNo and DersKodu=" + Request.QueryString["dersID"].ToString();
            komut.Parameters.AddWithValue(@"pVize", guncelVize);
            komut.Parameters.AddWithValue(@"pFinal", guncelFinal);
            komut.Parameters.AddWithValue(@"pNo", ogrenciNo);
            baglanti.Open();
            komut.ExecuteNonQuery();
            baglanti.Close();

            Response.Write("Not girişi başarılı");
        }
    }

    
}