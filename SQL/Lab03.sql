-- 1. Display the department ID, name, and ID, as well as the name of its manager.
    
    SELECT Dnum, Dname, MGRSSN, Fname+' '+Lname
    FROM Departments INNER JOIN Employee
    ON Employee.SSN = Departments.MGRSSN
    
-- 2. Display the names of the departments and the names of the projects under its control.
    
    SELECT Dname, Pname
    FROM project INNER JOIN departments
    ON departments.dnum = project.dnum
    
-- 3. Display the full data about all the dependence associated with the employee's name they depend on him/her. 
    
    SELECT CONCAT (fname, ' ', lname) AS Full_Name, dependent.*
    FROM employee RIGHT OUTER JOIN dependent
    ON dependent.essn = employee.ssn
    
-- 4. Display the projects’ ID, name, and location in Cairo or Alex City. 
    
    SELECT pnumber AS Project_ID, Pname AS project_name, Plocation AS project_location
    FROM project
    WHERE city = 'Cairo' OR city = 'Alex'
    
-- 5. Display the Projects full data of the projects with a name starting with "a" letter.
    
    SELECT *
    FROM project
    WHERE pname LIKE 'A%' 
    
-- 6. display all the employees in department 30 whose salary is from 1000 to 2000 LE monthly
    
    SELECT *
    FROM employee
    WHERE salary BETWEEN 1000 AND 2000
    
-- 7. Retrieve the names of all employees in department 10 who work more than or equal to 10 hours per week on the "AL Rabwah" project.
    
    SELECT CONCAT(employee.fname, ' ', employee.lname) AS full_name
    FROM employee
    INNER JOIN works_for ON employee.SSN = works_for.ESSN
    INNER JOIN project ON works_for.pno = project.pnumber
    WHERE employee.dno = 10 AND works_for.hours >= 10 AND project.pname = 'Al Rabwah';
    
-- 8. Find the names of the employees who are directly supervised by Kamel Mohamed.
    
    SELECT CONCAT(X.fname, ' ', X.lname) AS full_name
    FROM Employee X INNER JOIN Employee Y
    ON Y.ssn = X.superSSN AND Y.fname = 'Kamel' AND Y.lname = 'Mohamed'
    
9. Retrieve the names of all employees and the names of the projects they are working on, sorted by the project name.
    
    SELECT employee.fname, project.pname
    FROM employee 
    LEFT OUTER JOIN works_for ON employee.SSN = works_for.ESSN
    LEFT OUTER JOIN project ON project.pnumber = works_for.pno
    ORDER BY project.pname
    
-- 10. For each project located in Cairo City, find the project number, the controlling department name, the department manager's last name, address, and birth date. 
    
    SELECT project.pnumber, departments.dname, employee.lname, employee.address, employee.bdate
    FROM project 
    INNER JOIN departments ON departments.dnum = project.dnum
    INNER JOIN employee ON employee.SSN = departments.MGRSSN
    WHERE project.city = 'Cairo'