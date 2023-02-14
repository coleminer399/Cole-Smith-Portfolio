#ifndef _EMPLOYEE_H_
#define _EMPLOYEE_H_


#include <iostream>
#include <string>
using namespace std;


#include "address.h"
#include "date.h"

class Employee
{
private:
	string 	 name;
	Date 	 birthDate;
	Address* addr;

public:
	virtual double calc_pay() = 0;

	Employee(string a_name, int a_year, int a_month, int a_day)
		: name(a_name), birthDate(a_year, a_month, a_day), addr(NULL) {}

	~Employee()
	{
		if (addr != NULL)
			delete addr;
	}

	void setAddress(string a_street, string a_city)
	{
		if (addr != NULL)
			delete addr;
		addr = new Address(a_street, a_city);
	}

	virtual void display()
	{
		cout << name << endl;
		birthDate.display();
		if (addr != NULL)
			addr->display();
	}

	string getName()
	{
		return name;
	}

	friend 	ostream& operator<<(ostream& out, Employee& me)
	{
		cout << "Name: " << me.name << "  Birth Date: " << me.birthDate;
		if (me.addr != NULL)
			out << "  Address: " << *me.addr;
		out << endl;
		return out;
	}
	
};




#endif

