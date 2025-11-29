# See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

# This stage is used when running from VS in fast mode (Default for Debug configuration)
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081


# This stage is used to build the service project
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/3.Endpoints/Sampel.RestAPI.Endpoints.API/Sampel.RestAPI.Endpoints.API.csproj", "src/3.Endpoints/Sampel.RestAPI.Endpoints.API/"]
COPY ["src/1.Core/Sampel.RestAPI.Core.ApplicationService/Sampel.RestAPI.Core.ApplicationService.csproj", "src/1.Core/Sampel.RestAPI.Core.ApplicationService/"]
COPY ["src/1.Core/Sampel.RestAPI.Core.Contracts/Sampel.RestAPI.Core.Contracts.csproj", "src/1.Core/Sampel.RestAPI.Core.Contracts/"]
COPY ["src/1.Core/Sampel.RestAPI.Core.Domain/Sampel.RestAPI.Core.Domain.csproj", "src/1.Core/Sampel.RestAPI.Core.Domain/"]
COPY ["Sampel.RestAPI.SharedKernel/Sampel.RestAPI.SharedKernel.csproj", "Sampel.RestAPI.SharedKernel/"]
COPY ["src/1.Core/Sampel.RestAPI.Core.RequestResponse/Sampel.RestAPI.Core.RequestResponse.csproj", "src/1.Core/Sampel.RestAPI.Core.RequestResponse/"]
COPY ["src/2.Infra/Data/Sampel.RestAPI.Infra.Data.Sql.Commands/Sampel.RestAPI.Infra.Data.Sql.Commands.csproj", "src/2.Infra/Data/Sampel.RestAPI.Infra.Data.Sql.Commands/"]
COPY ["src/2.Infra/Data/Sampel.RestAPI.Infra.Data.Sql.Queries/Sampel.RestAPI.Infra.Data.Sql.Queries.csproj", "src/2.Infra/Data/Sampel.RestAPI.Infra.Data.Sql.Queries/"]
RUN dotnet restore "./src/3.Endpoints/Sampel.RestAPI.Endpoints.API/Sampel.RestAPI.Endpoints.API.csproj"
COPY . .
WORKDIR "/src/src/3.Endpoints/Sampel.RestAPI.Endpoints.API"
RUN dotnet build "./Sampel.RestAPI.Endpoints.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

# This stage is used to publish the service project to be copied to the final stage
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Sampel.RestAPI.Endpoints.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# This stage is used in production or when running from VS in regular mode (Default when not using the Debug configuration)
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Sampel.RestAPI.Endpoints.API.dll"]