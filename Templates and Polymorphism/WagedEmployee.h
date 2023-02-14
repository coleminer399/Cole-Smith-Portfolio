#ifndef _WAGEDEMPLOYEE_H_
#define _WAGEDEMPLOYEE_H_


#include <iostream>
#include <string>
using namespace std;

#include "Employee.h"


class WagedEmployee : public Employee
{
private:
	double 	wage;
	double 	hours;

public:
	double calc_pay()
	{
		return wage * hours;
	}
	WagedEmployee(string a_name, int a_year, int a_month, int a_day, double a_wage, double a_hours)
		: Employee(a_name, a_year, a_month, a_day), wage(a_wage), hours(a_hours) {}


	virtual void display()
	{
		Employee::display();
		cout << wage << " " << hours << endl;
		cout << calc_pay() << endl;
	}

	friend 	ostream& operator<<(ostream& out, WagedEmployee& me)
	{
		out << (Employee &)me << "  Wage: " << me.wage << " Hours: " << me.hours;
		return out;
	}
};

#endif

