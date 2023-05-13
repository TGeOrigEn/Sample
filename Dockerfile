FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base

ENV ASPNETCORE_ENVIRONMENT=Development
ENV ASPNETCORE_URLS=http://+:80

WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Sample.WebAPI/Sample.WebAPI.csproj", "Sample.WebAPI/"]
RUN dotnet restore "Sample.WebAPI/Sample.WebAPI.csproj"
COPY . .
WORKDIR "/src/Sample.WebAPI"
RUN dotnet build "Sample.WebAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Sample.WebAPI.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Sample.WebAPI.dll"]