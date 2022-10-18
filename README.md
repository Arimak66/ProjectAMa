<h1> WPF user interface </h1>
<br>
This application is a WPF-interface to interact with the MySQL university-database. Database is located on a separate computer running Fedora Server. Data is read synchronously using Dapper ORM. 
<br><br>
<h2>ER-model</h2>


<img src="er_model.png"/>
<br>
<h2>Application</h2>
<br>
The application opens with a main window directing user to either a login screen or to exit the application. 

<img src="mainwindow.png"/>

User authorization is done by comparing user inputted credentials with the data stored in the database. After successful authorization user is directed to an appropriate window based on user category, i.e. administratror, student of teacher. Each user category then can carry out operations that are allowed for the category, administrator-category having the largest rights.

Administrator can view, create, delete or update user information.

The application should be converted to the MVVM-model in the future.
