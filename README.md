# CsvToSql-
Csv To sql


1. The Connection string in Web.Config will need to point to the correct Location (and Schema)
2. A Table Named ExampleTable should be created with the following:
create table ExampleTable
	([GUID] varchar(100) NOT NULL,
	[Date] date not null,
	[Double] Float,
	[Int] int, 
	[String] varchar(50),
	PRIMARY KEY (GUID)
	);
  
 Although it is not necessary for the GUID to be a primary key, It will currently be treated as one regardless.
