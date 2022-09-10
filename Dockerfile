#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /
COPY ["src/WeddingSite.Server/WeddingSite.Server.csproj", "src/WeddingSite.Server/"]
COPY ["src/WeddingSite.Contracts/WeddingSite.Contracts.csproj", "src/WeddingSite.Contracts/"]
COPY ["src/WeddingSite.Infrastructure/WeddingSite.Infrastructure.csproj", "src/WeddingSite.Infrastructure/"]
COPY ["src/WeddingSite.Application/WeddingSite.Application.csproj", "src/WeddingSite.Application/"]
COPY ["src/WeddingSite.Domain/WeddingSite.Domain.csproj", "src/WeddingSite.Domain/"]
COPY ["src/WeddingSite.Client/WeddingSite.Client.csproj", "src/WeddingSite.Client/"]
RUN dotnet restore "src/WeddingSite.Server/WeddingSite.Server.csproj"
COPY . .
WORKDIR "/src/WeddingSite.Server"
RUN dotnet build "WeddingSite.Server.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "WeddingSite.Server.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "WeddingSite.Server.dll"]