FROM mcr.microsoft.com/dotnet/aspnet:6.0 as runtime
WORKDIR /publish
EXPOSE 80
COPY bin/Release/net6.0/publish .
ENTRYPOINT ["dotnet","EntregasADomicilio.Api.dll"]

#docker build -t entregasadomicilio_api_dotnet . -f "Dockerfile"