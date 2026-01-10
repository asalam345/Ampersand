## Initial Migration Command
dotnet ef migrations add InitialCreate -p TaskManagement.Infrastructure -s TaskManagement.API
## Update database without seeding data
dotnet ef update database -p TaskManagement.Infrastructure -s TaskManagement.API
