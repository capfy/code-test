using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace BankApp
{
	public class MySQLQuery{
		MySqlConnection sqlConn;
		MySqlCommand	sqlComm;

		/// <summary>
		/// Constructor
		/// </summary>
		public MySQLQuery(){
			CreateConnection();
		}

		private bool CreateConnection(){
			bool bResult = false;
			sqlConn = new MySqlConnection(G.mysqlConnStr);
			try{
				sqlConn.Open();
				if (sqlConn.State == ConnectionState.Open){
					//MessageBox.Show("MySQL connection is open!");
					bResult = true;
				}
			}
			catch (Exception ex){
				MessageBox.Show(ex.Message);
			}
			return bResult;
		}

		public void CloseConnection(){
			sqlConn.Close();
		}

		public string CreateUser(string stUid, string stIban, string stPass, string stFirst, string stLast){
			string	stError	= string.Empty;
			try{
				string	stCmd	= "INSERT INTO user(UID, FIRST_NAME, LAST_NAME, PASSWORD, IBAN) VALUES(@UID, @FIRST, @LAST, @PASS, @IBAN)";
				sqlComm	= new MySqlCommand(stCmd, sqlConn);
				sqlComm.Parameters.AddWithValue("@UID", stUid);
				sqlComm.Parameters.AddWithValue("@FIRST", stFirst);
				sqlComm.Parameters.AddWithValue("@LAST", stLast);
				sqlComm.Parameters.AddWithValue("@PASS", stPass);
				sqlComm.Parameters.AddWithValue("@IBAN", stIban);
				sqlComm.ExecuteNonQuery();
			}catch(Exception ex){
				stError	= ex.Message;
			}
			return stError;
		}

	}
}
