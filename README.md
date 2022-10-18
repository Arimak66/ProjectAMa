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
<br><br>
<img src="mainwindow.png"/>
User authorization is done by comparing user inputted credentials with the data stored in the database. After successful authorization user is directed to an appropriate window based on user category, i.e. administratror, student of teacher. Each user category then can carry out operations that are allowed for the category, administrator-category having the largest rights.
<br>
<img src="login.png"/>
<br><br>

<br>
Administrator can in the current version view user information and add/delete users. Administrator can also create a new course as well as change his/her own password. User information is output using ListView, thus user can be selected from the desired list by clicking. Update operations are at the moment under construction.
<br>
<img src="administratorview.png"/>
<br>
Student can at the moment view his/her own data in a limited fashion, as well as view courses and grades he/she has enrolled in. Changing of password is also possible.
<br>
<img src="studentview1.png"/>
<br>
Teacher has at the moment possibility to view limited student data and add a new course. Changing of password is also possible.
<br>
<img src="teacherview1.png"/>
Upon exiting the user window, application returns to the start window where user can either log in again or close the application.
<br>
The application should be converted to the MVVM-model in the future.
