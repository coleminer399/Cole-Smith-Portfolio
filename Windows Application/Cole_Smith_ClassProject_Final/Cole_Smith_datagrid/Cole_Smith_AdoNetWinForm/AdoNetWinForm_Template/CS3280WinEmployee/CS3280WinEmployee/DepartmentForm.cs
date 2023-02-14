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
    public partial class DepartmentForm : Form
    {
        public DepartmentForm()
        {
            InitializeComponent();
            #region data bind region
            Organization.DepartmentsDataTable dtDeptTable = Utility.GetDepartments();
            dgDepartment.DataSource = dtDeptTable;


            dgDepartment.Columns["DeptId"].Visible = false;
            dgDepartment.Columns["Address"].Visible = false;






            DataGridViewButtonColumn deleteColumn = new DataGridViewButtonColumn();
            deleteColumn.HeaderText = "Use to Delete";
            deleteColumn.Text = "Delete";
            deleteColumn.Name = "deleteButton";
            deleteColumn.UseColumnTextForButtonValue = true;
            dgDepartment.Columns.Add(deleteColumn);

            DataGridViewButtonColumn editColumn = new DataGridViewButtonColumn();
            editColumn.HeaderText = "Live Edit";
            editColumn.Text = "Edit";
            editColumn.Name = "editButton";
            editColumn.UseColumnTextForButtonValue = true;
            dgDepartment.Columns.Add(editColumn);

            dgDepartment.CellClick += DgDepartment_CellClick;


            #endregion
        }

        private void btnAddDepartment_Click(object sender, EventArgs e)
        {
            gbAddOrUpdate.Visible = true;
            ClearInput();
        }

        private void dgDepartment_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }


        private void DgDepartment_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Organization.DepartmentsDataTable dtDeptTable = Utility.GetDepartments();
            int currentDeptId = -1;

            DataGridView dg = (DataGridView)sender;

            DataGridViewRow rowToBeOpperatedUpon = dg.Rows[e.RowIndex];
            currentDeptId = int.Parse(rowToBeOpperatedUpon.Cells["DeptID"].Value.ToString());


            if (e.ColumnIndex == -1)
            {

                //MessageBox.Show("You Selected the entire row. Current Emp ID is: " + currentEmpId);
                if (e.RowIndex < dg.Rows.Count-1 ) {
                    gbAddOrUpdate.Visible = true;
                    txtName.Text = dtDeptTable.FindByDeptID(currentDeptId).DeptName;
                    txtLocation.Text = dtDeptTable.FindByDeptID(currentDeptId).Location;
                    txtAddress.Text = dtDeptTable.FindByDeptID(currentDeptId).Address;
                    txtContactPerson.Text = dtDeptTable.FindByDeptID(currentDeptId).ContactName;
                    txtPhoneNumber.Text = dtDeptTable.FindByDeptID(currentDeptId).PhoneNumber;
                }


                return;

            }




            if (dg.SelectedCells.Count == 1)
            {
                if (dg.SelectedCells[0] is DataGridViewTextBoxCell)
                {
                    DataGridViewTextBoxCell selectedCell = (DataGridViewTextBoxCell)dg.SelectedCells[0];

                }
                else if (dg.SelectedCells[0] is DataGridViewButtonCell)
                {

                    DataGridViewButtonCell selectedCell = (DataGridViewButtonCell)dg.SelectedCells[0];
                    if (selectedCell.Value.Equals("Delete"))
                    {
                        //MessageBox.Show("Delete is clicked. Current Emp ID is: " + currentEmpId);
                        Utility.DeleteDeptRow(currentDeptId);
                        RefreshGridData();
                    }
                    else if (selectedCell.Value.Equals("Edit"))
                    {
                        //MessageBox.Show("Edit is clicked. Current Dept ID is: " + currentDeptId);
                        Utility.UpdateDeptRow(currentDeptId, txtName.Text, txtLocation.Text, txtContactPerson.Text, txtPhoneNumber.Text, txtAddress.Text);
                        RefreshGridData();
                    }
                }
                return;
            }
            txtName.Text = "";
            txtLocation.Text = "";
            txtAddress.Text = "";
            txtContactPerson.Text = "";
            txtPhoneNumber.Text = "";
        }
        private void RefreshGridData()
        {
            Organization.DepartmentsDataTable dtDeptTable = Utility.GetDepartments();
            dgDepartment.DataSource = dtDeptTable;
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {

            Utility.SaveDepartment(txtName.Text, txtLocation.Text, txtContactPerson.Text, txtPhoneNumber.Text, txtAddress.Text);
            gbAddOrUpdate.Visible = false;



            RefreshGridData();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            dgDepartment.ClearSelection();
            //dgDepartment.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            CurrencyManager currencyManager = (CurrencyManager)BindingContext[dgDepartment.DataSource];
            currencyManager.SuspendBinding();
            //dgDepartment.CurrentCell = null;
           

            foreach (DataGridViewRow row in dgDepartment.Rows)
            {
                if (txtSearch.Text != "") {
                    if (row.Cells["DeptId"].Value != null)
                    {
                        if (row.Cells["DeptName"].Value.ToString().Equals(txtSearch.Text, StringComparison.InvariantCultureIgnoreCase))
                        {
                            dgDepartment.Rows[row.Index].Visible = true;
                        }
                        else
                        {
                            dgDepartment.Rows[row.Index].Visible = false;
                        }
                    }
                }
                else
                {
                    dgDepartment.Rows[row.Index].Visible = true;
                }
            }
            
            currencyManager.ResumeBinding();
           
            gbAddOrUpdate.Visible = false;
            ClearInput();
            
            //dgDepartment.CurrentCell = dgDepartment[0, 0];
        }
        private void ClearInput(){
            txtName.Text = "";
            txtLocation.Text = "";
            txtAddress.Text = "";
            txtContactPerson.Text = "";
            txtPhoneNumber.Text = "";
        }
    }

}
