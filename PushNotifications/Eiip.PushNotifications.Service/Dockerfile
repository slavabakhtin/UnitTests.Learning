#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/runtime:3.1-buster-slim AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["Eiip.PushNotifications.Service/Eiip.PushNotifications.Service.csproj", "Eiip.PushNotifications.Service/"]
RUN dotnet restore "Eiip.PushNotifications.Service/Eiip.PushNotifications.Service.csproj"
COPY . .
WORKDIR "/src/Eiip.PushNotifications.Service"
RUN dotnet build "Eiip.PushNotifications.Service.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Eiip.PushNotifications.Service.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Eiip.PushNotifications.Service.dll"]