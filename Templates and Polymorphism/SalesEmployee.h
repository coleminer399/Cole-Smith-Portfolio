#ifndef _SALESEMPLOYEE_H_
#define _SALESEMPLOYEE_H_


#include <iostream>
#include <string>
using namespace std;

#include "SalariedEmployee.h"


class SalesEmployee : public SalariedEmployee
{
private:
	double 	commission;
	double 	sales;

public:
	double calc_pay()
	{
		return SalariedEmployee::calc_pay()
			+ (commission * sales);
	}

	SalesEmployee(string a_name, int a_year, int a_month, int a_day,
		double a_salary, double a_commission, double a_sales) :
		SalariedEmployee(a_name, a_salary, a_year, a_month, a_day),
		sales(a_sales), commission(a_commission) {}

	virtual double calcPay() {
		return 0;
	}

	virtual void display()
	{
		SalariedEmployee::display();
		cout << commission << " " << sales << endl;
		cout << calc_pay() << endl;
	}

	friend 	ostream& operator<<(ostream& out, SalesEmployee& me)
	{
		out << (SalariedEmployee &)me << " Commission: " << me.commission <<
			" Sales: " << me.sales;
		return out;
	}
};

#endif

