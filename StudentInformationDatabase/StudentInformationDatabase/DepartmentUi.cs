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
    public partial class DepartmentUi : Form
    {
        public DepartmentUi()
        {
            InitializeComponent();
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            string name = deptNameTextBox.Text;
            string deptCode = deptCodeTextBox.Text;
           
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



                string query = @"INSERT INTO Department(DepartmentName, Code)VALUES('" + name + "','" + deptCode + "');";

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
            deptNameTextBox.Clear();
            deptCodeTextBox.Clear();
        }

        private void ShowButton_Click(object sender, EventArgs e)
        {
            try
            {
                string connectionString = @"Server = .\SQLEXPRESS; Database = StudentDb; Integrated Security = true";

                SqlConnection con = new SqlConnection(connectionString);

                // string query = @"INSERT INTO Students(Name, Address,ContactNo ,RegNo,DepartmentID )VALUES('" + name + "','" + address + "'," + mobile + ", '" + regNo + "', " + deptID + ")";
                string query = @"SELECT *FROM Department;";
                con.Open();
                SqlCommand sqlCommand = new SqlCommand(query, con);



                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                DataTable dataTable = new DataTable();
                sqlDataAdapter.Fill(dataTable);

                if (dataTable.Rows.Count > 0)
                {
                    deptShowDataGridView.DataSource = dataTable;
                }

                else
                {
                    deptShowDataGridView.DataSource = null;
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

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(deptIdTextBox.Text);
            try
            {
                string connectionString = @"Server = .\SQLEXPRESS; Database = StudentDb; Integrated Security = true";

                SqlConnection con = new SqlConnection(connectionString);

                // string query = @"INSERT INTO Students(Name, Address,ContactNo ,RegNo,DepartmentID )VALUES('" + name + "','" + address + "'," + mobile + ", '" + regNo + "', " + deptID + ")";
                string query = @"DELETE Department WHERE ID = " + id + ";";
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

        private void UpdateButton_Click(object sender, EventArgs e)
        {
            string name = deptNameTextBox.Text;
            string deptCode = deptCodeTextBox.Text;
           // int deptID = Convert.ToInt32(deptIdTextBox.Text);

            int id = Convert.ToInt32(deptIdTextBox.Text);
            try
            {
                string connectionString = @"Server = .\SQLEXPRESS; Database = StudentDb; Integrated Security = true";

                SqlConnection con = new SqlConnection(connectionString);

                // string query = @"INSERT INTO Students(Name, Address,ContactNo ,RegNo,DepartmentID )VALUES('" + name + "','" + address + "'," + mobile + ", '" + regNo + "', " + deptID + ")";
                string query = @"UPDATE Department SET DepartmentName = '" + name + "', Code = '" + deptCode + "' WHERE ID = "+id+"";
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
            int id = Convert.ToInt32(deptIdTextBox.Text);
            try
            {
                string connectionString = @"Server = .\SQLEXPRESS; Database = StudentDb; Integrated Security = true";

                SqlConnection con = new SqlConnection(connectionString);

                // string query = @"INSERT INTO Students(Name, Address,ContactNo ,RegNo,DepartmentID )VALUES('" + name + "','" + address + "'," + mobile + ", '" + regNo + "', " + deptID + ")";
                string query = @"SELECT *FROM Department WHERE Id = " + id + ";";
                con.Open();
                SqlCommand sqlCommand = new SqlCommand(query, con);



                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                DataTable dataTable = new DataTable();
                sqlDataAdapter.Fill(dataTable);

                if (dataTable.Rows.Count > 0)
                {
                    deptShowDataGridView.DataSource = dataTable;
                }

                else
                {
                    deptShowDataGridView.DataSource = null;
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

        private bool Exists(string name)
        {
            bool isExists = false;

            //int id = Convert.ToInt32(IdTextBox.Text);
            try
            {
                string connectionString = @"Server = .\SQLEXPRESS; Database = StudentDb; Integrated Security = true";

                SqlConnection con = new SqlConnection(connectionString);

                // string query = @"INSERT INTO Students(Name, Address,ContactNo ,RegNo,DepartmentID )VALUES('" + name + "','" + address + "'," + mobile + ", '" + regNo + "', " + deptID + ")";
                string query = @"SELECT *FROM Department WHERE DepartmentName = '" + name + "';";
                SqlCommand sqlCommand = new SqlCommand(query, con);
                con.Open();
              



                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                string data = "";
                if (sqlDataReader.Read())
                {
                    data = sqlDataReader["ID"].ToString();
                }

                if (!string.IsNullOrEmpty(data))
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
