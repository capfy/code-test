using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BankApp
{
	public partial class FormMain : Form{
		private MySQLQuery myQuery;

		public FormMain()
		{
			InitializeComponent();
		}

		private void FormMain_Load(object sender, EventArgs e){
			myQuery = new MySQLQuery();
		}

		private void btRegister_Click(object sender, EventArgs e){
			Register	register = new Register();
			register.ShowDialog();
		}

		private void btLogin_Click(object sender, EventArgs e){
			string	stUser	= tbUser.Text.Trim();
			string	stPass	= tbPassword.Text.Trim();
			if(String.IsNullOrEmpty(stUser) || String.IsNullOrEmpty(stPass)){
				MessageBox.Show("User ID or Password cannot empty!");
				return;
			}
			DataTable	dtUser	= myQuery.Login(stUser, stPass);
			Process		process	= new Process(this, dtUser);
			process.Show();
			this.Hide();
		}

		private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
		{
			myQuery.CloseConnection();
		}

		private void FormMain_FormClosed(object sender, FormClosedEventArgs e)
		{

		}

		public void Exit(){
			Close();
		}
	}
}
