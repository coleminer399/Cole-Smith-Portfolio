using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public static class Utility
    {
        public static Organization.DepartmentsDataTable GetDepartments()
        {
            Organization.DepartmentsDataTable dtDeptTable = new Organization.DepartmentsDataTable();
            OrganizationTableAdapters.DepartmentsTableAdapter deptAdapter = new OrganizationTableAdapters.DepartmentsTableAdapter();
            deptAdapter.Fill(dtDeptTable);
            return dtDeptTable;
        }
        public static List<Organization.DepartmentsRow> GetFilteredDepartments(string deptName)
        {
            Organization.DepartmentsDataTable dtDeptTable = new Organization.DepartmentsDataTable();
            OrganizationTableAdapters.DepartmentsTableAdapter deptAdapter = new OrganizationTableAdapters.DepartmentsTableAdapter();
            var filteredRows = dtDeptTable.Where(x => x.DeptName.Equals(deptName, StringComparison.InvariantCultureIgnoreCase)).ToList();
            deptAdapter.Fill(dtDeptTable);
            return filteredRows;
        }
        public static void SaveEmployee(string fname, string lname, string ssn, int deptID, decimal salary, decimal commisionRate, decimal sales, 
            string addr1, string addr2, string state, string zip, bool isMarried, string empType, DateTime bithDate, DateTime joinedDate)
        {
            //employee table and the new row technuiqe to insert
            Organization.EmployeesDataTable dtEmpTable = new Organization.EmployeesDataTable();
            OrganizationTableAdapters.EmployeesTableAdapter empAdapter = new OrganizationTableAdapters.EmployeesTableAdapter();
            empAdapter.Fill(dtEmpTable);

            Organization.EmployeesRow newEmpRow = dtEmpTable.NewEmployeesRow();
            newEmpRow.FName = fname;
            newEmpRow.LName = lname;
            newEmpRow.SSN = ssn;
            newEmpRow.DeptID = deptID;
            newEmpRow.Salary = salary;
            newEmpRow.Sales = sales;
            newEmpRow.Commision = commisionRate;
            newEmpRow.Addr1 = addr1;
            newEmpRow.Addr2 = addr2;
            newEmpRow.State = state;
            newEmpRow.Zip = zip;
            newEmpRow.IsMarried = isMarried;
            newEmpRow.EmpType = empType;
            newEmpRow.BirthDate = bithDate;
            newEmpRow.JoinDate = joinedDate;


            dtEmpTable.AddEmployeesRow(newEmpRow);
            
            empAdapter.Update(dtEmpTable);

            
        }
        public static void SaveDepartment(string deptName, string location, string contactName, string phoneNumber, string address)
        {
            
            Organization.DepartmentsDataTable dtDeptTable = new Organization.DepartmentsDataTable();
            OrganizationTableAdapters.DepartmentsTableAdapter deptAdapter = new OrganizationTableAdapters.DepartmentsTableAdapter();
            deptAdapter.Fill(dtDeptTable);

            Organization.DepartmentsRow newDeptRow = dtDeptTable.NewDepartmentsRow();
            newDeptRow.DeptName = deptName;
            newDeptRow.Location = location;
            newDeptRow.ContactName = contactName;
            newDeptRow.PhoneNumber = phoneNumber;
            newDeptRow.Address = address;

            


            dtDeptTable.AddDepartmentsRow(newDeptRow);

            deptAdapter.Update(dtDeptTable);


        }
        public static Organization.EmployeesDataTable GetEmployees()
        {
            Organization.EmployeesDataTable dtEmpTable = new Organization.EmployeesDataTable();
            OrganizationTableAdapters.EmployeesTableAdapter empAdapter = new OrganizationTableAdapters.EmployeesTableAdapter();
            empAdapter.Fill(dtEmpTable);
            return dtEmpTable;
        }
        public static void DeleteEmployeeRow(int employeeId)
        {
            Organization.EmployeesDataTable dtEmpTable = new Organization.EmployeesDataTable();
            OrganizationTableAdapters.EmployeesTableAdapter empAdapter = new OrganizationTableAdapters.EmployeesTableAdapter();
            empAdapter.Fill(dtEmpTable);

            
            var deletingRows = dtEmpTable.Where(x => x.EmpID == employeeId).ToList();

            foreach (Organization.EmployeesRow row in deletingRows)
            {
                empAdapter.Delete(row.EmpID, row.FName, row.LName, row.SSN, row.DeptID, row.Salary, row.Sales, row.Commision, row.Addr1, row.Addr2,
                   row.State, row.Zip, row.IsMarried, row.EmpType, row.BirthDate, row.JoinDate);

            }

            empAdapter.Update(dtEmpTable);
            
        }
        public static void DeleteDeptRow(int deptId)
        {
            Organization.DepartmentsDataTable dtDeptTable = new Organization.DepartmentsDataTable();
            OrganizationTableAdapters.DepartmentsTableAdapter deptAdapter = new OrganizationTableAdapters.DepartmentsTableAdapter();
            deptAdapter.Fill(dtDeptTable);


            var deletingRow = dtDeptTable.FindByDeptID(deptId);
            
            
                deptAdapter.Delete(deletingRow.DeptID, deletingRow.DeptName, deletingRow.Location, deletingRow.ContactName, deletingRow.PhoneNumber, deletingRow.Address);

            

            deptAdapter.Update(dtDeptTable);

        }
        public static void UpdateDeptRow(int deptId, string deptName, string location, string contactName, string phoneNumber, string address)
        {
            Organization.DepartmentsDataTable dtDeptTable = new Organization.DepartmentsDataTable();
            OrganizationTableAdapters.DepartmentsTableAdapter deptAdapter = new OrganizationTableAdapters.DepartmentsTableAdapter();
            deptAdapter.Fill(dtDeptTable);

            
            var updatingRow = dtDeptTable.FindByDeptID(deptId);


            
            updatingRow.DeptName = deptName;
            updatingRow.Location = location; 
            updatingRow.ContactName = contactName;
            updatingRow.PhoneNumber = phoneNumber;
            updatingRow.Address = address;



            deptAdapter.Update(dtDeptTable);

        }
        public static void UpdateEmployeeRow(int employeeId, string fname, string lname, string ssn, int deptID, decimal salary, decimal commisionRate, decimal sales,
            string addr1, string addr2, string state, string zip, bool isMarried, string empType, DateTime bithDate, DateTime joinedDate)
        {
            Organization.EmployeesDataTable dtEmpTable = new Organization.EmployeesDataTable();
            OrganizationTableAdapters.EmployeesTableAdapter empAdapter = new OrganizationTableAdapters.EmployeesTableAdapter();
            empAdapter.Fill(dtEmpTable);


            var updatingRow = dtEmpTable.FindByEmpID(employeeId);



            
            updatingRow.FName = fname;
            updatingRow.LName = lname;
            updatingRow.SSN = ssn;
            updatingRow.DeptID = deptID;
            updatingRow.Salary = salary;
            updatingRow.Sales = sales;
            updatingRow.Commision = commisionRate;
            updatingRow.Addr1 = addr1;
            updatingRow.Addr2 = addr2;
            updatingRow.State = state;
            updatingRow.Zip = zip;
            updatingRow.IsMarried = isMarried;
            updatingRow.EmpType = empType;
            updatingRow.BirthDate = bithDate;
            updatingRow.JoinDate = joinedDate;
            

            empAdapter.Update(dtEmpTable);

        }

    }
}
