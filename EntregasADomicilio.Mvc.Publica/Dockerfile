#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["EntregasADomicilio.Mvc.Publica/EntregasADomicilio.Mvc.Publica.csproj", "EntregasADomicilio.Mvc.Publica/"]
COPY ["EntregasADomicilio.BusinessLayer/EntregasADomicilio.BusinessLayer.csproj", "EntregasADomicilio.BusinessLayer/"]
RUN dotnet restore "EntregasADomicilio.Mvc.Publica/EntregasADomicilio.Mvc.Publica.csproj"
COPY . .
WORKDIR "/src/EntregasADomicilio.Mvc.Publica"
RUN dotnet build "EntregasADomicilio.Mvc.Publica.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "EntregasADomicilio.Mvc.Publica.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "EntregasADomicilio.Mvc.Publica.dll"]