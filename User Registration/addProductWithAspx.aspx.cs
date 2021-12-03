using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Text.RegularExpressions;

namespace User_Registration
{
    public partial class Index : System.Web.UI.Page
    {
        string connectionString = @"Data Source =.; Initial Catalog = UserRegistrationDB; Integrated Security=True;";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Clear();
                if (!String.IsNullOrEmpty(Request.QueryString["id"]))
                {
                    int userID = Convert.ToInt32(Request.QueryString["id"]);
                    using (SqlConnection sqlCon = new SqlConnection(connectionString))
                    {
                        sqlCon.Open();
                        SqlDataAdapter sqlDa = new SqlDataAdapter("UserViewByID",sqlCon);
                        sqlDa.SelectCommand.CommandType = CommandType.StoredProcedure;
                        sqlDa.SelectCommand.Parameters.AddWithValue("@UserID",userID);
                        DataTable dtbl = new DataTable();
                        sqlDa.Fill(dtbl);

                        hfUserID.Value = userID.ToString();
                        nameOfProduct.Text = dtbl.Rows[0][1].ToString();
                        numberOfProduct.Text = dtbl.Rows[0][2].ToString();
                        countryOfProduct.Items.FindByValue(dtbl.Rows[0][4].ToString()).Selected = true;
                        yearOfManufacturing.Text = dtbl.Rows[0][5].ToString();
                        priceOfProduct.Text = dtbl.Rows[0][6].ToString();
                        typeOfProdcut.Text = dtbl.Rows[0][7].ToString();
                        
                      
                    }
                }
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            //	Regex regex = new Regex(@"/\w{3}-\d{7}/", RegexOptions.ExplicitCapture | RegexOptions.IgnoreCase);
            // = regex.Matches("rrr-1234567");
            
            double numericValue;
            if (nameOfProduct.Text == "" || numberOfProduct.Text == "")
                lblErrorMessage.Text = "Please Fill Mandatory Fields";
            else if (!Regex.Match(numberOfProduct.Text, @"\w{3}-\d{7}").Success || numberOfProduct.Text.Length < 10)
                lblErrorMessage.Text = "input number of product must like (rrr-1234567)";
            else if (!double.TryParse(priceOfProduct.Text, out numericValue) || priceOfProduct.Text == "")
                lblErrorMessage.Text = "Please enter the price of product and make sure make it number";
            else if (yearOfManufacturing.Text == "" || yearOfManufacturing.Text.Length != 4 && Convert.ToInt32(yearOfManufacturing.Text) % 2 != 0 )
                lblErrorMessage.Text = "the year must be a positive number and contain at least four number";
            else if (Convert.ToDouble(priceOfProduct.Text) < 0 || Convert.ToDouble(priceOfProduct.Text) > 10000 )
                lblErrorMessage.Text = "the price must be positive and between 0 - 10000";
            else if (!Regex.Match(typeOfProdcut.Text, @"^[A-Za-z0-9]+$").Success)
                lblErrorMessage.Text = "Please make sure if the field contain only letters and numbers";
            else
            {
                /*using (SqlConnection sqlCon = new SqlConnection(connectionString))
                {
                    sqlCon.Open();
                    SqlCommand sqlCmd = new SqlCommand("UserAddOrEdit", sqlCon);
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    sqlCmd.Parameters.AddWithValue("@UserID", Convert.ToInt32(hfUserID.Value == "" ? "0" : hfUserID.Value));
                    sqlCmd.Parameters.AddWithValue("@nameOfProduct", nameOfProduct.Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@numberOfProduct", numberOfProduct.Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@countryOfProduct", countryOfProduct.SelectedValue);
                    sqlCmd.Parameters.AddWithValue("@yearOfManufacturing", yearOfManufacturing.Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@priceOfProduct", priceOfProduct.Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@typeOfProduct", typeOfProdcut.Text.Trim());
                    sqlCmd.ExecuteNonQuery();
                    Clear();
                    lblSuccessMessage.Text = "Submitted Successfully";
                    Response.Redirect("ResultOfAsp.aspx");
                }*/
                lblSuccessMessage.Text = "Submitted Successfully";
                Response.Redirect("ResultOfAsp.aspx");
            }
        }

        void Clear()
        {
            nameOfProduct.Text = numberOfProduct.Text  = countryOfProduct.Text = yearOfManufacturing.Text = priceOfProduct.Text = typeOfProdcut.Text = "";
            hfUserID.Value = "";
            lblSuccessMessage.Text = lblErrorMessage.Text = "";
        }
    }
}