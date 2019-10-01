## Api Docs

http://192.168.178.40:8081/swagger

## Deployment

dotnet publish -o publish -r linux-arm
cd publish
dotnet <NAME>.dll --urls http://0.0.0.0:<PORT>