using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace StudentInformationDatabase
{
    public partial class CourseUi : Form
    {
        public CourseUi()
        {
            InitializeComponent();
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(courseIdTextBox.Text);
            try
            {
                string connectionString = @"Server = .\SQLEXPRESS; Database = StudentDb; Integrated Security = true";

                SqlConnection con = new SqlConnection(connectionString);

                // string query = @"INSERT INTO Students(Name, Address,ContactNo ,RegNo,DepartmentID )VALUES('" + name + "','" + address + "'," + mobile + ", '" + regNo + "', " + deptID + ")";
                string query = @"DELETE Courses WHERE ID = " + id + ";";
                con.Open();
                SqlCommand sqlCommand = new SqlCommand(query, con);



                //SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                //DataTable dataTable = new DataTable();
                //sqlDataAdapter.Fill(dataTable);


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

        private void SaveButton_Click(object sender, EventArgs e)
        {
             string name = courseNameTextBox.Text;
            string courseCode = courseCodeTextBox.Text;
           
           // int deptID = Convert.ToInt32(deptIdTextBox.Text);

            if (Exists(name))
            {
                MessageBox.Show("Exist");
                return;
            }

            try
            {
                string connectionString = @"Server = .\SQLEXPRESS; Database = StudentDb; Integrated Security = true";

                SqlConnection con = new SqlConnection(connectionString);



                string query = @"INSERT INTO Courses(CourseName, CourseCode )VALUES('" + name + "','" + courseCode + "')";

                SqlCommand sqlCommand = new SqlCommand(query, con);

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
            courseNameTextBox.Clear();
            courseCodeTextBox.Clear();
        }

        private void ShowButton_Click(object sender, EventArgs e)
        {
            try
            {
                string connectionString = @"Server = .\SQLEXPRESS; Database = StudentDb; Integrated Security = true";

                SqlConnection con = new SqlConnection(connectionString);

                // string query = @"INSERT INTO Students(Name, Address,ContactNo ,RegNo,DepartmentID )VALUES('" + name + "','" + address + "'," + mobile + ", '" + regNo + "', " + deptID + ")";
                string query = @"SELECT *FROM Courses;";
                con.Open();
                SqlCommand sqlCommand = new SqlCommand(query, con);



                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                DataTable dataTable = new DataTable();
                sqlDataAdapter.Fill(dataTable);

                if (dataTable.Rows.Count > 0)
                {
                    courseShowDataGridView.DataSource = dataTable;
                }

                else
                {
                    courseShowDataGridView.DataSource = null;
                }

                //int isExecuted = sqlCommand.ExecuteNonQuery();

                //if (isExecuted > 0)
                //{
                //    MessageBox.Show("Saved");

                //}
                //else
                //{
                //    MessageBox.Show("Not saved");
                //}

                //con.Close();

                // clear();
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
                //throw;
            }
        }

        private void UpdateButton_Click(object sender, EventArgs e)
        {
            string name = courseNameTextBox.Text;
            string courseCode = courseCodeTextBox.Text;
            // int deptID = Convert.ToInt32(deptIdTextBox.Text);

            int id = Convert.ToInt32(courseIdTextBox.Text);
            try
            {
                string connectionString = @"Server = .\SQLEXPRESS; Database = StudentDb; Integrated Security = true";

                SqlConnection con = new SqlConnection(connectionString);

                // string query = @"INSERT INTO Students(Name, Address,ContactNo ,RegNo,DepartmentID )VALUES('" + name + "','" + address + "'," + mobile + ", '" + regNo + "', " + deptID + ")";
                string query = @"UPDATE Courses SET CourseName = '" + name + "', CourseCode = '" + courseCode + "' WHERE ID = " + id + "";
                con.Open();
                SqlCommand sqlCommand = new SqlCommand(query, con);



                //SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                //DataTable dataTable = new DataTable();
                //sqlDataAdapter.Fill(dataTable);


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
            int id = Convert.ToInt32(courseIdTextBox.Text);
            try
            {
                string connectionString = @"Server = .\SQLEXPRESS; Database = StudentDb; Integrated Security = true";

                SqlConnection con = new SqlConnection(connectionString);

                // string query = @"INSERT INTO Students(Name, Address,ContactNo ,RegNo,DepartmentID )VALUES('" + name + "','" + address + "'," + mobile + ", '" + regNo + "', " + deptID + ")";
                string query = @"SELECT *FROM Courses WHERE Id = " + id + ";";
                con.Open();
                SqlCommand sqlCommand = new SqlCommand(query, con);



                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                DataTable dataTable = new DataTable();
                sqlDataAdapter.Fill(dataTable);

                if (dataTable.Rows.Count > 0)
                {
                    courseShowDataGridView.DataSource = dataTable;
                }

                else
                {
                    courseShowDataGridView.DataSource = null;
                }

                //int isExecuted = sqlCommand.ExecuteNonQuery();

                //if (isExecuted > 0)
                //{
                //    MessageBox.Show("Saved");

                //}
                //else
                //{
                //    MessageBox.Show("Not saved");
                //}

                con.Close();

                clear();
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
                //throw;
            }
        }

        //private bool Exists(string name)
        //{
        //    bool isExists = false;

        //    //int id = Convert.ToInt32(IdTextBox.Text);
        //    try
        //    {
        //        string connectionString = @"Server = .\SQLEXPRESS; Database = StudentDb; Integrated Security = true";

        //        SqlConnection con = new SqlConnection(connectionString);

        //        // string query = @"INSERT INTO Students(Name, Address,ContactNo ,RegNo,DepartmentID )VALUES('" + name + "','" + address + "'," + mobile + ", '" + regNo + "', " + deptID + ")";
        //        string query = @"SELECT *FROM StudentsInfo WHERE CourseName = '" + name + "';";

        //        SqlCommand sqlCommand = new SqlCommand(query, con);
        //        con.Open();
               
        //        SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
        //        string data = "";
        //        if (sqlDataReader.Read())
        //        {
        //            data = sqlDataReader["CourseName"].ToString();
        //        }

        //        if (!string.IsNullOrEmpty(data))
        //        {
        //            isExists = true;
        //        }

        //        else
        //        {
        //            isExists = false;
        //        }


        //        con.Close();

        //        clear();
        //    }
        //    catch (Exception error)
        //    {
        //        MessageBox.Show(error.Message);
        //        //throw;
        //    }

        //    return isExists;
        //}



        private bool Exists(string name)
        {

            bool isExists = false;

            try
            {

                //2
                string connectionString = @"Server = .\SQLEXPRESS; Database = StudentDb; Integrated Security = true";
                //3
                SqlConnection sqlConnection = new SqlConnection(connectionString);

                //4
                string query = @"SELECT * FROM StudentsInfo WHERE CourseName = '" + name + "'";

                //5
                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                //6
                sqlConnection.Open();
                //7
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

                string data = "";
                if (sqlDataReader.Read())
                {
                    data = sqlDataReader["ID"].ToString();
                }

                if (!String.IsNullOrEmpty(data))
                {
                    isExists = true;
                }
                else
                {
                    isExists = false;
                }


                sqlConnection.Close();


            }
            catch (Exception exception)
            {

                MessageBox.Show(exception.Message);
            }

            return isExists;
        }


    }
}
