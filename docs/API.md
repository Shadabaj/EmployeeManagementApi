# API reference

The routes below reflect the current controller actions. Open Swagger at `/swagger` while running in the Development environment to inspect request models and try the endpoints.

## Employee endpoints

| Method | Route | Description | Typical result |
| --- | --- | --- | --- |
| GET | `/EmployeeDetails` | Lists employees | 200 with results; 204 when no employees are returned |
| GET | `/Employee/{id}` | Gets an employee by employee code | 200 when found; 404 when not found |
| POST | `/CreateEmployee` | Creates an employee from an employee model | 201 when created; 400 on a failed create; 500 on an unhandled server error |
| PUT | `/EditEmployee` | Updates an employee from an employee model | 200 when updated; 404 when the update fails; 500 on a server error |
| DELETE | `/DeleteEmployee/{employeeCode}/{profileImage}` | Deletes an employee and asks the file helper to delete the supplied profile image | 200 on success; 404 if the operation reports failure |

## Location reference endpoints

| Method | Route | Description | Typical result |
| --- | --- | --- | --- |
| GET | `/GetCountry` | Lists countries | 200 with results; 204 when empty |
| GET | `/GetStates` | Lists states | 200 with results; 204 when empty |
| GET | `/GetCities` | Lists cities | 200 with results; 204 when empty |

## Request and response notes

- Employee create and update actions use the employee model defined in the Models project.
- The employee lookup route uses the employee code as its `id` parameter.
- The delete route currently accepts the profile-image value as part of the URL. URL-encode route values where necessary and consider changing this contract so the server resolves the image from a validated employee record.
- Exact schemas and status codes should be verified against the running application and Swagger output as the API changes.
