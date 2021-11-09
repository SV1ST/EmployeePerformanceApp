# EmployeePerformanceApp
This small application is designed for keeping records and assigning ratings to subordinate employees by role. The program has three interfaces for working with it (administrator, team lead, head of department). The application is built on a local database.

## Login to the program
### The entrance to the program is accompanied by this login panel.
![LoginPage](https://user-images.githubusercontent.com/89912206/140965414-14f433da-f8be-45c4-bbef-617ebc2198c9.PNG)
### If the user of the program enters incorrect data, he will receive the following error.
![LoginError](https://user-images.githubusercontent.com/89912206/140965532-a799aca0-b98f-4a06-b2d8-85876f58311d.PNG)
### That the username and password are required to enter, and if the user does not enter data in the fields, he will receive the following.
![LoginRequired](https://user-images.githubusercontent.com/89912206/140966277-8b67819e-30d6-4bec-b039-6f26ac4c683b.PNG)
## Role-based interface
### Admin panel and its features 
![AdminLogin](https://user-images.githubusercontent.com/89912206/140967151-04411d8a-8ecd-4a30-96cb-6f3f64c28bb5.PNG)
#### The administrator has the ability to create a new user, edit it as well as delete it.
![AdminCreateUser](https://user-images.githubusercontent.com/89912206/140968335-bf54c67b-9755-47ce-9d17-315e3e4f87aa.PNG)
#### On the delete view, the admin has a search bar by first name, last name, department, status, and role. This whole panel works on the principle of entering both a whole word and a certain part of it. The admin can search both by one field and by all the fields specified in this form. The search itself is performed by type Contains. For example:
![SearchingAdm](https://user-images.githubusercontent.com/89912206/140969884-8a2685d0-182a-4f2a-831b-c6ad3e68111b.PNG)
Triggered by pressing a button!
#### As I said, the admin can edit an individual user by a unique value
![edit](https://user-images.githubusercontent.com/89912206/140970456-ece2d983-973e-4fac-bcf9-6e4c4df4b8cf.PNG)

I would like to note that so far I have not been able to transfer the default select for an existing user by the role and status fields, so I will have to completely rewrite it.
#### The user is deleted by a unique value, the determination is made by clicking on the delete button
![del](https://user-images.githubusercontent.com/89912206/140971556-81049de6-88a4-4524-a86a-d9bcd8272e47.PNG)
#### Parameters and selections
Creation of parameters and their addition to the created selection works according to the same principle. When creating parameters, they cling to the department, that is, they are not available for another department. The coefficient when creating a parameter is mandatory and varies in the range from one to zero.
The administrator also has the ability to remove a specific parameter by a unique value. Sample deletion is not designed.
![Param](https://user-images.githubusercontent.com/89912206/140973074-2577285a-7bee-4f1f-8322-3589c6ca77d4.PNG)
The created selection is built on the principle of overwriting parameters, that is, every time you access to edit parameters for a specific selection, the administrator will have to overwrite the array of parameters that need to be connected to this selection.
![add](https://user-images.githubusercontent.com/89912206/140974021-e3e4b7a9-1108-4d21-b933-dfc683781440.PNG)
![ower](https://user-images.githubusercontent.com/89912206/140974178-67f029be-cb62-4b49-b3c1-4c605bdb6d1d.PNG)

This is where the description of the admin's functionality ends, maybe it is not as colorful as it seemed, but still I tried to convey all the most basic ...
### Team lead panel and its capabilities
![lead panel](https://user-images.githubusercontent.com/89912206/140974920-8e448399-5b3a-4e60-9938-8381bca69683.PNG)
#### A team lead has the ability to rate his subordinates, watch other comrades in the department, not including himself, that is, he will not see himself in the search table, but he will be able to see other leads, a boss or subordinates.
![leadMa](https://user-images.githubusercontent.com/89912206/140975726-95f29edc-4d13-4040-bee9-76e9682c257a.PNG)
The lead role is rated by clicking on the link that conveys the unique value of the selected user. Further, in the form, the lead can select a specific parameter from the drop-down list (as I have already noted the parameter is tied to a specific department), the assessment argument, and give a mandatory description for the assessment. The date of the assessment in the database will correspond to this format: DateTime.Now().

![userma](https://user-images.githubusercontent.com/89912206/140976675-fa031ac8-f5c0-4bd6-ae5f-ec4a03b3b92b.PNG)

This is where the lead functionality ends, let's move on to the head of the department.
### Head of department panel and its features
Before describing the capabilities of the head of the department, I would like to note that the assessment in the role of the head occurs only for the leads of this department, according to the same parameters as for other subordinates of this department. The search in the table of all employees of a given department is carried out according to the same anology as in the lead panel.
#### The head of the department has the opportunity to view all the ratings for his department, and it does not matter who put them down by the leader or the head. Also in the table of all grades, with the help of the link which is located under the table, he can view only the current grades.
![allMa](https://user-images.githubusercontent.com/89912206/140978653-ba46b50f-4934-44b8-81ca-be3268cd58d7.PNG)
#### The administrator has the right to view all selections with a set of parameters for his department. Based on the sample, he can view the top best and top worst for this sample, as well as download the table file.
![312321](https://user-images.githubusercontent.com/89912206/140979460-fc425526-70b7-4d48-b304-3d9a589faf1e.PNG)
![Capture123123123](https://user-images.githubusercontent.com/89912206/140979587-48e9489d-108b-43f0-827b-9da45a6658b4.PNG)
## All headers by role and their functionality
### Admin
![admi](https://user-images.githubusercontent.com/89912206/140979925-c6a16c0c-b2c4-461c-9064-57f3fad1a667.PNG)
### Lead
![lea](https://user-images.githubusercontent.com/89912206/140980059-71735c4d-9de4-4152-b133-9029607c3e31.PNG)
### Head of department
![chief](https://user-images.githubusercontent.com/89912206/140980181-a31646ee-6017-47d2-860b-a855ede5e85e.PNG)
## Formulas used for business logic
### Ball-rating calculation for the top
![form](https://user-images.githubusercontent.com/89912206/140981999-d78e7209-9c9c-4861-a136-9adb7e89bfdb.PNG)

