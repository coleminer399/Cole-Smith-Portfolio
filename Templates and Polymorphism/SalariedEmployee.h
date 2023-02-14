#ifndef _SALARIEDEMPLOYEE_H_
#define _SALARIEDEMPLOYEE_H_


#include <iostream>
#include <string>
using namespace std;

#include "Employee.h"


class SalariedEmployee : public Employee
{
private:
	double 	salary;

public:
	double calc_pay()
	{
		return salary / 24;
	}

	SalariedEmployee(string a_name, int a_year, int a_month, int a_day, double a_salary)
		: Employee(a_name, a_year, a_month, a_day), salary(a_salary) {}


	virtual void display()
	{
		Employee::display();
		cout << salary << endl;
		cout << calc_pay() << endl;
	}

	friend 	ostream& operator<<(ostream& out, SalariedEmployee& me)
	{
		out << (Employee &)me << "  Salary: " << me.salary;
		return out;
	}
};

#endif

