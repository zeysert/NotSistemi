using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class NotSorgu : System.Web.UI.Page
{
    string baglantiYolu = ConfigurationManager.ConnectionStrings["baglantiYolum"].ToString();

    DataSet NotCek()
    {
        SqlConnection baglanti = new SqlConnection(baglantiYolu);
        SqlCommand komut = new SqlCommand();
        komut.Connection = baglanti;
        komut.CommandText = "select DersAdi, Vize, Final, (Vize*0.4+Final*0.6) as Ortalama from OgrenciDers, Ders where OgrenciDers.DersKodu=Ders.DersKodu and OgrenciNo=" + Session["ONo"].ToString();
        SqlDataAdapter adaptor = new SqlDataAdapter();
        adaptor.SelectCommand = komut;
        DataSet donenVeri = new DataSet();
        adaptor.Fill(donenVeri);
        return donenVeri;
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if((bool)Session["OGirisYetkisi"]==true)
        {
            if (IsPostBack == false)
            {
                GridView1.DataSource = NotCek().Tables[0];
                GridView1.DataBind();
            }
        }
        else
            Response.Redirect("OgrenciGiris.aspx");
       
    }
}