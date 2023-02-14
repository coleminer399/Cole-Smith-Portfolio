#ifndef _DATE_H_
#define _DATE_H_


#include <iostream>
#include <string>
using namespace std;


class Date
{
private:
	int 	year;
	int 	month;
	int 	date;

public:
	Date(int a_year, int a_month, int a_day)
		: year(a_year), month(a_month), date(a_day) {}

	virtual void display()
	{
		cout << year << "/" << month << "/" << date << endl;
	}

	friend 	ostream& operator<<(ostream& out, Date& me)
	{
		out << "Year: " << me.year << "  Month: " << me.month
			<< "  Date: " << me.date;
		return out;
	}
};

#endif

