﻿using System;
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
		MySqlConnection		myConn;
		MySqlCommand		myComm;
		MySqlDataAdapter	myAdapter;

		/// <summary>
		/// Constructor
		/// </summary>
		public MySQLQuery(){
			CreateConnection();
		}

		private bool CreateConnection(){
			bool bResult = false;
			myConn = new MySqlConnection(G.mysqlConnStr);
			try{
				myConn.Open();
				if (myConn.State == ConnectionState.Open){
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
			myConn.Close(); 
			if (myComm != null) myComm.Dispose();
			if (myAdapter != null) myAdapter.Dispose();
		}

		public string CreateUser(string stUid, string stIban, string stPass, string stFirst, string stLast){
			string	stError	= string.Empty;
			try{
				string	stCmd	= "INSERT INTO user(UID, FIRST_NAME, LAST_NAME, PASSWORD, IBAN) VALUES(@UID, @FIRST, @LAST, @PASS, @IBAN)";
				myComm	= new MySqlCommand(stCmd, myConn);
				myComm.Parameters.AddWithValue("@UID", stUid);
				myComm.Parameters.AddWithValue("@FIRST", stFirst);
				myComm.Parameters.AddWithValue("@LAST", stLast);
				myComm.Parameters.AddWithValue("@PASS", stPass);
				myComm.Parameters.AddWithValue("@IBAN", stIban);
				myComm.ExecuteNonQuery();
			}catch(Exception ex){
				stError	= ex.Message;
			}
			return stError;
		}

		public DataTable Login(string stUid, string stPass){
			DataTable	dtRes	= new DataTable();
			try{
				string	stCmd	= "SELECT * FROM user WHERE UID = @UID AND PASSWORD = @PASS";
				myComm = new MySqlCommand(stCmd, myConn);
				myComm.Parameters.AddWithValue("@UID", stUid);
				myComm.Parameters.AddWithValue("@PASS", stPass);
				myAdapter	= new MySqlDataAdapter(myComm);
				myAdapter.Fill(dtRes);
			}
			catch(Exception){
			}
			return dtRes;
		}

		public DataTable GetCurrent(string stIBAN){
			DataTable dtRes = new DataTable();
			try{
				string stCmd = "SELECT * FROM operation WHERE IBAN = @IBAN AND CANCEL_FLAG = 'F'";
				myComm = new MySqlCommand(stCmd, myConn);
				myComm.Parameters.AddWithValue("@IBAN", stIBAN);
				myAdapter = new MySqlDataAdapter(myComm);
				myAdapter.Fill(dtRes);
			} catch (Exception){
			}
			return dtRes;
		}

		public bool Deposit(string stIBAN, decimal dcDeposit, decimal dcCurrent){
			bool	bResult	= false;
			MySqlTransaction myTrans = null;
			try{
				myTrans	= myConn.BeginTransaction();
				//	Set CANCEL_FLAG
				string	stCmd	= "UPDATE operation SET CANCEL_FLAG = 'T' WHERE IBAN = @IBAN";
				myComm = new MySqlCommand(stCmd, myConn);
				myComm.Parameters.AddWithValue("@IBAN", stIBAN);
				myComm.ExecuteNonQuery();
				myComm.Dispose();
				//	Insert new operation
				stCmd	= "INSERT INTO operation(IBAN, DEPOSIT, CURRENT, CANCEL_FLAG, ACT_TIME) VALUES(@IBAN, @DEPOSIT, @CURRENT, 'F', NOW())";
				myComm = new MySqlCommand(stCmd, myConn);
				myComm.Parameters.AddWithValue("@IBAN", stIBAN);
				myComm.Parameters.AddWithValue("@DEPOSIT", dcDeposit);
				myComm.Parameters.AddWithValue("@CURRENT", dcCurrent);
				myComm.ExecuteNonQuery();
				myTrans.Commit();
				bResult	= true;
			} catch (Exception ex){
				if(myTrans != null) myTrans.Rollback();
			}
			return bResult;
		}

	}
}
