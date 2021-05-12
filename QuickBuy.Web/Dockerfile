FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim  AS base

WORKDIR /app              
	
EXPOSE 80
EXPOSE 443

FROM node:10-alpine as build-node

WORKDIR /ClientApp

COPY QuickBuy.Web/ClientApp/package.json .
COPY QuickBuy.Web/ClientApp/package-lock.json .

RUN npm install

COPY QuickBuy.Web/ClientApp/ . 

RUN npm run build  

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build

ENV BuildingDocker true

WORKDIR /src

COPY ["QuickBuy.Web/QuickBuy.Web.csproj", "QuickBuy.Web/"]
COPY ["QuickBuy.Dominio/QuickBuy.Dominio.csproj", "QuickBuy.Dominio/"]
COPY ["QuickBuy.Repositorio/QuickBuy.Repositorio.csproj", "QuickBuy.Repositorio/"]

RUN dotnet restore "QuickBuy.Web/QuickBuy.Web.csproj"
COPY . .
WORKDIR "/src/QuickBuy.Web"

RUN dotnet build "QuickBuy.Web.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "QuickBuy.Web.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
COPY --from=build-node /ClientApp/dist ./ClientApp/dist
ENTRYPOINT ["dotnet", "QuickBuy.Web.dll"]