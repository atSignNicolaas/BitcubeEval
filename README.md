#BitcubeEval

//Section-1
	Created:
		- Model>Data.cs (Code-Frist approach)
	Scaffolding:
		- Controllers
		- Views
	Database(Migration):
		- Migration>InitialCreate
	Modified Controllers:
		- Lecturer and Student for firstname and full name creation
		
//Section-2
	Created:
		- Two additional views for lecturer to support login page and dashboard
		- Two action methods to support Views in lecturer controller
		- Additional class to support multiple models in a view
	Modified:
		- Couple of views to support new changes to when a lecturer logs in that data has to be lecturer specific
		- Some existing action methods to present data better
		- Lecturer controller has been the most modified in this section specificly to implement the login and dashboard
	Note: login uses the id of lecturers as it is a unique value