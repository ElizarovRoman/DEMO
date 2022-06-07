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
using static sport.SQLzap;

namespace sport
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void userBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.userBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.tradeDataSet);

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "tradeDataSet.User". При необходимости она может быть перемещена или удалена.
            this.userTableAdapter.Fill(this.tradeDataSet.User);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.userBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.tradeDataSet);
        }

        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {
            this.userTableAdapter.Fill(this.tradeDataSet.User);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            DataTable dataTable = new DataTable("dataBase");
            string connectionString = "Server=.\\SQLEXPRESS; Trusted_Connection=Yes; Database=Trade";
            SqlConnection sqlconn = new SqlConnection(connectionString);
            sqlconn.Open();
            SqlCommand sqlcomand = sqlconn.CreateCommand();
            sqlcomand.CommandText = "Select * FROM [User] WHERE [UserName] = '" + textBox1.Text + "'";
            SqlDataAdapter sqlAdapter = new SqlDataAdapter(sqlcomand);
            sqlAdapter.Fill(dataTable);
            userDataGridView.DataSource = dataTable;
            /// SQLzap sql = new SQLzap();
            //DataTable users = new DataTable();
            //users = sql.SQLBase("Select * FROM [User] WHERE * = '" + textBox1.Text + "'");
            // this.userTableAdapter.Fill(users);
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {

        }

        private void userDataGridView_MouseEnter(object sender, EventArgs e)
        {
           
            this.userTableAdapter.Fill(this.tradeDataSet.User);
        }
    }
}
