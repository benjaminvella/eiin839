FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["TD3/TD3.csproj", "TD3/"]
RUN dotnet restore "TD3/TD3.csproj"
COPY . .
WORKDIR "/src/TD3"
RUN dotnet build "TD3.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TD3.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TD3.dll"]
