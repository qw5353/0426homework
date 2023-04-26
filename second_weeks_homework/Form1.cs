using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace second_weeks_homework
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}

		private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
		{

		}

		private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{
			
		}

		private void button1_Click(object sender, EventArgs e)
		{ 
			// 獲取所選行的數據
			DataGridViewRow row = dataGridView1.CurrentRow;

			string name = row.Cells["product_name"].Value.ToString();
				int quantity = Convert.ToInt32(row.Cells["product_count"].Value);
				int price = Convert.ToInt32(row.Cells["product_price"].Value);

				// 將數據添加到DataGridView2中
				dataGridView2.Rows.Add(name, quantity, price);
			
		}
	}
}
