# HR Platform - Milica Tamajka
* All functionalities are available for testing at */swagger*.  
* Frontend includes candidate creation, skill creation and candidate search by name and/or skill(s).

## The most challenging part  

* The most challenging part while implementing the task was the candidate search. It was difficult to put every condition into one LINQ query
which returns all results at once.
I solved this by refactoring. I created one repository method for searching by name and one for searching by skills 
and then I combined them into one. Later, these 3 separate methods helped me have a cleaner service layer which is easier to read and understand.
