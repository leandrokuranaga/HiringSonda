#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:9.0-preview AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:9.0-preview AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/HiringSonda.Api/HiringSonda.API.csproj", "src/HiringSonda.Api/"]
COPY ["src/HiringSonda.Application/HiringSonda.Application.csproj", "src/HiringSonda.Application/"]
COPY ["src/HiringSonda.Domain/HiringSonda.Domain.csproj", "src/HiringSonda.Domain/"]
COPY ["src/HiringSonda.Infra.CrossCutting.IoC/HiringSonda.Infra.CrossCutting.IoC.csproj", "src/HiringSonda.Infra.CrossCutting.IoC/"]
COPY ["src/HiringSonda.Infra.Data/HiringSonda.Infra.Data.csproj", "src/HiringSonda.Infra.Data/"]
RUN dotnet restore "./src/HiringSonda.Api/HiringSonda.API.csproj"
COPY . .
WORKDIR "/src/src/HiringSonda.Api"
RUN dotnet build "./HiringSonda.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./HiringSonda.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "HiringSonda.API.dll"]