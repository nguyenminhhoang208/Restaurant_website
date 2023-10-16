#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Restaurant.PublicApi/Restaurant.PublicApi.csproj", "Restaurant.PublicApi/"]
RUN dotnet restore "Restaurant.PublicApi/Restaurant.PublicApi.csproj"
COPY . .
WORKDIR "/src/Restaurant.PublicApi"
RUN dotnet build "Restaurant.PublicApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Restaurant.PublicApi.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Restaurant.PublicApi.dll"]