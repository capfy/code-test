using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace BankApp
{
	public partial class FormMain : Form{

		public FormMain()
		{
			InitializeComponent();
		}

		private void FormMain_Load(object sender, EventArgs e)
		{
			
		}



		private void btRegister_Click(object sender, EventArgs e)
		{
			Register	register = new Register();
			register.ShowDialog();
		}

		private void btLogin_Click(object sender, EventArgs e)
		{

		}
	}
}
