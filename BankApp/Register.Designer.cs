namespace BankApp
{
	partial class Register
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.tbUserID = new System.Windows.Forms.TextBox();
			this.tbPassword = new System.Windows.Forms.TextBox();
			this.tbPassword2 = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.btOk = new System.Windows.Forms.Button();
			this.btCancel = new System.Windows.Forms.Button();
			this.label4 = new System.Windows.Forms.Label();
			this.tbLastName = new System.Windows.Forms.TextBox();
			this.tbFirstName = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(32, 21);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(43, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "User ID";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(32, 55);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(53, 13);
			this.label2.TabIndex = 1;
			this.label2.Text = "Password";
			// 
			// tbUserID
			// 
			this.tbUserID.Location = new System.Drawing.Point(114, 18);
			this.tbUserID.Name = "tbUserID";
			this.tbUserID.Size = new System.Drawing.Size(153, 20);
			this.tbUserID.TabIndex = 2;
			// 
			// tbPassword
			// 
			this.tbPassword.Location = new System.Drawing.Point(114, 55);
			this.tbPassword.Name = "tbPassword";
			this.tbPassword.PasswordChar = '*';
			this.tbPassword.Size = new System.Drawing.Size(153, 20);
			this.tbPassword.TabIndex = 3;
			// 
			// tbPassword2
			// 
			this.tbPassword2.Location = new System.Drawing.Point(114, 89);
			this.tbPassword2.Name = "tbPassword2";
			this.tbPassword2.PasswordChar = '*';
			this.tbPassword2.Size = new System.Drawing.Size(153, 20);
			this.tbPassword2.TabIndex = 4;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(32, 92);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(70, 13);
			this.label3.TabIndex = 5;
			this.label3.Text = "Re-Password";
			// 
			// btOk
			// 
			this.btOk.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.btOk.Location = new System.Drawing.Point(35, 220);
			this.btOk.Name = "btOk";
			this.btOk.Size = new System.Drawing.Size(84, 28);
			this.btOk.TabIndex = 6;
			this.btOk.Text = "OK";
			this.btOk.UseVisualStyleBackColor = true;
			this.btOk.Click += new System.EventHandler(this.btOk_Click);
			// 
			// btCancel
			// 
			this.btCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btCancel.Location = new System.Drawing.Point(183, 220);
			this.btCancel.Name = "btCancel";
			this.btCancel.Size = new System.Drawing.Size(84, 28);
			this.btCancel.TabIndex = 7;
			this.btCancel.Text = "Cancel";
			this.btCancel.UseVisualStyleBackColor = true;
			this.btCancel.Click += new System.EventHandler(this.btCancel_Click);
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(32, 161);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(58, 13);
			this.label4.TabIndex = 11;
			this.label4.Text = "Last Name";
			// 
			// tbLastName
			// 
			this.tbLastName.Location = new System.Drawing.Point(114, 158);
			this.tbLastName.Name = "tbLastName";
			this.tbLastName.Size = new System.Drawing.Size(153, 20);
			this.tbLastName.TabIndex = 10;
			// 
			// tbFirstName
			// 
			this.tbFirstName.Location = new System.Drawing.Point(114, 125);
			this.tbFirstName.Name = "tbFirstName";
			this.tbFirstName.Size = new System.Drawing.Size(153, 20);
			this.tbFirstName.TabIndex = 9;
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(32, 128);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(57, 13);
			this.label5.TabIndex = 8;
			this.label5.Text = "First Name";
			// 
			// Register
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(306, 260);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.tbLastName);
			this.Controls.Add(this.tbFirstName);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.btCancel);
			this.Controls.Add(this.btOk);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.tbPassword2);
			this.Controls.Add(this.tbPassword);
			this.Controls.Add(this.tbUserID);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.MaximizeBox = false;
			this.Name = "Register";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Register";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Register_FormClosing);
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Register_FormClosed);
			this.Load += new System.EventHandler(this.Register_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox tbUserID;
		private System.Windows.Forms.TextBox tbPassword;
		private System.Windows.Forms.TextBox tbPassword2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Button btOk;
		private System.Windows.Forms.Button btCancel;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox tbLastName;
		private System.Windows.Forms.TextBox tbFirstName;
		private System.Windows.Forms.Label label5;
	}
}