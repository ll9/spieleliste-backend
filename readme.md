## Deployment

dotnet publish -o publish -r linux-arm
cd publish
dotnet <NAME>.dll --urls http://0.0.0.0:<PORT>