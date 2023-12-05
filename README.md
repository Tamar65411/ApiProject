This project is a website for a restaurant.
In order to run this  project,  .NET 7 is needed, as well as V.S. at least 2022 version. 
To create a DB you need to use CODE FIRST and make sure you have SQL installed.
About our project:
The project was written in .NET 7, client side: JS.
The project was written according to REST API  architecture principles.
When a user registers in the system we verified the strength of the password  by using the Zxcvbn package.
We divided our project according to the layers model. The layers communicate with the help of DI to enable encapsulation and for the code to be easier to operate.
We used async await for the project to be scalability.
We created the project in the DATA FIRST way using EF so that we used the data as objects.
In order to monitor the operations on the database we used the PROFILER professional tool.
Our project is documented and organized by the SWAGGWR.
We used DTO entities because we have to return to the client not the same things 
We used AutoMapper library- to exchange objects to DTO object and the opposite.
We created CONFIGURATION file for separated code parameters, like connection string 
In case of 
Our project send information data to file, in case of error it send email to the manager by using the LOGGER opensource library.
 To catch errors from all the layer we wrote middleware.  
We wrote another middleware to keep important data about the entries user.   
Enjoy using our project.
