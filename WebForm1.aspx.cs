using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

namespace CRUD_Xml
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        string xmlfile = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                xmlfile = Server.MapPath("Employee.xml");
                LoadData();
            }
        }
        protected void LoadData()
        {
            DataSet ds = new DataSet();
 
            ds.ReadXml(Server.MapPath("Employee.xml"));
            EmployeeListView.DataSource = ds;

            EmployeeListView.DataBind();
        }

        protected void EmployeeListView_ItemInserting(object sender, ListViewInsertEventArgs e)
        {
          //insert record

            TextBox txtNameTextBox = (TextBox)EmployeeListView.InsertItem.FindControl("txtName");
            TextBox txtMobileTextBox = (TextBox)EmployeeListView.InsertItem.FindControl("txtMobile");
            TextBox txtCityTextBox = (TextBox)EmployeeListView.InsertItem.FindControl("txtCity");
            TextBox txtCountryTextBox = (TextBox)EmployeeListView.InsertItem.FindControl("txtCountry");

            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(Server.MapPath("Employee.xml"));
            XmlElement xelement = xmlDoc.CreateElement("Employee");

            XmlElement xName = xmlDoc.CreateElement("Name");
            xName.InnerText = txtNameTextBox.Text;
            xelement.AppendChild(xName);

            XmlElement xMobile = xmlDoc.CreateElement("Mobile");
            xMobile.InnerText = txtMobileTextBox.Text;
            xelement.AppendChild(xMobile);

            XmlElement xCity = xmlDoc.CreateElement("City");
            xCity.InnerText = txtCityTextBox.Text;
            xelement.AppendChild(xCity);

            XmlElement xCountry = xmlDoc.CreateElement("Country");
            xCountry.InnerText = txtCountryTextBox.Text;
            xelement.AppendChild(xCountry);

            xmlDoc.DocumentElement.AppendChild(xelement);
            xmlDoc.Save(Server.MapPath("Employee.xml"));
            LoadData();
        }
      
        protected void EmployeeListView_ItemDeleting(object sender, ListViewDeleteEventArgs e)
        {
            //delete record
            Label lblName = (EmployeeListView.Items[e.ItemIndex].FindControl("lblName")) as Label;
            Label lblMobile = (EmployeeListView.Items[e.ItemIndex].FindControl("lblMobile")) as Label;
            Label lblCity = (EmployeeListView.Items[e.ItemIndex].FindControl("lblCity")) as Label;
            Label lblCountry = (EmployeeListView.Items[e.ItemIndex].FindControl("lblCountry")) as Label;

            XmlDocument xmlDoc = new XmlDocument();
     
            DataSet ds = new DataSet();
            ds.ReadXml(Server.MapPath("Employee.xml"));
            ds.Tables[0].Rows.RemoveAt(e.ItemIndex);
            ds.WriteXml(Server.MapPath("Employee.xml"));
            xmlDoc = null;
            LoadData();

        }
        static Int32 i = 0; 
        protected void EmployeeListView_ItemEditing(object sender, ListViewEditEventArgs e)
        {
            //edit record 

            EmployeeListView.EditIndex = e.NewEditIndex;
            i = Convert.ToInt32(EmployeeListView.EditIndex);

            Label lblName = (Label)EmployeeListView.EditItem.FindControl("lblName");
            Label lblMobile = (Label)EmployeeListView.EditItem.FindControl("lblMobile");
            Label lblCity = (Label)EmployeeListView.EditItem.FindControl("lblCity");
            Label lblCountry = (Label)EmployeeListView.EditItem.FindControl("lblCountry");

            TextBox txtnameTextBox = (TextBox)EmployeeListView.InsertItem.FindControl("txtName");
            TextBox txtMobileTextBox = (TextBox)EmployeeListView.InsertItem.FindControl("txtMobile");
            TextBox txtCityTextBox = (TextBox)EmployeeListView.InsertItem.FindControl("txtCity");
            TextBox txtCountryTextBox = (TextBox)EmployeeListView.InsertItem.FindControl("txtCountry");
            txtnameTextBox.Text = lblName.Text;
            txtMobileTextBox.Text = lblMobile.Text;
            txtCityTextBox.Text = lblCity.Text;
            txtCountryTextBox.Text = lblCountry.Text;
        }

        protected void EmployeeListView_ItemCanceling(object sender, ListViewCancelEventArgs e)
        {
            //cancle
            TextBox txtNameTextBox = (TextBox)EmployeeListView.InsertItem.FindControl("txtName");
            TextBox txtMobileTextBox = (TextBox)EmployeeListView.InsertItem.FindControl("txtMobile");
            TextBox txtCityTextBox = (TextBox)EmployeeListView.InsertItem.FindControl("txtCity");
            TextBox txtCountryTextBox = (TextBox)EmployeeListView.InsertItem.FindControl("txtCountry");
            txtNameTextBox.Text = string.Empty;
            txtMobileTextBox.Text = string.Empty;
            txtCityTextBox.Text = string.Empty;
            txtCountryTextBox.Text = string.Empty;
        }

        protected void btnUpdate_Click(object sender, ImageClickEventArgs e)
        {
         //update record
            TextBox txtNameTextBox = (TextBox)EmployeeListView.InsertItem.FindControl("txtName");
            TextBox txtMobileTextBox = (TextBox)EmployeeListView.InsertItem.FindControl("txtMobile");
            TextBox txtCityTextBox = (TextBox)EmployeeListView.InsertItem.FindControl("txtCity");
            TextBox txtCountryTextBox = (TextBox)EmployeeListView.InsertItem.FindControl("txtCountry");

            XmlDocument xmldoc = new XmlDocument();
            xmldoc.Load(Server.MapPath("Employee.xml"));

            XmlNode xmlnode = xmldoc.DocumentElement.ChildNodes.Item(i);
            xmlnode["Name"].InnerText = txtNameTextBox.Text;
            xmlnode["Mobile"].InnerText = txtMobileTextBox.Text;
            xmlnode["City"].InnerText = txtCityTextBox.Text;
            xmlnode["Country"].InnerText = txtCountryTextBox.Text;
            xmldoc.Save(Server.MapPath("Employee.xml"));
            LoadData();
        }
    }
}