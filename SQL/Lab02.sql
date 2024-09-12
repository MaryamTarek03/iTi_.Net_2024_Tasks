Using company database

-- 1. display all the employee’s data
    
    
    SELECT *
    FROM Employee
    
    
-- 2. display the employee's first name, last name, salary, and department number 
    
    
    SELECT Fname, Lname, Dno, Salary
    FROM Employee
    
    
-- 3. display all the project names, locations, and the department responsible for it
    
    
    SELECT Pname, Plocation, Dnum
    FROM Project
    SELECT Pname, Plocation, Dname
    FROM Project LEFT OUTER JOIN Departments
    ON Departments.Dnum = Project.Dnum
    
    
-- 4. As you know the company policy is to pay an annual commission for each employee with a specific percentage = 10% of his/her yearly salary. display each employee's full name and annual commission in an ANNUAL COM column (alias)
    
    
    SELECT Fname + ' ' + Lname AS 'Full Name', (Salary * 12 * 0.1) AS 'Annual Com'
    FROM Employee
    
    
-- 5. display the employee's ID, and name who earn more than 1000 LE monthly
    
    
    SELECT SSN, Fname
    FROM Employee
    WHERE Salary >= 1000
    
    
-- 6. display the employee IDs and names who earn more than 10000 LE annually
    
    
    SELECT SSN, Fname
    FROM Employee
    WHERE Salary * 12 >= 10000
    
    
-- 7. display the name and salary of the female employees
    
    
    SELECT Fname, Salary
    FROM Employee
    WHERE Sex = 'F'
    
    
-- 8. display each department ID, and name, which is managed by a manager with id = 968574 
    
    
    SELECT Dnum, Dname
    FROM Departments
    WHERE MGRSSN = 968574
    
    
-- 9. display the ID, name, and location of the project which is controlled by Department 10


    SELECT Pnumber, Pname, Plocation
    FROM Project
    WHERE Dnum = 10