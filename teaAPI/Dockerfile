FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["teaAPI/teaAPI.csproj", "teaAPI/"]
RUN dotnet restore "teaAPI/teaAPI.csproj"
COPY . .
WORKDIR "/src/teaAPI"
RUN dotnet build "teaAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "teaAPI.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "teaAPI.dll"]