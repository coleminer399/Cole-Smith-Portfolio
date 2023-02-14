using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CS3280WinEmployee
{
    public partial class EmployeeForm : Form
    {
        Color originalGroupBoxColor = Color.White;
        Color originalSubmitBtnColor = Color.White;
        public EmployeeForm()
        {
            InitializeComponent();
            btnSubmit.BackColor = Color.Red;
            originalGroupBoxColor = groupBox1.BackColor;
            groupBox1.BackColor = Color.Aqua;
            cmbState.SelectedItem = "CA";
            radioSalaried.Checked = true;
            originalSubmitBtnColor = btnSubmit.BackColor;

            #region Event intialization region
            btnSubmit.MouseEnter += BtnSubmit_MouseEnter;
            btnSubmit.MouseLeave += BtnSubmit_MouseLeave;

            txtLastname.MouseEnter += TxtLastname_MouseEnter;
            txtLastname.MouseLeave += TxtLastname_MouseLeave;
            txtSSN.Leave += TxtSSN_Leave;
            cmbDept.Click += CmbDept_Click;
            #endregion

            #region data bind region
            
            Organization.DepartmentsDataTable dtDeptTable = Utility.GetDepartments();

            
            cmbDept.DataSource = dtDeptTable;
            //display member
            //value member

            cmbDept.DisplayMember = dtDeptTable.DeptNameColumn.ColumnName;
            cmbDept.ValueMember = dtDeptTable.DeptIDColumn.ColumnName;

            Organization.EmployeesDataTable dtEmpTable = Utility.GetEmployees();

            dgEmployee.DataSource = dtEmpTable;

            //empid column invisible
            //column index, column name 0, EmpID
            dgEmployee.Columns["EmpID"].Visible = false;
            dgEmployee.Columns["Salary"].Visible = false;
            dgEmployee.Columns["Sales"].Visible = false;
            dgEmployee.Columns["Commision"].Visible = false;
            dgEmployee.Columns["Addr1"].Visible = false;
            dgEmployee.Columns["Addr2"].Visible = false;
            dgEmployee.Columns["State"].Visible = false;
            dgEmployee.Columns["Zip"].Visible = false;
            dgEmployee.Columns["IsMarried"].Visible = false;
            dgEmployee.Columns["EmpType"].Visible = false;
            dgEmployee.Columns["BirthDate"].Visible = false;
            dgEmployee.Columns["JoinDate"].Visible = false;
            //dgEmployee.Columns["DeptId"].DataPropertyName = dgEmployee.Columns["Addr1"].ToString();

            //dgEmployee.Columns["DeptID"]
            //dtDeptTable.FindByDeptID().DeptName;
            //dgEmployee.Columns["DeptID"].ReadOnly = true

            DataGridViewTextBoxColumn deptColumn = new DataGridViewTextBoxColumn();
            deptColumn.HeaderText = "Department";
            deptColumn.Name = "Department";
            dgEmployee.Columns.Add(deptColumn);

            DataGridViewButtonColumn deleteColumn = new DataGridViewButtonColumn();
            deleteColumn.HeaderText = "Use to Delete";
            deleteColumn.Text = "Delete";
            deleteColumn.Name = "deleteButton";
            deleteColumn.UseColumnTextForButtonValue = true;
            dgEmployee.Columns.Add(deleteColumn);

            DataGridViewButtonColumn editColumn = new DataGridViewButtonColumn();
            editColumn.HeaderText = "Live Edit";
            editColumn.Text = "Edit";
            editColumn.Name = "editButton";
            editColumn.UseColumnTextForButtonValue = true;
            dgEmployee.Columns.Add(editColumn);


            dgEmployee.Columns["Department"].Visible = false;
            
            
            foreach (DataGridViewRow row in dgEmployee.Rows)
            {

                if (row.Cells["DeptId"].Value != null) {


                        int deptId = int.Parse(row.Cells["DeptId"].Value.ToString());
                    if (dtDeptTable.FindByDeptID(deptId) != null) {
                        row.Cells["Department"].Value = dtDeptTable.FindByDeptID(deptId).DeptName;
                    }
                        
                    

                    
                }
                
                
            }

            dgEmployee.CellClick += DgEmployee_CellClick;


            #endregion

        }

        private void CmbDept_Click(object sender, EventArgs e)
        {
            RefreshCmbDepartments();
        }

        private void DgEmployee_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Organization.DepartmentsDataTable dtDeptTable = Utility.GetDepartments();
            Organization.EmployeesDataTable dtEmpTable = Utility.GetEmployees();
            int currentEmpId = -1;
            
            DataGridView dg = (DataGridView)sender;

            DataGridViewRow rowToBeOpperatedUpon = dg.Rows[e.RowIndex];
            currentEmpId = int.Parse(rowToBeOpperatedUpon.Cells["EmpID"].Value.ToString());
            

            if (e.ColumnIndex == -1)
            {

                //MessageBox.Show("You Selected the entire row. Current Emp ID is: " + currentEmpId);
                epSSN.SetError(txtSSN, "");
                epDateOfBirth.SetError(dtpBirthDate, "");
                epDateJoined.SetError(dtpJoinedDate, "");
                epFName.SetError(txtFirstName, "");
                epLName.SetError(txtLastname, "");
                epZip.SetError(txtZip, "");

                txtFirstName.Text = dtEmpTable.FindByEmpID(currentEmpId).FName;
                txtLastname.Text = dtEmpTable.FindByEmpID(currentEmpId).LName;
                txtSSN.Text = dtEmpTable.FindByEmpID(currentEmpId).SSN;
                txtSalary.Text = dtEmpTable.FindByEmpID(currentEmpId).Salary.ToString();
                txtSales.Text = dtEmpTable.FindByEmpID(currentEmpId).Sales.ToString();
                txtComission.Text = dtEmpTable.FindByEmpID(currentEmpId).Commision.ToString();
                if (dtEmpTable.FindByEmpID(currentEmpId) != null) {
                    //cmbDept.Text = dtDeptTable.FindByDeptID(dtEmpTable.FindByEmpID(currentEmpId).DeptID).DeptName;
                }
                txtAddress1.Text = dtEmpTable.FindByEmpID(currentEmpId).Addr1;
                txtAddress2.Text = dtEmpTable.FindByEmpID(currentEmpId).Addr2;
                cmbState.SelectedItem = dtEmpTable.FindByEmpID(currentEmpId).State;
                txtZip.Text = dtEmpTable.FindByEmpID(currentEmpId).Zip;
                chkMarried.Checked = dtEmpTable.FindByEmpID(currentEmpId).IsMarried;
                dtpBirthDate.Value = dtEmpTable.FindByEmpID(currentEmpId).BirthDate;
                dtpJoinedDate.Value = dtEmpTable.FindByEmpID(currentEmpId).JoinDate;

                if (radioBaseComission.Text == dtEmpTable.FindByEmpID(currentEmpId).EmpType)
                {
                    radioBaseComission.Checked = true;
                }
                else if (radioSalaried.Text == dtEmpTable.FindByEmpID(currentEmpId).EmpType)
                {
                    radioSalaried.Checked = true;
                }
                else if (radioCommision.Text == dtEmpTable.FindByEmpID(currentEmpId).EmpType)
                {
                    radioCommision.Checked = true;
                }
                else
                {
                    radioSalaried.Checked = true;
                }


                /*.Text = dtEmpTable.FindByEmpID(currentEmpId);
                .Text = dtEmpTable.FindByEmpID(currentEmpId);*/

                return;
                
            }
            

            if (dg.SelectedCells.Count == 1)
            {
                if (dg.SelectedCells[0] is DataGridViewTextBoxCell) {
                    DataGridViewTextBoxCell selectedCell = (DataGridViewTextBoxCell)dg.SelectedCells[0];
                    
                }
                else if (dg.SelectedCells[0] is DataGridViewButtonCell)
                {
                    DataGridViewButtonCell selectedCell = (DataGridViewButtonCell)dg.SelectedCells[0];
                    if (selectedCell.Value.Equals("Delete"))
                    {
                        //MessageBox.Show("Delete is clicked. Current Emp ID is: " + currentEmpId);
                        Utility.DeleteEmployeeRow(currentEmpId);
                        RefreshGridData();
                    }
                    else if (selectedCell.Value.Equals("Edit"))
                    {
                        if (ValidCheck()) {
                            string empType;

                            if (radioBaseComission.Checked)
                            {
                                empType = radioBaseComission.Text;
                            }
                            else if (radioSalaried.Checked)
                            {
                                empType = radioSalaried.Text;
                                txtComission.Text = "";
                                txtSales.Text = "";
                            }
                            else if (radioCommision.Checked)
                            {
                                empType = radioCommision.Text;
                                txtSalary.Text = "";
                            }
                            else
                            {
                                empType = "None";
                            }
                            int deptID = int.Parse(cmbDept.SelectedValue.ToString());
                            decimal salary = string.IsNullOrEmpty(txtSalary.Text) ? 0 : decimal.Parse(txtSalary.Text);
                            decimal commisionRate = string.IsNullOrEmpty(txtComission.Text) ? 0 : decimal.Parse(txtComission.Text);
                            decimal sales = string.IsNullOrEmpty(txtSales.Text) ? 0 : decimal.Parse(txtSales.Text);
                            //MessageBox.Show("Edit is clicked. Current Emp ID is: " + currentEmpId);
                            Utility.UpdateEmployeeRow(currentEmpId, txtFirstName.Text, txtLastname.Text, txtSSN.Text, deptID, salary,
                                commisionRate, sales, txtAddress1.Text, txtAddress2.Text, cmbState.Text, txtZip.Text, chkMarried.Checked, empType, dtpBirthDate.Value, dtpJoinedDate.Value);
                            RefreshGridData();
                            clearInput();
                        }
                    }
                }
                return;
            }
            
        }

        private void clearInput()
        {
            txtFirstName.Text = "";
            txtLastname.Text = "";
            txtSSN.Text = "";
            txtSalary.Text = "";
            txtSales.Text = "";
            txtComission.Text = "";
            cmbDept.SelectedIndex = 0;
            txtAddress1.Text = "";
            txtAddress2.Text = "";
            cmbState.SelectedItem = "CA";
            txtZip.Text = "";
            chkMarried.Checked = false;
            radioSalaried.Checked = true;
            dtpBirthDate.Value = DateTime.Now;
            dtpJoinedDate.Value = DateTime.Now;
        }
        /*private void DgEmployee_SelectionChanged(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }*/

        private void TxtSSN_Leave(object sender, EventArgs e)
        {
            bool isSSNCorrect =   Regex.IsMatch(txtSSN.Text, @"^\d{3}-\d{2}-\d{4}$");
            if (!isSSNCorrect) {
                MessageBox.Show("Enter valid ssn. An example: 111-11-1111");
                txtSSN.Clear();
                txtSSN.Focus();
            }
        }

        private void TxtLastname_MouseLeave(object sender, EventArgs e)
        {
            txtLastname.Size = new Size(txtLastname.Size.Width - 10, txtLastname.Size.Height);
        }
    

        private void TxtLastname_MouseEnter(object sender, EventArgs e)
        {
            txtLastname.Size = new Size(txtLastname.Size.Width + 10, txtLastname.Size.Height);
        }
        private void BtnSubmit_MouseLeave(object sender, EventArgs e)
        {
            btnSubmit.BackColor = originalSubmitBtnColor;
            
        }

        private void BtnSubmit_MouseEnter(object sender, EventArgs e)
        {
            btnSubmit.BackColor = Color.Beige;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void cmbState_SelectedIndexChanged(object sender, EventArgs e)
        {
            //MessageBox.Show(cmbState.SelectedItem.ToString());
            //MessageBox.Show(cmbState.SelectedIndex.ToString());
            
        }

        private void chkMarried_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void radioSalaried_CheckedChanged(object sender, EventArgs e)
        {
            //MessageBox.Show(radioSalaried.Checked.ToString());
            //MessageBox.Show(radioCommision.Checked.ToString());
            //MessageBox.Show(radioBaseComission.Checked.ToString());
            lblSalary.Visible = true;
            txtSalary.Visible = true;
            lblSales.Visible = false;
            lblCommission.Visible = false;
            txtComission.Visible = false;
            txtSales.Visible = false;
        }

        private void radioCommision_CheckedChanged(object sender, EventArgs e)
        {
            //MessageBox.Show(radioSalaried.Checked.ToString());
            //MessageBox.Show(radioCommision.Checked.ToString());
            //MessageBox.Show(radioBaseComission.Checked.ToString());
            lblSalary.Visible = false;
            txtSalary.Visible = false;
            lblSales.Visible = true;
            lblCommission.Visible = true;
            txtComission.Visible = true;
            txtSales.Visible = true;
        }

        private void radioBaseComission_CheckedChanged(object sender, EventArgs e)
        {
            //MessageBox.Show(radioSalaried.Checked.ToString());
            //MessageBox.Show(radioCommision.Checked.ToString());
            //MessageBox.Show(radioBaseComission.Checked.ToString());
            lblSalary.Visible = true;
            txtSalary.Visible = true;
            lblSales.Visible = true;
            lblCommission.Visible = true;
            txtComission.Visible = true;
            txtSales.Visible = true;
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            //int deptID = int.Parse(cmbDept.SelectedValue.ToString());
            if (ValidCheck()) {
                int deptID = int.Parse(cmbDept.SelectedValue.ToString());
                string addr1 = txtAddress1.Text;
                string addr2 = txtAddress2.Text;
                string state = cmbState.Text;
                string zip = txtZip.Text;
                bool isMarried = chkMarried.Checked;

                string employeeInformation = string.Empty;
                employeeInformation += txtFirstName.Text + " " + txtLastname.Text + "\r\n";
                employeeInformation += txtAddress1.Text + " " + txtAddress2.Text + " " + cmbState.SelectedItem.ToString() + "\r\n";
                employeeInformation += txtSSN.Text + "\r\n";
                if (txtSalary.Visible) {
                    employeeInformation += "Salary : " + txtSalary.Text + "\r\n";
                }
                if (txtComission.Visible) {
                    employeeInformation += "Commision Rate : " + txtComission.Text + "\r\n";
                }
                if (txtSales.Visible)
                {
                    employeeInformation += "Sales : " + txtSales.Text + "\r\n";
                }

                groupBox1.BackColor = originalGroupBoxColor;

                string empType;

                if (radioBaseComission.Checked)
                {
                    empType = radioBaseComission.Text;
                }
                else if (radioSalaried.Checked)
                {
                    empType = radioSalaried.Text;
                    txtComission.Text = "";
                    txtSales.Text = "";
                }
                else if (radioCommision.Checked)
                {
                    empType = radioCommision.Text;
                    txtSalary.Text = "";
                }
                else {
                    empType = "None";
                }


                decimal salary = string.IsNullOrEmpty(txtSalary.Text) ? 0 : decimal.Parse(txtSalary.Text);
                decimal commisionRate = string.IsNullOrEmpty(txtComission.Text) ? 0 : decimal.Parse(txtComission.Text);
                decimal sales = string.IsNullOrEmpty(txtSales.Text) ? 0 : decimal.Parse(txtSales.Text);




                Utility.SaveEmployee(txtFirstName.Text, txtLastname.Text, txtSSN.Text, deptID, salary, commisionRate, sales, addr1, addr2, state, zip, isMarried, empType, dtpBirthDate.Value, dtpJoinedDate.Value);




                RefreshGridData();
            }

        }

        private void RefreshGridData()
        {
            Organization.EmployeesDataTable dtEmpTable = Utility.GetEmployees();
            dgEmployee.DataSource = dtEmpTable;
        }
        private void RefreshCmbDepartments()
        {
            Organization.DepartmentsDataTable dtDeptTable = Utility.GetDepartments();
            cmbDept.DataSource = dtDeptTable;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            dgEmployee.ClearSelection();
            
            CurrencyManager currencyManager = (CurrencyManager)BindingContext[dgEmployee.DataSource];
            currencyManager.SuspendBinding();
            //dgDepartment.CurrentCell = null;

            foreach (DataGridViewRow row in dgEmployee.Rows)
            {
                if (txtSearch.Text != "")
                {
                    if (row.Cells["FName"].Value != null && row.Cells["LName"].Value != null)
                    {
                        if (row.Cells["FName"].Value.ToString().Equals(txtSearch.Text, StringComparison.InvariantCultureIgnoreCase) ||
                            row.Cells["LName"].Value.ToString().Equals(txtSearch.Text, StringComparison.InvariantCultureIgnoreCase))
                        {
                            dgEmployee.Rows[row.Index].Visible = true;
                        }
                        else
                        {
                            dgEmployee.Rows[row.Index].Visible = false;
                        }
                    }
                }
                else
                {
                    dgEmployee.Rows[row.Index].Visible = true;
                }
            }

            currencyManager.ResumeBinding();

            
        }
        private bool ValidCheck() {
            bool valid = true;
            bool isSSNCorrect = Regex.IsMatch(txtSSN.Text, @"^\d{3}-\d{2}-\d{4}$");
            epSSN.SetError(txtSSN, "");
            epDateOfBirth.SetError(dtpBirthDate, "");
            epDateJoined.SetError(dtpJoinedDate, "");
            epFName.SetError(txtFirstName,"");
            epLName.SetError(txtLastname, "");
            epZip.SetError(txtZip, "");
            if (txtFirstName.Text == "")
            {
                epFName.SetError(txtFirstName, "First name cannot be empty");
                valid = false;
            }
            if (txtLastname.Text == "")
            {
                epLName.SetError(txtLastname, "Last name cannot be empty");
                valid = false;
            }
            if (dtpBirthDate.Value >= DateTime.Now)
            {
                epDateOfBirth.SetError(dtpBirthDate, "Date of birth cannot be a future date");
                valid = false;
            }
            if (dtpJoinedDate.Value >= DateTime.Now)
            {
                epDateJoined.SetError(dtpJoinedDate, "The joined date cannot be a future date");
                valid = false;
            }
            if (txtZip.Text.Length != 5)
            {
                epZip.SetError(txtZip, "The zip must have 5 digits");
                valid = false;
            }            
            if (!isSSNCorrect)
            {
                epSSN.SetError(txtSSN,"The SSN must be in the form xxx-xx-xxxx");
                valid = false;
            }
            return valid;
        }
    }
}
