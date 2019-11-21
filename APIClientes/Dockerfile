FROM mcr.microsoft.com/dotnet/core/aspnet:3.0-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.0-buster AS build
WORKDIR /src
COPY ["APIClientes/APIClientes.csproj", "APIClientes/"]
RUN dotnet restore "APIClientes/APIClientes.csproj"
COPY . .
WORKDIR "/src/APIClientes"
RUN dotnet build "APIClientes.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "APIClientes.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "APIClientes.dll"]