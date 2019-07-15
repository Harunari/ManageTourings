FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["Manage_Tourings/Manage_Tourings.csproj", "Manage_Tourings/"]
RUN dotnet restore "Manage_Tourings/Manage_Tourings.csproj"
COPY . .
WORKDIR "/src/Manage_Tourings"
RUN dotnet build "Manage_Tourings.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "Manage_Tourings.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Manage_Tourings.dll"]