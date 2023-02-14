// Copyright 2019, Bradley Peterson, Weber State University, all rights reserved. (11/2019)

#include <iostream>
#include <string>
#include <stack>
#include <sstream>
#include <cmath>

//To prevent those using g++ from trying to use a library
//they don't have
#ifndef __GNUC__
#include <conio.h>
#else
#include <stdio.h>
#endif

using std::stack;
using std::istringstream;
using std::ostringstream;
using std::string;
using std::cout;
using std::cerr;
using std::endl;
using std::pow;
class Node {
public:
	string data = "";
	Node* leftPtr = nullptr;
	Node* rightPtr = nullptr;
};
class TreeParser {
private:
	stack<string> mathStack;
	double castStrToDouble(string const &s);
	string castDoubleToStr(const double d);
	void initialize();
	bool isDigit(char c);
	bool isOperator(char c);
	void processExpression(Node* p); //Assuming raw pointers, or you can use shared pointers
	void computeAnswer(Node* p); //Assuming raw pointers, or you can use shared pointers
protected:
	string expression;
	unsigned int position;
public:
	TreeParser();
	void displayParseTree();
	void processExpression(string &expression);
	string computeAnswer();
	void inOrderTraversal(Node* root);
	void postOrderTraversal(Node* root);
	Node* rootPtr = nullptr;
};
void TreeParser::initialize() {
	expression = "";
	position = 0;
	while (!mathStack.empty()) {
		mathStack.pop();
	}
}

double TreeParser::castStrToDouble(const string &s) {
	istringstream iss(s);
	double x;
	iss >> x;
	return x;
}

string TreeParser::castDoubleToStr(const double d) {
	ostringstream oss;
	oss << d;
	return oss.str();

}

TreeParser::TreeParser() {
	initialize();
}


void TreeParser::displayParseTree() {
	cout << "The expression seen using in-order traversal: ";
	inOrderTraversal(this->rootPtr);
	cout << endl;
	cout << "The expression seen using post-order traversal: ";
	postOrderTraversal(this->rootPtr);
	cout << endl;

}

bool TreeParser::isOperator(char c) {
	if (c == 94 || (c >= 42 && c <= 47 && c != 44 && c != 46)) {
		return true;
	}
	else {
		return false;
	}
}

bool TreeParser::isDigit(char c) {
	if (c >= 48 && c<=57) {
		return true;
	}
	else {
		return false;
	}
	
}

void TreeParser::processExpression(Node* p) {
	while (this->position < this->expression.size()) {
		if (expression[this->position] == 40) {
			Node* newNode = new Node;
			p->leftPtr = newNode;
			this->position++;
			processExpression(p->leftPtr);
		}
		else if (isDigit(expression[this->position])) {
			string temp = "";
			while (isDigit(expression[this->position]))
			{
				temp += expression[this->position];
				this->position++;
			}
			p->data = temp;
			return;
		}
		else if (isOperator(expression[this->position])) {
			p->data = expression[this->position];
			Node* newNode = new Node;
			p->rightPtr = newNode;
			this->position++;
			processExpression(p->rightPtr);
		}
		else if (expression[this->position] == 41) {
			this->position++;
			return;
		}
		else if (expression[this->position] == 32) {
			this->position++;
		}
	}
}

void TreeParser::processExpression(string &expression) {
	if (expression != "") {
		this->expression = expression;
		this->position = 0;

		Node* newNode = new Node;
		this->rootPtr = newNode;
		processExpression(rootPtr);
	}
	
}

string TreeParser::computeAnswer() {
	computeAnswer(this->rootPtr);
	return mathStack.top();
}

void TreeParser::computeAnswer(Node* p) {
	if (p == NULL) {
		return;
	}
	else {
		computeAnswer(p->leftPtr);
		computeAnswer(p->rightPtr);
		if (isDigit(p->data[0])) {
			mathStack.push(p->data);
		}
		if (isOperator(p->data[0])) {
			double num1;
			num1 = castStrToDouble(mathStack.top());
			mathStack.pop();
			double num2;
			num2 = castStrToDouble(mathStack.top());
			mathStack.pop();
			double answer;
			if (p->data[0] == 42) {//Multiply
				answer = num2 * num1;
			}
			else if (p->data[0] == 43) {//Add
				answer = num2 + num1;
			}
			else if (p->data[0] == 45) {//Sub
				answer = num2 - num1;
			}
			else if (p->data[0] == 47) {//Div
				answer = num2 / num1;
			}
			else if (p->data[0] == 94) {//Pow
				answer = pow(num2,num1);
			}
			mathStack.push(castDoubleToStr(answer));
		}
	}
}

void TreeParser::inOrderTraversal(Node* root) {
	if (root == NULL) {
		return;
	}
	else {
		inOrderTraversal(root->leftPtr);
		cout << root->data << ",";
		inOrderTraversal(root->rightPtr);
	}

}

void TreeParser::postOrderTraversal(Node* root) {
	if (root == NULL) {
		return;
	}
	else {
		postOrderTraversal(root->leftPtr);
		postOrderTraversal(root->rightPtr);
		cout << root->data << ",";
	}
}


void pressAnyKeyToContinue() {
	printf("Press any key to continue\n");

	//Linux and Mac users with g++ don't need this
	//But everyone else will see this message.
#ifndef __GNUC__
	_getch();
#else
	int c;
	fflush(stdout);
	do c = getchar(); while ((c != '\n') && (c != EOF));
#endif

}

// Copyright 2019, Bradley Peterson, Weber State University, all rights reserved. (11/2019)

int main() {

	TreeParser *tp = new TreeParser;

	string expression = "(4+7)";
	tp->processExpression(expression);
	tp->displayParseTree();
	cout << "The result is: " << tp->computeAnswer() << endl; //Should display 11 as a double output

	expression = "(7-4)";
	tp->processExpression(expression);
	tp->displayParseTree();
	cout << "The result is: " << tp->computeAnswer() << endl; //Should display 3 as a double output

	expression = "(9*5)";
	tp->processExpression(expression);
	tp->displayParseTree();
	cout << "The result is: " << tp->computeAnswer() << endl; //Should display 45 as a double output

	expression = "(4^3)";
	tp->processExpression(expression);
	tp->displayParseTree();
	cout << "The result is: " << tp->computeAnswer() << endl; //Should display 64 as a double output

	expression = "((2-5)-5)";
	tp->processExpression(expression);
	tp->displayParseTree();
	cout << "The result is: " << tp->computeAnswer() << endl; //Should display -8 as a double output

	expression = "(5*(6/2))";
	tp->processExpression(expression);
	tp->displayParseTree();
	cout << "The result is: " << tp->computeAnswer() << endl; //Should display 15 as a double output

	expression = "((1 + 2) * (3 + 4))";
	tp->processExpression(expression);
	tp->displayParseTree();
	cout << "The result is: " << tp->computeAnswer() << endl; //Should display 21 as a double output

	expression = "(543+321)";
	tp->processExpression(expression);
	tp->displayParseTree();
	cout << "The result is: " << tp->computeAnswer() << endl; //Should display 864 as a double output

	expression = "((5*(3+2))+(7*(4+6)))";
	tp->processExpression(expression);
	tp->displayParseTree();
	cout << "The result is: " << tp->computeAnswer() << endl; //Should display 95 as a double output

	expression = "(((((3+12)-7)*120)/(2+3))^3)";
	tp->processExpression(expression);
	tp->displayParseTree();
	cout << "The result is: " << tp->computeAnswer() << endl; //Should display close to 7077888 as a double output 
															//NOTE, it won't be exact, it will display as scientific notation!

	expression = "(((((9+(2*(110-(30/2))))*8)+1000)/2)+(((3^4)+1)/2))";
	tp->processExpression(expression);
	tp->displayParseTree();
	cout << "The result is: " << tp->computeAnswer() << endl; //Should display close to 1337 as a double/decimal output

	pressAnyKeyToContinue();
	return 0;
}
