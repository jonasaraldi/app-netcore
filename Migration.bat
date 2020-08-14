set /p Input=Nome do migration:
dotnet ef migrations add "%Input%" -s "WebApi\WebApi.csproj" -p "Data\Data.csproj" -c "DataContext"
pause