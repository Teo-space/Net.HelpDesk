#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0-alpine AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0-alpine AS build
WORKDIR /src
COPY ["HelpDesk/HelpDesk.csproj", "HelpDesk/"]
RUN dotnet restore "HelpDesk/HelpDesk.csproj"
COPY . .
WORKDIR "/src/HelpDesk"
RUN dotnet build "HelpDesk.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "HelpDesk.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "HelpDesk.dll"]