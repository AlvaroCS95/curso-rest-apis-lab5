FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80

ENV ASPNETCORE_URLS=http://+:80

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["DotNetWebAssembly/", "DotNetWebAssembly/"]
RUN dotnet restore "DotNetWebAssembly/DotNetWebAssembly.csproj"
COPY . .
WORKDIR "/src/DotNetWebAssembly"
RUN dotnet build "DotNetWebAssembly.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "DotNetWebAssembly.csproj" -c Release -o /app/publish

FROM nginx:latest as final
WORKDIR /app
COPY --from=publish /app/publish/wwwroot/_framework /usr/share/nginx/html/_framework
COPY --from=build /src/DotNetWebAssembly/wwwroot/index.html /usr/share/nginx/html/index.html