/* Question #1: Create a view that generates one record per invoice.  Each
	line should have a total of all invoice lines (using extended price),
	the year that the invoice was created in, the invoice id, the customer id
	and the customer name.

	Use the view to return the top 3 invoices for customerID 1 and 401, in the
	year 2014.  You should get 6 rows back, one for Tailspin Toys with an invoice
	total of $23,156.98.

	Include the script for your view and the query you wrote to use the view.
*/
CREATE OR ALTER VIEW ItemsSoldByYear
AS(
	SELECT
		I.InvoiceID,
		I.CustomerID,
		C.CustomerName,
		YEAR(I.InvoiceDate) [salesYear],
		SUM(IL.ExtendedPrice) [total]
	FROM
		Sales.Invoices I 
		INNER JOIN Sales.InvoiceLines IL ON I.InvoiceID = IL.InvoiceID
		INNER JOIN Sales.Customers C ON C.CustomerID = I.CustomerID
	GROUP BY 
		I.InvoiceID,
		I.CustomerID,
		C.CustomerName,
		YEAR(I.InvoiceDate)
)

Select 
*
FROM
	(SELECT
		ROW_NUMBER() OVER (PARTITION BY ISBY.customerID,ISBY.SalesYear 
			ORDER BY ISBY.Total DESC) [Ranking],
			*
	FROM 
		ItemsSoldByYear ISBY
	WHERE
		ISBY.SalesYear = 2014
	)X
WHERE X.ranking IN (1,2,3)
AND (X.CustomerID = '1'
	OR X.CustomerID = '401')



		
/* Question #2: Write a check constraint for the table below that
	restricts ItemCost to be some value between $0.01 and $999,999.99.

	Write two inserts for the table above - one that falls in the approved
	range, one that does not.  
*/

CREATE TABLE CS3550FinalFall2018_Table1
(
	MyKey int IDENTITY(1,1) NOT NULL PRIMARY KEY,
	ItemCost money NOT NULL,
	ItemDescription varchar(255) NOT NULL,
	CreatedOn smalldatetime DEFAULT(GETDATE()),
	UpdatedOn smalldatetime DEFAULT(GETDATE()),
	Active bit DEFAULT(1)
)

ALTER TABLE CS3550FinalFall2018_Table1
	ADD CONSTRAINT CheckVal CHECK(CS3550FinalFall2018_Table1.ItemCost > .01 AND CS3550FinalFall2018_Table1.ItemCost < 999999.99)

INSERT INTO [CS3550FinalFall2018_Table1](ItemCost,ItemDescription)VALUES (5.00, 'random description')--should pass
INSERT INTO [CS3550FinalFall2018_Table1](ItemCost,ItemDescription)VALUES (1000000.00, 'different random description')--should not pass

--drop table CS3550FinalFall2018_Table1
/* Question #3: Write a trigger that prevents deletes from the finals table.
	Your trigger should instead update the active bit to 0.  Make sure your
	trigger works on multiple statements (not just a single row delete).

	Write an insert statement that adds three records to the table.  Then write
	a single delete statement that removes two of the three records (your
	choice on which two).  Finally, add a select statement to validate
	your trigger worked.

*/
--trigger
CREATE OR ALTER TRIGGER NoDeletes
ON [CS3550FinalFall2018_Table1]
INSTEAD OF DELETE
AS
BEGIN
	UPDATE T 
	SET Active = 0
	FROM
	deleted i
	INNER JOIN CS3550FinalFall2018_Table1 t ON i.MyKey = t.MyKey
END

--inserts
SET IDENTITY_INSERT CS3550FinalFall2018_Table1 ON
INSERT INTO [CS3550FinalFall2018_Table1](
myKey,
ItemCost,
ItemDescription
)
VALUES 
	(2, 15.00, 'another description'),
	(3, 67.00, 'somthing'),
	(4, 98.00, 'somthing else')

SET IDENTITY_INSERT CS3550FinalFall2018_Table1 OFF


DELETE FROM CS3550FinalFall2018_Table1 WHERE mykey = 3 OR myKey = 4--deletes check


SELECT * FROM CS3550FinalFall2018_Table1--select check


/* Question #4: Write a trigger that updates the "UpdatedOn" column
	after someone updates any value in the above finals table.  Again,
	make sure your trigger will handle updates to multiple records...

	Update the cost of the row you didn't activate above.  Write another
	select statement to make sure your trigger fired.  

*/
CREATE OR ALTER TRIGGER UpdateDate
ON [CS3550FinalFall2018_Table1]
AFTER UPDATE
AS
	UPDATE T 
	SET UpdatedOn = GETDATE()
	FROM
	Inserted i
	INNER JOIN CS3550FinalFall2018_Table1 t ON i.MyKey = t.MyKey



UPDATE CS3550FinalFall2018_Table1
	SET ItemDescription = 'changed description'
	WHERE MyKey = 1 OR MyKey = 2


SELECT * FROM CS3550FinalFall2018_Table1

/* Question #5: Write a stored procedure to add items to the above
	finals table.  Rules you need to consider - 
	- Check for errors when you insert and gracefully handle the 
		problem by returning a value of -1 and printing out a message
		of the problem.
	- Verify that an item with the same name is not already in the table.
		If there is, return -2 and print out a message for the problem

	Write a script to call your stored procedure three times - one with a
		bad price, one with a duplicated description, and one that works.
		Make sure to capture the error code and print it to the screen.

*/
CREATE OR ALTER PROCEDURE spAddItems
	@ItemCost MONEY ,
	@ItemDescription VARCHAR (255)
AS
BEGIN
	DECLARE @DoYouExist int = 0
	DECLARE @ErrorMesAllreadyExists varchar(100) = 'Description already exists'
	DECLARE @ErrorMesNotAllowed varchar(100) = 'Value not allowed'
		SELECT
			@DoYouExist = COUNT(T1.MyKey)
		FROM
			CS3550FinalFall2018_Table1 T1
		WHERE
			UPPER(T1.ItemDescription) = UPPER(@ItemDescription)
		IF (@ItemCost < .01 OR @ItemCost > 999999.99)
		BEGIN
			PRINT @ErrorMesNotAllowed
		END

		ELSE
		BEGIN
			IF(@DoYouExist = 0)
			BEGIN
				INSERT INTO CS3550FinalFall2018_Table1
				(
					ItemCost,
					ItemDescription
				)
				VALUES	(@ItemCost, @ItemDescription)
			END
			ELSE
			BEGIN
				PRINT @ErrorMesAllreadyExists
			END
		END
END;
EXEC spAddItems 50000000000, 'bad price'
EXEC spAddItems 50, 'somthing'
EXEC spAddItems 138, 'Should Work'

/* Question #6: Write a function that takes a price and a tax rate as inputs
	and returns the price with tax applied to it.

	Use this function in a query that returns the price, the price with tax (for
	Utah @7.25%, the item key, and item description.  Only include active
	items.
*/
CREATE OR ALTER FUNCTION funcPriceWithTax (@Price MONEY,@Tax DECIMAL(10,2))         
RETURNS MONEY
BEGIN 
	DECLARE @Total MONEY
	DECLARE @OriginalPrice MONEY	
	SET @Tax = @Tax/100
	SET @Total = @price * @Tax
	SET @Total = @price +@Total
	RETURN @Total; 
END 



SELECT 
	MyKey,
	ItemDescription,
	ItemCost,
	dbo.funcPriceWithTax (ItemCost,7.25)[CostWithTax]
FROM 
	CS3550FinalFall2018_Table1
WHERE Active = 1


/* Question #7: Write a query that returns yearly sales (2013, 2014, 2015, 2016) and
	a total for all years for each Color in the Warehouse.Colors table.  
	You'll use the Sales.Invoices, Sales.InvoiceLines, Warehouse.StockItems, 
	and Warehouse.Colors tables.  Use the Extended price in the InvoiceLines table
	for the dollar values and InvoiceDate in the Invoices table for the year.

	Sort your final results on largest to smallest total sales.  You should get
	36 rows back.  Blue had the most sales with 41,289,464.30. Red had  
	1,505,240.75 of sales in 2014.
*/
SELECT
	WC.ColorName,
	SUM(CASE WHEN YEAR(SI.InvoiceDate) = 2013 THEN SIL.ExtendedPrice ELSE 0 END)[2013],
	SUM(CASE WHEN YEAR(SI.InvoiceDate) = 2014 THEN SIL.ExtendedPrice ELSE 0 END)[2014],
	SUM(CASE WHEN YEAR(SI.InvoiceDate) = 2015 THEN SIL.ExtendedPrice ELSE 0 END)[2015],
	SUM(SIL.ExtendedPrice)[Total]
FROM
	Warehouse.Colors WC
	LEFT JOIN Warehouse.StockItems WSI ON WSI.ColorID = WC.ColorID 
	LEFT JOIN Sales.InvoiceLines SIL ON WSI.StockItemID = SIL.StockItemID
	LEFT JOIN Sales.Invoices SI ON SIL.InvoiceID = SI.InvoiceID
GROUP BY 
	WC.ColorName
ORDER BY SUM(SIL.ExtendedPrice) DESC

/* Question #8: Create a view that returns all employees from the Application.People
	table (isEmployee = 1).  Make sure your view does the following:
		- Return a last name and first name colum, leveraging the full name
			column to get the values.
		- Fix the LogonName to exclude @wideworldimporters.com
		- Pull out title and hire date from the JSON string
		- Add a column for tenure that is calculated based on the difference
			of the current date and their hire date, in days, divided by 365.0
		- Include their email address, preferred name, personId also.
*/
CREATE OR ALTER VIEW AllEmployees
AS(
	SELECT
		PersonID,
		SUBSTRING(FullName, 1, CHARINDEX(' ', FullName) - 1) [FirstName],
		SUBSTRING(FullName, CHARINDEX(' ', FullName) + 1,LEN(FullName)) [LastName],
		JSON_VALUE(CustomFields,'$.Title') [Title],
		JSON_VALUE (customFields,'$.HireDate')[HireDate],
		SUBSTRING(LogonName, 1, CHARINDEX('@', LogonName) - 1) [LogonName],
		PreferredName,
		EmailAddress,
		(DATEDIFF(DAY,GETDATE(),JSON_VALUE (customFields,'$.HireDate')))/365*-1 [Tenure]
	FROM
		Application.People
	WHERE IsEmployee = 1
	
		
)

SELECT * FROM AllEmployees

/* Question #9: Write T-SQL that simulates rolling a dice 3000 times.  For
	each roll, insert the roll into the table below.  If you need help
	figuring out how to generate a random number between 1 and 6, check
	out https://stackoverflow.com/questions/7878287/generate-random-int-value-from-3-to-6

	When you're done, write a query that sums up how many of each roll you have and 
	what percentage of all rolls it was.  It should look pretty uniform and very close to 500
	for each.

*/

CREATE TABLE CS3550FinalFall2018_DiceRoll
(
	DiceRollKey int IDENTITY(1,1) PRIMARY KEY NOT NULL,
	DiceRoll int NOT NULL
)


DECLARE @TimesCount INT
DECLARE @DiceNum INT
SET @TimesCount = 1
WHILE @TimesCount <= 3000
BEGIN
	SET @DiceNum = (1.0 + floor(6 * RAND(convert(varbinary, newid()))))
	INSERT INTO CS3550FinalFall2018_DiceRoll (DiceRoll) VALUES (@DiceNum)
	SET @TimesCount = @TimesCount + 1
END


SELECT 
	DiceRoll,
	COUNT(DiceRoll)[Rolls], 
	(Count(DiceRollKey)* 100 / (Select Count(*) From CS3550FinalFall2018_DiceRoll)) [AproxPercentage]
	
FROM
	CS3550FinalFall2018_DiceRoll 
GROUP BY
	DiceRoll
ORDER BY DiceRoll



