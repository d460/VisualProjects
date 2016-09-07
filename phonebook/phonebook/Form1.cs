using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;

namespace phonebook
{
    public partial class Form1 : Form
    {
        SQLiteConnection myConnection = new SQLiteConnection(@"Data Source = C:\Users\Dagoberto\Documents\Visual Studio 2015\Projects\phonebook\phonebook.db");
        public int mode = 1;  //  1 = Insert , 2 = Update


        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (mode == 1)
                insertData();
            else if (mode == 2)
                updateData();
        }

        private void insertData()
        {
            myConnection.Open();
            SQLiteCommand myCommand = new SQLiteCommand(myConnection);
            myCommand.CommandText = "Insert Into persons (firstName,lastNAme,email,Address,homePhone,workPhone,mobilePhone) values('" + txtfirstName.Text + "','" + txtlastName.Text + "','" + txtEmail.Text + "','" + txtAddres.Text + "','" + txtHomePhone.Text + "','" + txtWorkPhone.Text + "','" + txtMobilePhone.Text + "')";
            myCommand.ExecuteNonQuery();
            myConnection.Close();
            readData();
            MessageBox.Show("Your data is saved!");
            clear();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            readData();
        }

        private void readData()
        {
            myConnection.Open();
            SQLiteCommand myCommand = new SQLiteCommand(myConnection);
            var datatable = new DataTable();
            string commandText = "select * from persons";
            SQLiteDataAdapter mydataAdapter = new SQLiteDataAdapter(commandText, myConnection);
            mydataAdapter.Fill(datatable);
            myConnection.Close();
            dataGridView1.DataSource = datatable;
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string selectedPersonsID = dataGridView1.CurrentRow.Cells["id"].Value.ToString();
            myConnection.Open();
            SQLiteCommand myCommand = new SQLiteCommand(myConnection);
            myCommand.CommandText = "delete from persons where id =" + selectedPersonsID;
            myCommand.ExecuteNonQuery();
            myConnection.Close();
            readData();
            MessageBox.Show("Your selected date is Deleted!!");
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mode = 2;
            string selectedPersonID = dataGridView1.CurrentRow.Cells["id"].Value.ToString();
            var dataTable = new DataTable();
            myConnection.Open();
            string commandText = "Select * from persons where id = " + selectedPersonID;
            SQLiteDataAdapter myAdapter = new SQLiteDataAdapter(commandText, myConnection);
            myAdapter.Fill(dataTable);
            myConnection.Close();

            txtID.Text = dataTable.Rows[0]["id"].ToString();
            txtfirstName.Text = dataTable.Rows[0]["firstName"].ToString();
            txtlastName.Text = dataTable.Rows[0]["lastNAme"].ToString();
            txtEmail.Text = dataTable.Rows[0]["Address"].ToString();
            txtAddres.Text = dataTable.Rows[0]["email"].ToString();
            txtHomePhone.Text = dataTable.Rows[0]["homePhone"].ToString();
            txtWorkPhone.Text = dataTable.Rows[0]["workPhone"].ToString();
            txtMobilePhone.Text = dataTable.Rows[0]["mobilePhone"].ToString();
        }

        private void updateData()
        {
            myConnection.Open();
            SQLiteCommand myCommand = new SQLiteCommand(myConnection);
            myCommand.CommandText = "update persons set firstName = '" + txtfirstName.Text + "', lastNAme = '" + txtlastName.Text + "',"
              + "  email = '" + txtEmail.Text + "', Address = '" + txtAddres.Text + "', homePhone = '" + txtHomePhone.Text + "', "
              + " workPhone = '" + txtWorkPhone.Text + "', mobilePhone = '" + txtMobilePhone.Text + "' where id = " + txtID.Text;
            myCommand.ExecuteNonQuery();
            myConnection.Close();
            readData();
            MessageBox.Show("Your data is Update!");
            clear();
            
        }

        private void txtMobilePhone_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            mode = 1;
            clear();

        }

        private void clear()
        {

            txtfirstName.Text = "";
            txtlastName.Text = "";
            txtEmail.Text = "";
            txtAddres.Text = "";
            txtHomePhone.Text = "";
            txtWorkPhone.Text = "";
            txtMobilePhone.Text = "";
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            mode = 1;
            clear();
        }
    }
}
