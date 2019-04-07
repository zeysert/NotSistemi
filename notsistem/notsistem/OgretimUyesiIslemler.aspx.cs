using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class OgretimUyesiIslemler : System.Web.UI.Page
{
    string baglantiYolu = ConfigurationManager.ConnectionStrings["baglantiYolum"].ToString();

    DataSet OUDersCek()
    {
        SqlConnection baglanti = new SqlConnection(baglantiYolu);
        SqlCommand komut = new SqlCommand();
        komut.Connection = baglanti;
        komut.CommandText = "select DersAdi, DersKodu from Ders where SicilNo=" + Session["SicilNo"].ToString();
        SqlDataAdapter adaptor = new SqlDataAdapter();
        adaptor.SelectCommand = komut;
        DataSet donenVeri = new DataSet();
        adaptor.Fill(donenVeri);
        return donenVeri;
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if ((bool)Session["OUGirisYetkisi"] == true)
        {
            Response.Write("Merhaba " + Session["OUAd"].ToString() + " " + Session["OUSoyad"].ToString());
            if(IsPostBack==false)
            {
                Repeater1.DataSource = OUDersCek().Tables[0];
                Repeater1.DataBind();
            }
        }
        else
            Response.Redirect("OgretimUyesiGiris.aspx");

    }
}