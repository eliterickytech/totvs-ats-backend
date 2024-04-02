#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["1-Presentation/Totvs.ATS.Api/Totvs.ATS.Api.csproj", "1-Presentation/Totvs.ATS.Api/"]
RUN dotnet restore "./1-Presentation/Totvs.ATS.Api/./Totvs.ATS.Api.csproj"
COPY . .
WORKDIR "/src/1-Presentation/Totvs.ATS.Api"
RUN dotnet build "./Totvs.ATS.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Totvs.ATS.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Totvs.ATS.Api.dll"]