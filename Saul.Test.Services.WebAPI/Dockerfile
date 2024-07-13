FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build-env
WORKDIR /src
COPY . .
WORKDIR /src/Saul.Test.Services.WebAPI
RUN dotnet restore
RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1
WORKDIR /app
COPY --from=build-env /src/Saul.Test.Services.WebAPI/out ./

ENTRYPOINT ["dotnet", "Saul.Test.Services.WebAPI.dll"]