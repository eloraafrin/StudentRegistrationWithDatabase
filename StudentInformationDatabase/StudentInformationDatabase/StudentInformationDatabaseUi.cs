using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudentInformationDatabase
{
    public partial class StudentInformationDatabaseUi : Form
    {
        public StudentInformationDatabaseUi()
        {
            InitializeComponent();
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            string name = nameTextBox.Text;
            string address = addressTextBox.Text;
            string regNo = regNoTextBox.Text;
            string mobile = contactTextBox.Text;
            int deptID = Convert.ToInt32(deptIDTextBox.Text);
            int courseID = Convert.ToInt32(courseIDTextBox.Text);

            if (Exists(regNo))
            {
                MessageBox.Show("Exist");
                return;
            }

            try
            {
                string connectionString = @"Server = .\SQLEXPRESS; Database = StudentDb; Integrated Security = true";

                SqlConnection con = new SqlConnection(connectionString);



                string query = @"INSERT INTO Students(Name, Address,ContactNo ,RegNo,DepartmentID, CourseID )VALUES('" + name + "','" + address + "'," + mobile + ", '" + regNo + "'," + deptID + ", " + courseID + ")";

                SqlCommand sqlCommand = new SqlCommand(query,con);

                con.Open();
               

                int isExecuted = sqlCommand.ExecuteNonQuery();

                
               
                if (isExecuted > 0)
                {



                    MessageBox.Show("Saved");


                }
                else
                {
                    MessageBox.Show("Not saved");
                }

               

                con.Close();

                clear();
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
                //throw;
            }
        }

        void clear()
        {
            nameTextBox.Clear();
            addressTextBox.Clear();
            regNoTextBox.Clear();
            contactTextBox.Clear();
            deptIDTextBox.Clear();
            courseIDTextBox.Clear();
        }

        private void ShowButton_Click(object sender, EventArgs e)
        {
            try
            {
                string connectionString = @"Server = .\SQLEXPRESS; Database = StudentDb; Integrated Security = true";

                SqlConnection con = new SqlConnection(connectionString);

               
                string query = @"SELECT *FROM StudentsInfo;";
               
                con.Open();
                SqlCommand sqlCommand = new SqlCommand(query, con);


                
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                DataTable dataTable = new DataTable();
                sqlDataAdapter.Fill(dataTable);

               if (dataTable.Rows.Count>0)
                {
                    showDataGridView1.DataSource = dataTable;
                }

                else
                {
                   showDataGridView1.DataSource = null;
                }

               

                con.Close();

                clear();
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
                //throw;
            }
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(IdTextBox.Text);
            try
            {
                string connectionString = @"Server = .\SQLEXPRESS; Database = StudentDb; Integrated Security = true";

                SqlConnection con = new SqlConnection(connectionString);

             
                string query = @"DELETE Students WHERE ID = "+id+";";
                con.Open();
                SqlCommand sqlCommand = new SqlCommand(query, con);


                int isExecuted = sqlCommand.ExecuteNonQuery();

                if (isExecuted > 0)
                {
                    MessageBox.Show("Deleted");

                }
                else
                {
                    MessageBox.Show("Not Deleted");
                }

                con.Close();

                clear();
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
                //throw;
            }
        }

        private void UpdateButton_Click(object sender, EventArgs e)
        {

            string name = nameTextBox.Text;
            string address = addressTextBox.Text;
            string regNo = regNoTextBox.Text;
            string mobile = contactTextBox.Text;
            int deptID = Convert.ToInt32(deptIDTextBox.Text);
            int courseId = Convert.ToInt32(courseIDTextBox.Text);

            int id = Convert.ToInt32(IdTextBox.Text);
            try
            {
                string connectionString = @"Server = .\SQLEXPRESS; Database = StudentDb; Integrated Security = true";

                SqlConnection con = new SqlConnection(connectionString);

           
                string query = @"UPDATE Students SET Name = '" + name + "', Address = '" + address + "', ContactNo = '" + mobile + "', RegNo = '" + regNo + "', DepartmentID = " + deptID + ", CourseID = " + courseId + "  WHERE ID = " + id + "";
                con.Open();
                SqlCommand sqlCommand = new SqlCommand(query, con);

                int isExecuted = sqlCommand.ExecuteNonQuery();

                if (isExecuted > 0)
                {
                    MessageBox.Show("Updated");

                }
                else
                {
                    MessageBox.Show("Not Updated");
                }

                con.Close();

                clear();
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
                //throw;
            }
        }

        private void SearchButton_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(IdTextBox.Text);
            try
            {
                string connectionString = @"Server = .\SQLEXPRESS; Database = StudentDb; Integrated Security = true";

                SqlConnection con = new SqlConnection(connectionString);

              
                string query = @"SELECT *FROM StudentsInfo WHERE ID = "+id+";";
                con.Open();
                SqlCommand sqlCommand = new SqlCommand(query, con);

                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                DataTable dataTable = new DataTable();
                sqlDataAdapter.Fill(dataTable);

                if (dataTable.Rows.Count > 0)
                {
                    showDataGridView1.DataSource = dataTable;
                }

                else
                {
                    showDataGridView1.DataSource = null;
                }

              

                con.Close();

                 clear();
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
                //throw;
            }
        }


        private bool Exists(string regNo)
        {
            bool isExists = false;

            //int id = Convert.ToInt32(IdTextBox.Text);
            try
            {
                string connectionString = @"Server = .\SQLEXPRESS; Database = StudentDb; Integrated Security = true";

                SqlConnection con = new SqlConnection(connectionString);

                string query = @"SELECT *FROM StudentsInfo WHERE RegNo = '" + regNo + "';";
                con.Open();
               SqlCommand sqlCommand = new SqlCommand(query, con);



                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                string data = "";
                if(sqlDataReader.Read())
                {
                    data = sqlDataReader["ID"].ToString();
                }

                if(!string.IsNullOrEmpty(data))
                {
                    isExists = true;
                }

                else
                {
                    isExists = false;
                }


                con.Close();

                clear();
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
                //throw;
            }

            return isExists;
        }
    }
}
                                                                                                                                                    