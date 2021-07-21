# CommandApi

cd src  
ls  
dir  
cd ..

## dotnet
dotnet dev-certs https --trust  
-> trust local development certificates

dotnet new  
dotnet sln [sln file name].sln add [path to csproj]  
dotnet new sln -n [sln file name]  
dotnet new [template] -n [project name]  


dotnet new web -f netcoreapp3.1 -n CommandApi  
dotnet new xunit -f netcoreapp3.1 -n CommandApi.Tests  
dotnet sln .\CommandApi.sln add .\src\CommandApi\CommandApi.csproj .\test\CommandApi.Tests\CommandApi.Tests.csproj  
dotnet add .\test\CommandApi.Tests\CommandApi.Tests.csproj reference .\src\CommandApi\CommandApi.csproj  
dotnet build  
dotnet run  

dotnet user-secrets set "<user>" "<password>"  

Windows: %APPDATA%\Microsoft\UserSecrets  
Linux/OSX: ~/.microsoft/usersecrets  

## powershell
git init  
git status  
git add .  
git rm -r --cached .vscode  
git commit -m "initial commit"  

git remote add origin https://github.com/xurca/CommandApi.git  
git push -u origin master  


## docker
docker run --name some-postgres -e POSTGRES_PASSWORD=1a2s3d4f -p 5432:5432 -d postgres  
-> -p [internal port] : [external port]  
   --name is docker name  
   -e environment variable  
   -d tells docker to run "detached", meaning that the command prompt can be used  

docker ps  
-> list running containers  
docker ps -all  
-> list all containers that have run

docker start <container id or name>
-> start an existing container

docker stop <container id or name>
-> stop a running container

https://docs.docker.com/engine/reference/commandline/docker/


## dotnet ef
dotnet ef migrations add AddCommandsToDb  
dotnet ef database update

## sql
`
insert into "Commands" ("HowTo", "Platform", "CommandLine")
values ('Create an EF migration', 'Entity Framework Core Command Line',
'dotnet ef migrations add');
`

`
insert into "Commands" ("HowTo", "Platform", "CommandLine")
VALUES ('Apply Migrations to DB', 'Entity Framework Core Command Line',
'dotnet ef database update');
`

`
insert into "Commands" ("HowTo", "Platform", "CommandLine")
values ('Create an EF migration', 'Entity Framework Package Manager Console',
'add-migration <name of migration>');
`

`
insert into "Commands" ("HowTo", "Platform", "CommandLine")
values ('Apply Migrations to DB', 'Entity Framework Package Manager Console',
'update-database');