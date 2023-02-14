namespace CS3280WinEmployee
{
    partial class EmployeeForm
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
            this.components = new System.ComponentModel.Container();
            this.txtFirstName = new System.Windows.Forms.TextBox();
            this.lblFirstName = new System.Windows.Forms.Label();
            this.lblLastName = new System.Windows.Forms.Label();
            this.txtLastname = new System.Windows.Forms.TextBox();
            this.lblSSN = new System.Windows.Forms.Label();
            this.txtSSN = new System.Windows.Forms.TextBox();
            this.lblAddress1 = new System.Windows.Forms.Label();
            this.txtAddress1 = new System.Windows.Forms.TextBox();
            this.lblAddress2 = new System.Windows.Forms.Label();
            this.txtAddress2 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbState = new System.Windows.Forms.ComboBox();
            this.chkMarried = new System.Windows.Forms.CheckBox();
            this.radioSalaried = new System.Windows.Forms.RadioButton();
            this.radioCommision = new System.Windows.Forms.RadioButton();
            this.radioBaseComission = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtSalary = new System.Windows.Forms.TextBox();
            this.lblSalary = new System.Windows.Forms.Label();
            this.lblCommission = new System.Windows.Forms.Label();
            this.txtComission = new System.Windows.Forms.TextBox();
            this.lblSales = new System.Windows.Forms.Label();
            this.txtSales = new System.Windows.Forms.TextBox();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.txtZip = new System.Windows.Forms.TextBox();
            this.cmbDept = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dgEmployee = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.dtpBirthDate = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dtpJoinedDate = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.epSSN = new System.Windows.Forms.ErrorProvider(this.components);
            this.epDateOfBirth = new System.Windows.Forms.ErrorProvider(this.components);
            this.epDateJoined = new System.Windows.Forms.ErrorProvider(this.components);
            this.epFName = new System.Windows.Forms.ErrorProvider(this.components);
            this.epLName = new System.Windows.Forms.ErrorProvider(this.components);
            this.epZip = new System.Windows.Forms.ErrorProvider(this.components);
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgEmployee)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.epSSN)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.epDateOfBirth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.epDateJoined)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.epFName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.epLName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.epZip)).BeginInit();
            this.SuspendLayout();
            // 
            // txtFirstName
            // 
            this.txtFirstName.Location = new System.Drawing.Point(307, 55);
            this.txtFirstName.Margin = new System.Windows.Forms.Padding(2);
            this.txtFirstName.Name = "txtFirstName";
            this.txtFirstName.Size = new System.Drawing.Size(135, 20);
            this.txtFirstName.TabIndex = 1;
            // 
            // lblFirstName
            // 
            this.lblFirstName.AutoSize = true;
            this.lblFirstName.Location = new System.Drawing.Point(203, 58);
            this.lblFirstName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblFirstName.Name = "lblFirstName";
            this.lblFirstName.Size = new System.Drawing.Size(57, 13);
            this.lblFirstName.TabIndex = 1;
            this.lblFirstName.Text = "First Name";
            // 
            // lblLastName
            // 
            this.lblLastName.AutoSize = true;
            this.lblLastName.Location = new System.Drawing.Point(203, 90);
            this.lblLastName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblLastName.Name = "lblLastName";
            this.lblLastName.Size = new System.Drawing.Size(58, 13);
            this.lblLastName.TabIndex = 3;
            this.lblLastName.Text = "Last Name";
            // 
            // txtLastname
            // 
            this.txtLastname.Location = new System.Drawing.Point(307, 86);
            this.txtLastname.Margin = new System.Windows.Forms.Padding(2);
            this.txtLastname.Name = "txtLastname";
            this.txtLastname.Size = new System.Drawing.Size(135, 20);
            this.txtLastname.TabIndex = 2;
            // 
            // lblSSN
            // 
            this.lblSSN.AutoSize = true;
            this.lblSSN.Location = new System.Drawing.Point(203, 121);
            this.lblSSN.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblSSN.Name = "lblSSN";
            this.lblSSN.Size = new System.Drawing.Size(29, 13);
            this.lblSSN.TabIndex = 5;
            this.lblSSN.Text = "SSN";
            this.lblSSN.Click += new System.EventHandler(this.label1_Click);
            // 
            // txtSSN
            // 
            this.txtSSN.Location = new System.Drawing.Point(307, 117);
            this.txtSSN.Margin = new System.Windows.Forms.Padding(2);
            this.txtSSN.Name = "txtSSN";
            this.txtSSN.Size = new System.Drawing.Size(135, 20);
            this.txtSSN.TabIndex = 4;
            this.txtSSN.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // lblAddress1
            // 
            this.lblAddress1.AutoSize = true;
            this.lblAddress1.Location = new System.Drawing.Point(203, 153);
            this.lblAddress1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblAddress1.Name = "lblAddress1";
            this.lblAddress1.Size = new System.Drawing.Size(77, 13);
            this.lblAddress1.TabIndex = 7;
            this.lblAddress1.Text = "Address Line 1";
            // 
            // txtAddress1
            // 
            this.txtAddress1.Location = new System.Drawing.Point(307, 149);
            this.txtAddress1.Margin = new System.Windows.Forms.Padding(2);
            this.txtAddress1.Name = "txtAddress1";
            this.txtAddress1.Size = new System.Drawing.Size(135, 20);
            this.txtAddress1.TabIndex = 6;
            // 
            // lblAddress2
            // 
            this.lblAddress2.AutoSize = true;
            this.lblAddress2.Location = new System.Drawing.Point(203, 185);
            this.lblAddress2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblAddress2.Name = "lblAddress2";
            this.lblAddress2.Size = new System.Drawing.Size(77, 13);
            this.lblAddress2.TabIndex = 9;
            this.lblAddress2.Text = "Address Line 2";
            // 
            // txtAddress2
            // 
            this.txtAddress2.Location = new System.Drawing.Point(307, 181);
            this.txtAddress2.Margin = new System.Windows.Forms.Padding(2);
            this.txtAddress2.Name = "txtAddress2";
            this.txtAddress2.Size = new System.Drawing.Size(135, 20);
            this.txtAddress2.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(203, 296);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "State";
            // 
            // cmbState
            // 
            this.cmbState.FormattingEnabled = true;
            this.cmbState.Items.AddRange(new object[] {
            "UT",
            "CA",
            "NV",
            "OR",
            "WA",
            "CO",
            "NY"});
            this.cmbState.Location = new System.Drawing.Point(307, 290);
            this.cmbState.Margin = new System.Windows.Forms.Padding(2);
            this.cmbState.Name = "cmbState";
            this.cmbState.Size = new System.Drawing.Size(82, 21);
            this.cmbState.TabIndex = 11;
            this.cmbState.SelectedIndexChanged += new System.EventHandler(this.cmbState_SelectedIndexChanged);
            // 
            // chkMarried
            // 
            this.chkMarried.AutoSize = true;
            this.chkMarried.Location = new System.Drawing.Point(206, 334);
            this.chkMarried.Margin = new System.Windows.Forms.Padding(2);
            this.chkMarried.Name = "chkMarried";
            this.chkMarried.Size = new System.Drawing.Size(136, 17);
            this.chkMarried.TabIndex = 13;
            this.chkMarried.Text = "Is Married (For taxation)";
            this.chkMarried.UseVisualStyleBackColor = true;
            this.chkMarried.CheckedChanged += new System.EventHandler(this.chkMarried_CheckedChanged);
            // 
            // radioSalaried
            // 
            this.radioSalaried.AutoSize = true;
            this.radioSalaried.Location = new System.Drawing.Point(17, 29);
            this.radioSalaried.Margin = new System.Windows.Forms.Padding(2);
            this.radioSalaried.Name = "radioSalaried";
            this.radioSalaried.Size = new System.Drawing.Size(63, 17);
            this.radioSalaried.TabIndex = 14;
            this.radioSalaried.TabStop = true;
            this.radioSalaried.Text = "Salaried";
            this.radioSalaried.UseVisualStyleBackColor = true;
            this.radioSalaried.CheckedChanged += new System.EventHandler(this.radioSalaried_CheckedChanged);
            // 
            // radioCommision
            // 
            this.radioCommision.AutoSize = true;
            this.radioCommision.Location = new System.Drawing.Point(109, 29);
            this.radioCommision.Margin = new System.Windows.Forms.Padding(2);
            this.radioCommision.Name = "radioCommision";
            this.radioCommision.Size = new System.Drawing.Size(80, 17);
            this.radioCommision.TabIndex = 14;
            this.radioCommision.TabStop = true;
            this.radioCommision.Text = "Commission";
            this.radioCommision.UseVisualStyleBackColor = true;
            this.radioCommision.CheckedChanged += new System.EventHandler(this.radioCommision_CheckedChanged);
            // 
            // radioBaseComission
            // 
            this.radioBaseComission.AutoSize = true;
            this.radioBaseComission.Location = new System.Drawing.Point(216, 29);
            this.radioBaseComission.Margin = new System.Windows.Forms.Padding(2);
            this.radioBaseComission.Name = "radioBaseComission";
            this.radioBaseComission.Size = new System.Drawing.Size(102, 17);
            this.radioBaseComission.TabIndex = 15;
            this.radioBaseComission.TabStop = true;
            this.radioBaseComission.Text = "Base+Comission";
            this.radioBaseComission.UseVisualStyleBackColor = true;
            this.radioBaseComission.CheckedChanged += new System.EventHandler(this.radioBaseComission_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioSalaried);
            this.groupBox1.Controls.Add(this.radioCommision);
            this.groupBox1.Controls.Add(this.radioBaseComission);
            this.groupBox1.Location = new System.Drawing.Point(158, 365);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(364, 65);
            this.groupBox1.TabIndex = 19;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "groupBox1";
            // 
            // txtSalary
            // 
            this.txtSalary.Location = new System.Drawing.Point(158, 456);
            this.txtSalary.Margin = new System.Windows.Forms.Padding(2);
            this.txtSalary.Name = "txtSalary";
            this.txtSalary.Size = new System.Drawing.Size(68, 20);
            this.txtSalary.TabIndex = 20;
            // 
            // lblSalary
            // 
            this.lblSalary.AutoSize = true;
            this.lblSalary.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSalary.Location = new System.Drawing.Point(157, 441);
            this.lblSalary.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblSalary.Name = "lblSalary";
            this.lblSalary.Size = new System.Drawing.Size(123, 17);
            this.lblSalary.TabIndex = 21;
            this.lblSalary.Text = "Salary/Base Salary";
            // 
            // lblCommission
            // 
            this.lblCommission.AutoSize = true;
            this.lblCommission.Location = new System.Drawing.Point(278, 441);
            this.lblCommission.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCommission.Name = "lblCommission";
            this.lblCommission.Size = new System.Drawing.Size(86, 13);
            this.lblCommission.TabIndex = 23;
            this.lblCommission.Text = "Commisson Rate";
            // 
            // txtComission
            // 
            this.txtComission.Location = new System.Drawing.Point(281, 456);
            this.txtComission.Margin = new System.Windows.Forms.Padding(2);
            this.txtComission.Name = "txtComission";
            this.txtComission.Size = new System.Drawing.Size(68, 20);
            this.txtComission.TabIndex = 22;
            // 
            // lblSales
            // 
            this.lblSales.AutoSize = true;
            this.lblSales.Location = new System.Drawing.Point(399, 441);
            this.lblSales.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblSales.Name = "lblSales";
            this.lblSales.Size = new System.Drawing.Size(33, 13);
            this.lblSales.TabIndex = 25;
            this.lblSales.Text = "Sales";
            // 
            // txtSales
            // 
            this.txtSales.Location = new System.Drawing.Point(401, 456);
            this.txtSales.Margin = new System.Windows.Forms.Padding(2);
            this.txtSales.Name = "txtSales";
            this.txtSales.Size = new System.Drawing.Size(68, 20);
            this.txtSales.TabIndex = 24;
            // 
            // btnSubmit
            // 
            this.btnSubmit.BackColor = System.Drawing.SystemColors.HotTrack;
            this.btnSubmit.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSubmit.ForeColor = System.Drawing.SystemColors.Desktop;
            this.btnSubmit.Location = new System.Drawing.Point(281, 493);
            this.btnSubmit.Margin = new System.Windows.Forms.Padding(2);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(75, 25);
            this.btnSubmit.TabIndex = 26;
            this.btnSubmit.Text = "submit";
            this.btnSubmit.UseVisualStyleBackColor = false;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // txtZip
            // 
            this.txtZip.Location = new System.Drawing.Point(409, 290);
            this.txtZip.Margin = new System.Windows.Forms.Padding(2);
            this.txtZip.Name = "txtZip";
            this.txtZip.Size = new System.Drawing.Size(68, 20);
            this.txtZip.TabIndex = 12;
            // 
            // cmbDept
            // 
            this.cmbDept.FormattingEnabled = true;
            this.cmbDept.Location = new System.Drawing.Point(386, 339);
            this.cmbDept.Name = "cmbDept";
            this.cmbDept.Size = new System.Drawing.Size(105, 21);
            this.cmbDept.TabIndex = 28;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(383, 323);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 13);
            this.label2.TabIndex = 29;
            this.label2.Text = "Department";
            // 
            // dgEmployee
            // 
            this.dgEmployee.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgEmployee.Location = new System.Drawing.Point(24, 563);
            this.dgEmployee.Name = "dgEmployee";
            this.dgEmployee.Size = new System.Drawing.Size(642, 193);
            this.dgEmployee.TabIndex = 30;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // dtpBirthDate
            // 
            this.dtpBirthDate.Location = new System.Drawing.Point(307, 210);
            this.dtpBirthDate.Name = "dtpBirthDate";
            this.dtpBirthDate.Size = new System.Drawing.Size(200, 20);
            this.dtpBirthDate.TabIndex = 31;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(203, 216);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 13);
            this.label3.TabIndex = 32;
            this.label3.Text = "Date of Birth:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(203, 242);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 13);
            this.label4.TabIndex = 34;
            this.label4.Text = "Date Joined:";
            // 
            // dtpJoinedDate
            // 
            this.dtpJoinedDate.Location = new System.Drawing.Point(307, 236);
            this.dtpJoinedDate.Name = "dtpJoinedDate";
            this.dtpJoinedDate.Size = new System.Drawing.Size(200, 20);
            this.dtpJoinedDate.TabIndex = 33;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(24, 540);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(169, 13);
            this.label5.TabIndex = 35;
            this.label5.Text = "Search by first name or last name: ";
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(199, 537);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(350, 20);
            this.txtSearch.TabIndex = 36;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(555, 537);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(110, 23);
            this.btnSearch.TabIndex = 37;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // epSSN
            // 
            this.epSSN.ContainerControl = this;
            // 
            // epDateOfBirth
            // 
            this.epDateOfBirth.ContainerControl = this;
            // 
            // epDateJoined
            // 
            this.epDateJoined.ContainerControl = this;
            // 
            // epFName
            // 
            this.epFName.ContainerControl = this;
            // 
            // epLName
            // 
            this.epLName.ContainerControl = this;
            // 
            // epZip
            // 
            this.epZip.ContainerControl = this;
            // 
            // EmployeeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(694, 768);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dtpJoinedDate);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dtpBirthDate);
            this.Controls.Add(this.dgEmployee);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbDept);
            this.Controls.Add(this.txtZip);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.lblSales);
            this.Controls.Add(this.txtSales);
            this.Controls.Add(this.lblCommission);
            this.Controls.Add(this.txtComission);
            this.Controls.Add(this.lblSalary);
            this.Controls.Add(this.txtSalary);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.chkMarried);
            this.Controls.Add(this.cmbState);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblAddress2);
            this.Controls.Add(this.txtAddress2);
            this.Controls.Add(this.lblAddress1);
            this.Controls.Add(this.txtAddress1);
            this.Controls.Add(this.lblSSN);
            this.Controls.Add(this.txtSSN);
            this.Controls.Add(this.lblLastName);
            this.Controls.Add(this.txtLastname);
            this.Controls.Add(this.lblFirstName);
            this.Controls.Add(this.txtFirstName);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "EmployeeForm";
            this.Text = "EmployeeForm";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgEmployee)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.epSSN)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.epDateOfBirth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.epDateJoined)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.epFName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.epLName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.epZip)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtFirstName;
        private System.Windows.Forms.Label lblFirstName;
        private System.Windows.Forms.Label lblLastName;
        private System.Windows.Forms.TextBox txtLastname;
        private System.Windows.Forms.Label lblSSN;
        private System.Windows.Forms.TextBox txtSSN;
        private System.Windows.Forms.Label lblAddress1;
        private System.Windows.Forms.TextBox txtAddress1;
        private System.Windows.Forms.Label lblAddress2;
        private System.Windows.Forms.TextBox txtAddress2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbState;
        private System.Windows.Forms.CheckBox chkMarried;
        private System.Windows.Forms.RadioButton radioSalaried;
        private System.Windows.Forms.RadioButton radioCommision;
        private System.Windows.Forms.RadioButton radioBaseComission;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtSalary;
        private System.Windows.Forms.Label lblSalary;
        private System.Windows.Forms.Label lblCommission;
        private System.Windows.Forms.TextBox txtComission;
        private System.Windows.Forms.Label lblSales;
        private System.Windows.Forms.TextBox txtSales;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.TextBox txtZip;
        private System.Windows.Forms.ComboBox cmbDept;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgEmployee;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.DateTimePicker dtpBirthDate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dtpJoinedDate;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.ErrorProvider epSSN;
        private System.Windows.Forms.ErrorProvider epDateOfBirth;
        private System.Windows.Forms.ErrorProvider epDateJoined;
        private System.Windows.Forms.ErrorProvider epFName;
        private System.Windows.Forms.ErrorProvider epLName;
        private System.Windows.Forms.ErrorProvider epZip;
    }
}

