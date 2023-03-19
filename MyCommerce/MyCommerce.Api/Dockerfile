#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["MyCommerce.Api/MyCommerce.Api.csproj", "MyCommerce.Api/"]
RUN dotnet restore "MyCommerce.Api/MyCommerce.Api.csproj"
COPY . .
WORKDIR "/src/MyCommerce.Api"
RUN dotnet build "MyCommerce.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MyCommerce.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MyCommerce.Api.dll"]