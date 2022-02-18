@ECHO OFF
start "eureka-server" docker run --publish 8761:8761 steeltoeoss/eureka-server
start "postgresql" docker run --env POSTGRES_PASSWORD=Steeltoe789 --publish 5432:5432 steeltoeoss/postgresql
start "Web Api Instance 1" dotnet run --project .\SteeltoeWebApi1\SteeltoeWebApi1.csproj --force -f netcoreapp3.1
start "Web Api Instance 2" dotnet run --project .\SteeltoeWebApi2\SteeltoeWebApi2.csproj --force -f netcoreapp3.1
start "Web App Instance 1" dotnet run --project .\SteeltoeWebApp1\SteeltoeWebApp1.csproj --force -f netcoreapp3.1
exit /b
