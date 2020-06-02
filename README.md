

This solution is developed using DotNet Core 3.0 & Clean Architecture Principle

Prerequsite:
--> Dot Net Core 3.0, MediatR, SQLExpress
--> Also other dependencies please repress the dependencies
--> Data Seeder & config can be used to generate Initial Migration Database Table with single command.

Run
1. Install / refresh all dependencies
2. Generate migration script or Manually create a Table user based on Infrastructure/UserConfiguration.cs 
3. Add valid Database connection for NotificationDatabase section in API/appsetting.json
4. Check the available port (It should be free)
5. Hit the run button --> It will pop-up a swagger-ui page for API testing

Missing Part
1. Exception handing
2. Validation of request object
3. SMTP Client Implementation