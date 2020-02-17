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
	public partial class Process : Form{
		private	FormMain	main;
		private	DataTable	dtUser		= new DataTable();
		private	DataTable	dtCurrent	= new DataTable();
		private	MySQLQuery	myQuery;

		public Process(FormMain main, DataTable dtUser){
			InitializeComponent();
			this.main	= main;
			this.dtUser	= dtUser;
		}

		private void Process_Load(object sender, EventArgs e){
			labelUserName.Text	= dtUser.Rows[0]["FIRST_NAME"].ToString() + " " + dtUser.Rows[0]["LAST_NAME"].ToString();
			myQuery		= new MySQLQuery();
			dtCurrent	= myQuery.GetCurrent(dtUser.Rows[0]["IBAN"].ToString());
			if(dtCurrent.Rows.Count < 1){
				SetDeposit("0");
			}
			else{
				SetDeposit(dtCurrent.Rows[0]["CURRENT"].ToString());
			}
		}

		private void Process_FormClosing(object sender, FormClosingEventArgs e)
		{
			myQuery.CloseConnection();
		}

		private void Process_FormClosed(object sender, FormClosedEventArgs e)
		{
			main.Exit();
		}

		private void btDeposit_Click(object sender, EventArgs e){
			try{
				decimal	dcDeposit	= Convert.ToDecimal(mtbDeposit.Text.Trim());
				if(dcDeposit <= 0){
					MessageBox.Show("No money!");
					return;
				}
				decimal	dcCurrent	= dtCurrent.Rows.Count < 1 ? 0 : Convert.ToDecimal(dtCurrent.Rows[0]["CURRENT"]);
				dcCurrent	+= dcDeposit - (dcDeposit * (decimal)0.1 / 100);
				bool	bResult	= myQuery.Deposit(dtUser.Rows[0]["IBAN"].ToString(), dcDeposit, dcCurrent);

			}
			catch(FormatException fex){
				MessageBox.Show("Wrong Format: " + fex.Message);
			}catch(Exception ex){
				MessageBox.Show(ex.Message);
			}
		}

		private void btTransfer_Click(object sender, EventArgs e)
		{

		}

		private void SetDeposit(string stDeposit){
			labelDeposit.Text = String.Format("Deposit: {0} Baht", stDeposit);
		}
	}
}
