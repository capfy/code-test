namespace BankApp
{
	partial class Process
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
			this.labelUserName = new System.Windows.Forms.Label();
			this.labelDeposit = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.mtbDeposit = new System.Windows.Forms.MaskedTextBox();
			this.mtbTransfer = new System.Windows.Forms.MaskedTextBox();
			this.btDeposit = new System.Windows.Forms.Button();
			this.btTransfer = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// labelUserName
			// 
			this.labelUserName.AutoSize = true;
			this.labelUserName.Location = new System.Drawing.Point(12, 22);
			this.labelUserName.Name = "labelUserName";
			this.labelUserName.Size = new System.Drawing.Size(97, 13);
			this.labelUserName.TabIndex = 0;
			this.labelUserName.Text = "Display User Name";
			// 
			// labelDeposit
			// 
			this.labelDeposit.AutoSize = true;
			this.labelDeposit.Location = new System.Drawing.Point(185, 22);
			this.labelDeposit.Name = "labelDeposit";
			this.labelDeposit.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.labelDeposit.Size = new System.Drawing.Size(80, 13);
			this.labelDeposit.TabIndex = 1;
			this.labelDeposit.Text = "Display Deposit";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 65);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(43, 13);
			this.label1.TabIndex = 2;
			this.label1.Text = "Deposit";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(12, 103);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(46, 13);
			this.label2.TabIndex = 3;
			this.label2.Text = "Transfer";
			// 
			// mtbDeposit
			// 
			this.mtbDeposit.Location = new System.Drawing.Point(68, 62);
			this.mtbDeposit.Name = "mtbDeposit";
			this.mtbDeposit.Size = new System.Drawing.Size(153, 20);
			this.mtbDeposit.TabIndex = 4;
			// 
			// mtbTransfer
			// 
			this.mtbTransfer.Location = new System.Drawing.Point(68, 100);
			this.mtbTransfer.Name = "mtbTransfer";
			this.mtbTransfer.Size = new System.Drawing.Size(153, 20);
			this.mtbTransfer.TabIndex = 5;
			// 
			// btDeposit
			// 
			this.btDeposit.Location = new System.Drawing.Point(237, 59);
			this.btDeposit.Name = "btDeposit";
			this.btDeposit.Size = new System.Drawing.Size(75, 23);
			this.btDeposit.TabIndex = 6;
			this.btDeposit.Text = "Deposit";
			this.btDeposit.UseVisualStyleBackColor = true;
			this.btDeposit.Click += new System.EventHandler(this.btDeposit_Click);
			// 
			// btTransfer
			// 
			this.btTransfer.Location = new System.Drawing.Point(237, 98);
			this.btTransfer.Name = "btTransfer";
			this.btTransfer.Size = new System.Drawing.Size(75, 23);
			this.btTransfer.TabIndex = 7;
			this.btTransfer.Text = "Transfer";
			this.btTransfer.UseVisualStyleBackColor = true;
			this.btTransfer.Click += new System.EventHandler(this.btTransfer_Click);
			// 
			// Process
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(339, 206);
			this.Controls.Add(this.btTransfer);
			this.Controls.Add(this.btDeposit);
			this.Controls.Add(this.mtbTransfer);
			this.Controls.Add(this.mtbDeposit);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.labelDeposit);
			this.Controls.Add(this.labelUserName);
			this.MaximizeBox = false;
			this.Name = "Process";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Management";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Process_FormClosing);
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Process_FormClosed);
			this.Load += new System.EventHandler(this.Process_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label labelUserName;
		private System.Windows.Forms.Label labelDeposit;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.MaskedTextBox mtbDeposit;
		private System.Windows.Forms.MaskedTextBox mtbTransfer;
		private System.Windows.Forms.Button btDeposit;
		private System.Windows.Forms.Button btTransfer;
	}
}