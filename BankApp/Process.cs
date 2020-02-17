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
		private	bool		bSwitch		= false;

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
				SetDeposit(Convert.ToDecimal(dtCurrent.Rows[0]["CURRENT"]).ToString("0.##"));
			}
		}

		private void Process_FormClosing(object sender, FormClosingEventArgs e)
		{
			myQuery.CloseConnection();
		}

		private void Process_FormClosed(object sender, FormClosedEventArgs e){
			if(bSwitch){
				main.ClearInput();
				main.Show();
			}else{
				main.Exit();
			}
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
				if(bResult){
					dtCurrent.Rows[0]["CURRENT"]	= dcCurrent;
					SetDeposit(dcCurrent.ToString("0.##"));
					mtbDeposit.Text	= string.Empty;
					MessageBox.Show("Deposit Successful");
				}else{
					MessageBox.Show("Deposit Unsuccessful");
				}
			}
			catch(FormatException fex){
				MessageBox.Show("Wrong Format: " + fex.Message);
			}catch(Exception ex){
				MessageBox.Show(ex.Message);
			}
		}

		private void btTransfer_Click(object sender, EventArgs e){
			try{
				//	Check transfer user
				string	stTransAcc	= mtbTransAcc.Text.Trim();
				if(String.IsNullOrEmpty(stTransAcc)){
					MessageBox.Show("No account to transfer.");
					return;
				}
				DataTable	dtReceiver	= myQuery.CheckUser(stTransAcc);
				if(dtReceiver.Rows.Count != 1){
					MessageBox.Show("Account to transfer is not found.");
					return;
				}
				//	Check amount
				string	stTrAmount	= mtbTranAmount.Text.Trim();
				if (String.IsNullOrEmpty(stTrAmount)){
					MessageBox.Show("No money to transfer!");
					return;
				}
				decimal dcTransfer = Convert.ToDecimal(stTrAmount);
				if(dcTransfer <= 0){
					MessageBox.Show("No money to transfer!");
					return;
				}
				//	Check over amount
				decimal	dcSender	= Convert.ToDecimal(dtCurrent.Rows[0]["CURRENT"]);
				if (dcSender < dcTransfer){
					MessageBox.Show("Money is not enough!");
					return;
				}
				//	Transfer Money
				string	stIBSend	= dtUser.Rows[0]["IBAN"].ToString();
				string	stIBRecv	= dtReceiver.Rows[0]["IBAN"].ToString();
				decimal	dcCurSender	= dcSender - dcTransfer;
				DataTable	dtRecv	= myQuery.GetCurrent(stIBRecv);
				decimal	dcCurRecv	= dtRecv.Rows.Count < 1 ? 0 : Convert.ToDecimal(dtRecv.Rows[0]["CURRENT"]);
				dcCurRecv	+= dcTransfer;
				bool	bExecute	= myQuery.Transfer(stIBSend, stIBRecv, dcCurSender, dcCurRecv, dcTransfer);
				if(bExecute){
					dtCurrent.Rows[0]["CURRENT"] = dcCurSender;
					SetDeposit(dcCurSender.ToString("0.##"));
					mtbTranAmount.Text	= string.Empty;
					MessageBox.Show("Transfer Complete");
				}else{
					MessageBox.Show("Transfer Unsuccessful");
				}
			}
			catch(FormatException fex){
				MessageBox.Show("Wrong Format: " + fex.Message);
			}catch (Exception ex){
				MessageBox.Show(ex.Message);
			}
		}

		private void SetDeposit(string stDeposit){
			labelDeposit.Text = String.Format("Deposit: {0} Baht", stDeposit);
		}

		private void btSwitch_Click(object sender, EventArgs e){
			bSwitch	= true;
			Close();
		}
	}
}
