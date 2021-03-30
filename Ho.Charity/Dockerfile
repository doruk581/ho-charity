FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim AS build
WORKDIR /src
COPY ["Ho.Charity/Ho.Charity.csproj", "Ho.Charity/"]
RUN dotnet restore "Ho.Charity/Ho.Charity.csproj"
COPY . .
WORKDIR "/src/Ho.Charity"
RUN dotnet build "Ho.Charity.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Ho.Charity.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Ho.Charity.dll"]
