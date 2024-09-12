-- Using company DB
-- 1.  Display the sum salary of employees who work in department number 10 
SELECT SUM(salary)
FROM employee
WHERE dno = 10

-- 2.  Display average salaries of employees 
SELECT AVG(salary)
FROM employee

-- 3.  Display average salaries of employees in department number 10 
SELECT AVG(salary)
FROM employee
WHERE dno = 10

-- 4.  Count the employees who work on project number 100 
SELECT COUNT(SSN)
FROM employee
INNER JOIN works_for ON employee.SSN = works_for.ESSN
WHERE works_for.pno = 100
SELECT COUNT(ESSN) AS employee_number
FROM works_for
WHERE pno = 100

-- 5.  Count the employees depending on their departments 
SELECT COUNT(SSN) AS employee_number, dno
FROM employee
GROUP BY dno

-- 6.  Sum hours of each project 
SELECT project.pname, SUM(works_for.hours) AS total_hours
FROM project 
INNER JOIN works_for
ON project.pnumber = works_for.pno
GROUP BY project.pname

-- 7.  Display the employee's full name and project name where the city of the project = Cairo and the address of its employees contains Giza 
SELECT CONCAT(e.fname, ' ', e.lname)  AS full_name, pr.pname
FROM employee e
INNER JOIN works_for w ON e.SSN = w.ESSN
INNER JOIN project pr ON pr.pnumber = w.pno
WHERE pr.city ILIKE 'Cairo' AND e.address ILIKE '%Giza%'

-- 8.  Display the full name of employees and their salaries when the salary is greater than the average salaries 
SELECT CONCAT(fname, ' ', lname)  AS full_name, salary
FROM employee
WHERE salary >= (SELECT AVG(salary) FROM employee)
-- Average salary = 1406

-- 9.  Display the supervisor names without duplication 
SELECT DISTINCT CONCAT(x.fname, ' ', x.lname), y.superSSN
FROM employee x
INNER JOIN employee y
ON x.SSN = y.superSSN