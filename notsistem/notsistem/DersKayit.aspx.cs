using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class DersKayit : System.Web.UI.Page
{
    string baglantiYolu = ConfigurationManager.ConnectionStrings["baglantiYolum"].ToString();
    DataSet DersCek()
    {
        SqlConnection baglanti = new SqlConnection(baglantiYolu);
        SqlCommand komut = new SqlCommand();
        komut.Connection = baglanti;
        komut.CommandText = "select DersAdi, DersKodu from Ders";
        SqlDataAdapter adptor = new SqlDataAdapter();
        adptor.SelectCommand = komut;
        DataSet dersler = new DataSet();
        adptor.Fill(dersler);
        return dersler;
    }
    void DersEkle()
    {
        SqlConnection baglanti = new SqlConnection(baglantiYolu);
        SqlCommand komut = new SqlCommand();
        komut.Connection = baglanti;
        komut.CommandText = "insert into OgrenciDers (OgrenciNo, DersKodu) values (@pONo, @pDersK)";
        komut.Parameters.AddWithValue(@"pONo", Session["ONo"]);
        komut.Parameters.AddWithValue(@"pDersK", DropDownList1.SelectedValue);
        baglanti.Open();
        komut.ExecuteNonQuery();
        baglanti.Close();
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if ((bool)Session["OGirisYetkisi"] == true)
        {
            //özellikle Page_Load eventinde ve yine özellikle veri bağlama işlemlerinde IsPostBack kontrolüne dikkat ediyoruz.
            if(IsPostBack==false)
            {
                //Web uygulamalarında ComboBox benzeri bir yapı olarak DropDownList kullanıyoruz. Combobox'ta olduğu gibi elemanların kullanıcıya gösterilecek
                //hali (DataTextField) ve elemanların arkaplanda ifade ettği değer (DataValueField) olarak
                //verikaynağının (DataSource) hangi kolonunun ayarlanacağını belirliyoruz.
                DropDownList1.DataTextField = "DersAdi";
                DropDownList1.DataValueField = "DersKodu";
                DropDownList1.DataSource = DersCek().Tables[0];
                //Web uygulamalarında kontrolün veri kaynağını ayarladıktan sonra DataBind() ile veri bağlama işlemini de gerçekleştirmemiz gerekiyor.
                DropDownList1.DataBind();
            }
        }
        else
            Response.Redirect("OgrenciGiris.aspx");
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        DersEkle();
        Response.Write("Seçtiğiniz ders kaydınıza eklendi");
    }
}