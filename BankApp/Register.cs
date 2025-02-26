﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Jint;

namespace BankApp
{
	public partial class Register : Form
	{

		public bool	bClose	= false;
		private	MySQLQuery	myQuery;

		public Register()
		{
			InitializeComponent();
		}

		private void Register_Load(object sender, EventArgs e){
			myQuery	= new MySQLQuery();
		}

		private void btOk_Click(object sender, EventArgs e)
		{
			string	stUid	= tbUserID.Text.Trim();
			string	stPass1	= tbPassword.Text.Trim();
			string	stPass2	= tbPassword2.Text.Trim();
			string	stFirst	= tbFirstName.Text.Trim();
			string	stLast	= tbLastName.Text.Trim();
			do{
				if (String.IsNullOrEmpty(stUid) || String.IsNullOrEmpty(stPass1) || String.IsNullOrEmpty(stFirst) || String.IsNullOrEmpty(stLast)){
					MessageBox.Show("Please fill all data.");
					break;
				}
				if (stUid.Length > 10){
					MessageBox.Show("User ID cannot over 10 character!");
					break;
				}
				if (stPass1.Length > 10 || stPass2.Length > 10){
					MessageBox.Show("Password cannot over 10 character!");
					break;
				}
				if(!stPass1.Equals(stPass2)){
					MessageBox.Show("Password mismatch!");
					break;
				}
				//	Generate IBAN ID
				//	http://randomiban.com/static/mapp4.js
				//	Method: buildIbans
				string	url1	= "https://cdn.jsdelivr.net/lodash/4.17.4/lodash.min.js";
				string	url2	= "http://randomiban.com/static/mapp4.js";
				string	stIBAN	= string.Empty;
				try{
					using (System.Net.WebClient wc1 = new WebClient())
					{
						string stData1 = wc1.DownloadString(url1);
						using (WebClient wc2 = new WebClient())
						{
							string stData2 = wc2.DownloadString(url2);
							Engine engine = new Engine();
							engine.Execute(stData1);
							engine.Execute(stData2);
							stIBAN	= engine.GetValue("buildIbans").Invoke("Netherlands").ToString();
						}
					}
				}catch(Exception){
					break;
				}
				if(String.IsNullOrEmpty(stIBAN)){
					MessageBox.Show("Can not create IBAN Id!");
					break;
				}
				//	Save user data to database
				if (!String.IsNullOrEmpty(
					myQuery.CreateUser(stUid, stIBAN, stPass1, stFirst, stLast)
				)){
					MessageBox.Show("Can not register new user!");
					break;
				}
				//	Show message
				MessageBox.Show("Register successfully");
				bClose	= true;
			} while(false);
		}

		private void btCancel_Click(object sender, EventArgs e)
		{
			bClose	= true;
			Close();
		}

		private void Register_FormClosing(object sender, FormClosingEventArgs e)
		{
			if(!bClose){
				e.Cancel = true;
				myQuery.CloseConnection();
			}
		}

		private void Register_FormClosed(object sender, FormClosedEventArgs e)
		{

		}
	}
}
