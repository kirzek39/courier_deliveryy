using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace airoport
{
    public partial class Form6 : Form
    {
        DataSet ds;
        MySqlDataAdapter adapter;
        string connectionString = @"Data Source=DESKTOP-K6HD04V; Initial Catalog=courier_deliveryy;";
        string sql = "SELECT * FROM year_statistics";
        public Form6()
        {
            InitializeComponent();
            getInfo();
        }
        public void getInfo()
        {
            try
            {
                MySqlConnection cnn = DBUtils.GetDBConnection();
                MySqlDataAdapter ada = new MySqlDataAdapter("select * from year_statistics;", cnn);
                DataTable dt = new DataTable();
                cnn.Open();
                ada.Fill(dt);
                dataGridView1.DataSource = dt;
                cnn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form1 Win =
                new Form1();
            Win.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("Уверены, что хотите удалить?", "Вы уверены?", MessageBoxButtons.YesNo);
            if (res == DialogResult.Yes)
            {
                string del = "delete from salary where id_salary = " + dataGridView1[0, dataGridView1.CurrentRow.Index].Value.ToString() + ";";
                MySqlConnection conn = DBUtils.GetDBConnection();
                MySqlCommand cmDB = new MySqlCommand(del, conn);
                try
                {
                    conn.Open();
                    cmDB.ExecuteReader();
                    conn.Close();
                    MessageBox.Show("данные удалены");
                    getInfo();

                }
                catch (Exception)
                {
                    MessageBox.Show("Возникла непредвиденная ошибка.");
                }
            }
        }

        private void Form6_Load(object sender, EventArgs e)
        {

        }
    }
}
