# CommandApi

dotnet dev-certs https --trust
-> trust local development certificates


cd src
ls
dir
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

git init
git status
git add .
git rm -r --cached .vscode
git commit -m "initial commit"

git remote add origin https://github.com/xurca/CommandApi.git
git push -u origin master
