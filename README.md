# Mortgage Choice Dev Exam
The task is to build a simple application with the following requirements:

Create a simple ATM application with the following features:
 - Ability to login with a PIN or password
 - Ability to view a current balance
 - Ability to debit the balance
 - Ability to credit the balance
 - Ability to log out

For **Backend(web api)** I used the following:
 - Visual Studio 2019 Community Edition
 - .Net Core 3.1 framework
 - MS SQL Server 2019
 - Implemented Clean Architecture using MediatR and CQRS design pattern.

I used CQRS(Command and Query Responsibility Segregation) Pattern to maximize performance, scalability and security. It can also support the evolution of the system over time through higher flexibility. It can also prevent update commands from causing merge conflicts at the domain level.

The web api has the following endpints:
 - endpoint for validating the account number which will serve as a unique identification of the user and the PIN which will serve as the password.
 - it has PIN encryption and validation
 - endpoint for deposit
 - endpoint for withdrawal
 - endpoint for balance inquiry

For **Frontend** I used the latest angular version.
 - It has menu for Login and Logout, Balance Inquiry, Deposit and Withdrawal

I have completed the development and testing of the backend(web api). 
From the TestData folder I have InsertTestDataScript.sql script file that you can execute to create a test accounts.

**My trade-offs (anything I left out, or what I might do differently if I were to spend additional time on the project.)**

I left out the front-end part but if given the time I will continue to do the following where I got an issue and not yet completed.
 - applying of the authentication result to display the menu option available when the user successfully login.
 - passing of the account id to balance inquiry, deposit and withdrawal parameter currently it is hard-coded just for me to be able to call the web api to save the data and get a response.
 - displaying of the returned balance inquiry response to the UI.

Angular Level: Beginner

Single Page Application Level: Beginner

