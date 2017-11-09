/**
	This Script must return ALL employees employed in the company at the point of execution
	Howdy will automatically invite/remove/move employees based on this data.
*/

select
	'EmployeeID' = cast(Id as nvarchar(10)), --Must always be a string. Required
	'Firstname' = Firstname, --Required
	'Lastname' = Lastname, --Required
	'Email' = Email, --Required
	'Phonenumber' = Phonenumber, -- always a string in for format '+XXYYYYYYY' or null. Not required
	
	--Optional, company specific dimensions. All strings or null
	'Department' = Department, 
	'Role' = 'Manager', 
	'Dim1' = '', 
	'Dim2' = ''
from
	Person	