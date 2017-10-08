# getState-byCoutryId-andCity-byStateId-mvc
 I defined  here how to create each table in sql for performing this program .I hope its a helpful. 
 
 
 create table Countries
(
CountryId int primary key identity,
CountryName nvarchar(50) 
)
create table States
(
StateId int primary key identity,
CountryId int foreign key references Countries(CountryId),
StateName nvarchar(50) 
)
create table Cities
(
CityId int primary key,
StateId int foreign key references States(StateId),
CityName nvarchar(50) 
)
