using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Simple_Webapp
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string StudentName = TextBox1.Text;
            string StudentAddress = TextBox2.Text;
            string StudentCell = TextBox3.Text;

            SqlConnection db = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"D:\\University\\7th Semester\\IPT\\k190324_Assignment1\\Simple-Webapp\\Simple-Webapp\\App_Data\\Database1.mdf\";Integrated Security=True");
            SqlCommand commandID = new SqlCommand("Select StudentID from Student", db);

            int StudentID = 0;
           
            db.Open();
            SqlDataReader reader = commandID.ExecuteReader();
            
            while (reader.Read())
                StudentID++;
            
            db.Close();

            SqlCommand command = new SqlCommand("Insert into Student(StudentID, StudentName, StudentAddress, StudentCell) values(@StudentID, @StudentName, @StudentAddress, @StudentCell)", db);

            command.Parameters.Add("@StudentID", SqlDbType.Int).Value = StudentID+1;
            command.Parameters.Add("@StudentName", SqlDbType.VarChar, 50).Value = StudentName;
            command.Parameters.Add("@StudentAddress", SqlDbType.VarChar, 50).Value = StudentAddress;
            command.Parameters.Add("@StudentCell", SqlDbType.VarChar, 11).Value = StudentCell;

            db.Open();
            command.ExecuteNonQuery();
            db.Close();
        }

        protected void TextBox2_TextChanged(object sender, EventArgs e)
        {
            
        }

        protected void Delete_Click(object sender, EventArgs e)
        {
            String tmpID = GridView1.SelectedRow.Cells[2].Text;
            int StudentID = Int16.Parse(tmpID);

            SqlConnection db = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"D:\\University\\7th Semester\\IPT\\k190324_Assignment1\\Simple-Webapp\\Simple-Webapp\\App_Data\\Database1.mdf\";Integrated Security=True");
            SqlCommand deleteCmd = new SqlCommand("Delete from Student where StudentID = @StudentID", db);

            deleteCmd.Parameters.Add("@StudentID", SqlDbType.Int).Value = StudentID;

            db.Open();
            deleteCmd.ExecuteNonQuery();
            db.Close();
        }
    }
}