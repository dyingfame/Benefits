using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Xml.Linq;
using System.Data.SqlClient;


public partial class doctors : System.Web.UI.Page
{
    private DataSet doctorsDataSet;
    private DataView doctorsDataView;
    private SqlConnection doctorsConnection;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            doctorsGridView.DataSource = SqlDataSource1;
            doctorsGridView.DataBind();
            
            //TODO Lab8: Bind the list to city field in the doctors table.
            //createDataSet();  //lab02
            //createCitiesList();  //lab02
            //TODO Lab9: Bind the listbox to the getUniqueCities stored procedure.
            createDataSet();
            createCitiesListWithProcedure();
            //TODO Lab8: Add the "All" item to the list and select it.
            citiesList.Items.Add("All");
            citiesList.SelectedIndex = 4;
            // Hide the specialties ListBox.
            specialtiesListBox.Visible = false;
            specialtiesLabel.Visible = false;

        }
    }

    private void createDataSet()
    {
        
        SqlDataAdapter doctorsSqlDataAdapter;

        string strConn = "data source=localhost; " + "initial catalog=doctors; " + "integrated security=true";
        doctorsConnection = new SqlConnection(strConn);
        string myDataString = ConfigurationManager.ConnectionStrings["doctorsConnectionString1"].ConnectionString;
        doctorsConnection = new SqlConnection(myDataString);
        doctorsConnection.ConnectionString = SqlDataSource1.ConnectionString;
        doctorsConnection.Open();
        doctorsSqlDataAdapter = new SqlDataAdapter("select * from doctors", doctorsConnection);
        doctorsSqlDataAdapter.SelectCommand = new SqlCommand(SqlDataSource1.SelectCommand,doctorsConnection);
        doctorsDataSet = new DataSet();
        doctorsSqlDataAdapter.Fill(doctorsDataSet, "doctors");
    }

    private void createCitiesList()
    {
        SqlCommand citiesSqlCommand;
        SqlDataReader citiesSqlDataReader;
        citiesSqlCommand = new SqlCommand("Select DISTINCT city from doctors", doctorsConnection);
        citiesSqlDataReader = citiesSqlCommand.ExecuteReader();
        citiesList.DataSource = citiesSqlDataReader;
        citiesList.DataTextField = "city";
        citiesList.DataBind();
        while (citiesSqlDataReader.Read())
        {
            citiesList.Items.Add(citiesSqlDataReader["city"].ToString());
        }
        citiesSqlDataReader.Close();
        doctorsConnection.Close();
    }

    private void createCitiesListWithProcedure()
    {
        SqlCommand citiesSqlCommand = new SqlCommand("getUniqueCities", doctorsConnection);
        citiesSqlCommand.CommandType = CommandType.StoredProcedure;
        SqlDataReader citiesSqlDataReader;
        citiesSqlDataReader = citiesSqlCommand.ExecuteReader();
        citiesList.DataSource = citiesSqlDataReader;
        citiesList.DataTextField = "City";
        citiesList.DataBind();
        citiesSqlDataReader.Close();
        doctorsConnection.Close();
    }

    private void Reset()
    {
		// Reset page index to 0.
		doctorsGridView.PageIndex = 0;

		// Remove the selection from the datagrid.
		doctorsGridView.SelectedIndex = -1;

		// Hide the specialties listbox.
        specialtiesListBox.Visible = false;
        specialtiesLabel.Visible = false;
    }
    
    protected void submitButton_Click(object sender, EventArgs e)
    {
        int currentIndex;
        if (doctorsGridView.SelectedIndex != -1)
        {
            String doctorName;
            currentIndex = doctorsGridView.SelectedIndex + (doctorsGridView.PageIndex * doctorsGridView.PageSize);
            doctorName = doctorsGridView.Rows[currentIndex % 5].Cells[3].Text.ToString().Trim() 
                + " " 
                + doctorsGridView.Rows[currentIndex % 5].Cells[2].Text.ToString().Trim();
            Response.Redirect("medical.aspx?pcp=" + doctorName);
        }
        
    }

    protected void citiesList_selectedIndexChanged(object sender, EventArgs e)
    {
        String cityName = citiesList.SelectedItem.Value.Trim();
        if (cityName.Equals("All"))
        {
            doctorsGridView.DataSource = SqlDataSource1;
            doctorsGridView.DataBind();
        }
        else
        {
            createDataSet();
            doctorsDataView = doctorsDataSet.Tables[0].DefaultView;
            doctorsDataView.RowFilter = "city ='" + cityName + "' ";
            doctorsGridView.DataSource = doctorsDataView;
            doctorsGridView.DataBind();
        }
        Reset();
    }

    protected void doctorsGridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        doctorsGridView.PageIndex = e.NewPageIndex;
        doctorsGridView.DataBind();
    }

    protected void doctorsGridView_PageIndexChanged(object sender, EventArgs e)
    {
        createDataSet();
        String cityName = citiesList.SelectedItem.Value.Trim();
        if (cityName.Equals("All"))
        {
            doctorsGridView.DataSource = SqlDataSource1;
            doctorsGridView.DataBind();
        }
        else
        {
            createDataSet();
            doctorsDataView = doctorsDataSet.Tables[0].DefaultView;
            doctorsDataView.RowFilter = "city ='" + cityName + "' ";
            doctorsGridView.DataSource = doctorsDataView;
            doctorsGridView.DataBind();
        }
    }

    protected void doctorsGridView_SelectIndexChanged(object sender, EventArgs e)
    {
        //Exercise 09 Exercise 2
        /*String drID;
        int currentIndex;
        createDataSet();
        currentIndex = doctorsGridView.SelectedIndex + (doctorsGridView.PageIndex * doctorsGridView.PageSize);
        drID = doctorsGridView.Rows[currentIndex % doctorsGridView.PageSize].Cells[1].Text.ToString().Trim();
        SqlCommand specialtiesSqlCommand = new SqlCommand("getDrSpecialty", doctorsConnection);
        specialtiesSqlCommand.CommandType = CommandType.StoredProcedure;
        SqlParameter specialtiesParameter = new SqlParameter("@dr_id",SqlDbType.Char,4);
        specialtiesParameter.Direction = ParameterDirection.Input;
        specialtiesParameter.Value = drID;
        specialtiesSqlCommand.Parameters.Add(specialtiesParameter);
        SqlDataReader specialtiesSqlDataReader = specialtiesSqlCommand.ExecuteReader();
        specialtiesListBox.DataSource = specialtiesSqlDataReader;
        specialtiesListBox.DataTextField = "Specialty";
        specialtiesListBox.DataBind();
        if (specialtiesSqlDataReader.IsClosed == false)
        {
            specialtiesListBox.Visible = specialtiesSqlDataReader.HasRows;
            specialtiesLabel.Visible = specialtiesSqlDataReader.HasRows;
        }
        specialtiesSqlDataReader.Close();
        doctorsConnection.Close();*/


        //Exercise 09 Exercise 3
        String drID;
        int currentIndex;
        currentIndex = doctorsGridView.SelectedIndex + (doctorsGridView.PageIndex * doctorsGridView.PageSize);
        drID = doctorsGridView.Rows[currentIndex % doctorsGridView.PageSize].Cells[1].Text.ToString().Trim();
        DoctorsDataContext doctorsContext = new DoctorsDataContext();
        specialtiesListBox.DataSource = doctorsContext.getDrSpecialty(drID);
        specialtiesListBox.DataTextField = "Specialty";
        specialtiesListBox.DataBind();
        if (specialtiesListBox.Text != null)
        {
            specialtiesListBox.Visible = true;
            specialtiesLabel.Visible = true;
        }
    }
}

