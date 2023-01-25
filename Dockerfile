FROM mcr.microsoft.com/dotnet/aspnet:7.0 as base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
COPY . /src
WORKDIR /src
RUN ls
RUN dotnet build "ECommerce.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ECommerce.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ECommerce.dll"]

# EXPOSE 5000/tcp
