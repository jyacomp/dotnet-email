# dotnet send email
## Software Architecture
```
# .\src\Infrastructure
dotnet new classlib -o .\src\Infrastructure\Infrastructure.Notifications -f net5.0
dotnet add .\src\Infrastructure\Infrastructure.Notifications package Microsoft.Extensions.DependencyInjection.Abstractions
dotnet add .\src\Infrastructure\Infrastructure.Notifications package Microsoft.Extensions.Configuration.Abstractions
dotnet user-secrets init -p .\src\Infrastructure\Infrastructure.Notifications
rm .\src\Infrastructure\Infrastructure.Notifications\Class1.cs
mkdir .\src\Infrastructure\Infrastructure.Notifications\Email
echo 'namespace Infrastructure.Notifications.Email { }' > .\src\Infrastructure\Infrastructure.Notifications\Email\IEmailService.cs
echo 'namespace Infrastructure.Notifications.Email { }' > .\src\Infrastructure\Infrastructure.Notifications\Email\MailKitEmailService.cs
dotnet add .\src\Infrastructure\Infrastructure.Notifications package MailKit
echo 'namespace Infrastructure.Notifications.Email { }' > .\src\Infrastructure\Infrastructure.Notifications\Email\SmtpClientEmailService.cs

echo 'namespace Infrastructure.Notifications { }' > .\src\Infrastructure\Infrastructure.Notifications\DependencyInjection.cs


# .\src\Presentation
dotnet new mvc -o .\src\Presentation\WebApp -f net5.0
dotnet add .\src\Presentation\WebApp reference .\src\Infrastructure\Infrastructure.Notifications

dotnet new console -o .\src\Presentation\ConsoleApp -f net5.0
dotnet add .\src\Presentation\ConsoleApp package Microsoft.Extensions.Hosting
dotnet add .\src\Presentation\ConsoleApp package Microsoft.Extensions.Hosting.Abstractions
dotnet add .\src\Presentation\ConsoleApp reference .\src\Infrastructure\Infrastructure.Notifications
dotnet user-secrets init -p .\src\Presentation\ConsoleApp

dotnet new webapi -o .\src\Presentation\WebApi -f net5.0
dotnet add .\src\Presentation\WebApi reference .\src\Infrastructure\Infrastructure.Notifications


dotnet new sln
dotnet sln add (ls -r .\**\*.csproj)
```
