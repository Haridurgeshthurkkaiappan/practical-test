create table Employee
(
  Name nvarchar(500) not null,
  Address nvarchar(500) not null,
  Age int not null,
  Phonenumber int not null,
  DOB datetime2 not null
  )

  create procedure listp
  as
  begin
   select * from Employee
   end
   exec listp

   create procedure inserta (@Name nvarchar(500),@Address nvarchar(500), @Age int,@phonenumber int, @DOB datetime2)
   as 
   begin

   insert into Employee (Name,Address,Age,Phonenumber,DOB) values (@Name,@Address,@Age,@phonenumber,@DOB)
   end
   exec inserta 'hari','palani',21,892552007,'08-08-2002'