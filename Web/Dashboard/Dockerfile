#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY BetsDashboard.csproj .
RUN dotnet restore "BetsDashboard.csproj"
COPY . .
RUN dotnet build "BetsDashboard.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "BetsDashboard.csproj" -c Release -o /app/publish

FROM nginx:alpine AS final
WORKDIR /usr/share/nginx/html
COPY --from=publish /app/publish/BetsDashboard/dist .
COPY nginx.conf /etc/nginx/nginx.conf