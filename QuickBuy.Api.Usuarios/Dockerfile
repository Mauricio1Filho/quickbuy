FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
RUN apt-get update -yq \
    && apt-get install curl gnupg -yq \
    && curl -sL https://deb.nodesource.com/setup_10.x | bash \
    && apt-get install nodejs -yq
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
RUN apt-get update -yq \
    && apt-get install curl gnupg -yq \
    && curl -sL https://deb.nodesource.com/setup_10.x | bash \
    && apt-get install nodejs -yq
WORKDIR /src

RUN npm install
RUN npm run build -- --prod


COPY ["netcore-angular-docker/netcore-angular-docker.csproj", "netcore-angular-docker/"]

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
ENTRYPOINT ["dotnet", "QuickBuy.Web.dll"]