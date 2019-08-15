FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-nanoserver-1809 AS base
WORKDIR /VBaseProject.Api
EXPOSE 5000

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-nanoserver-1809 AS build
WORKDIR /app

COPY ["VBaseProject.Api/VBaseProject.Api.csproj", "VBaseProject.Api/"]
COPY ["VBaseProject.Service/VBaseProject.Service.csproj", "VBaseProject.Service/"]
COPY ["VBaseProject.Entities/VBaseProject.Entities.csproj", "VBaseProject.Entities/"]
COPY ["VBaseProject.Extensions/VBaseProject.Resources.csproj", "VBaseProject.Extensions/"]
COPY ["VBaseProject.Data/VBaseProject.Data.csproj", "VBaseProject.Data/"]

RUN dotnet restore "VBaseProject.Api/VBaseProject.Api.csproj"

COPY . .
WORKDIR /app/VBaseProject.Api
RUN dotnet build "VBaseProject.Api.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "VBaseProject.Api.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "VBaseProject.Api.dll"]

#docker build -t vbaseproject .
#docker run -p 8080:5000 vbaseproject
#PORTS ext:docker