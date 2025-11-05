DEV NOTES

dotnet-task-evaluator
backend

download all preqrequisites
identify the connection of project to postgresql base on readme.md
Add defaultconnection string and then migrate with readme.md command line

✦ Run The Project
	✓ no initial errors
	✓ displays now listening at a specific http url

✦ Visit the url API Swagger
	! GET /tasks endpoint returns ok status but no object data
	! Returns EF Core entities, potential internal data leak, circular reference exceptions

✦ Checked Models in relation to tasks
	✓ Has table structure
	✓ Has 1:M relationship

✦ Checked Users Model
	! Had bad indentions which hurts dev eyes (if it builds up)
	! PasswordHash is direct to API Response -> EFCore Returns
	✓ Added ViewModel for User Access
	✓ Added RegisterRequestClass for Input with Validation Attributes

✦ Go back to task model and controller
	✓ Async and Await methods are properly used
	✓ Contains Basic Crud already
	✓ Returns proper http codes
	✓ Uses DBContext
	! Returns EF Core Entities
	! Client Access Directly the EF

✦ TaskController Modifications
	✓ CRUD Functionality uses ViewModels
	✓ Validations Message Additions
	! User Auth/Login is nonexisting
_______________________________________________________________________________________________________________________

Version Control
Git Commits


✦ eb5a733
	✓ appsettings.json
	✓ backend.sln

✦ 9f7509c
	✓ ViewModels/
	✓ TaskItemViewModel.cs
	✓ UserViewModel.cs

✦ 7acd956
	✓ TaskController.cs GET /tasks

✦ 3bac4f5
	✓ TaskController.cs POST, PUT, DELETE /tasks

✦ c1d257f
	✓ Added Return Validation Message