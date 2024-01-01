# BUILD
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /app
COPY . .
RUN dotnet restore && \
	dotnet publish -c Release -o out

# DEPLOY
FROM mcr.microsoft.com/dotnet/aspnet:6.0 as deploy
WORKDIR /app
COPY --from=build /app/out .
EXPOSE 5245
ENTRYPOINT ["dotnet", "BankingBackend.API.dll"]
