FROM microsoft/dotnet:2.2-sdk-alpine AS build-env
WORKDIR /app

# Copiar csproj e restaurar dependencias
COPY . ./
RUN dotnet restore
RUN dotnet publish -c RELEASE --self-contained  -r linux-x64 -o out

# Build da aplicacao
COPY . ./
RUN dotnet publish -c Release -o out

# Build da imagem
FROM microsoft/dotnet:2.2-aspnetcore-runtime-alpine

RUN sed -i 's/CipherString = DEFAULT@SECLEVEL=2/CipherString = DEFAULT@SECLEVEL=1/' /etc/ssl/openssl.cnf

WORKDIR /app

COPY --from=build-env /app/out .

EXPOSE 80	

ENTRYPOINT ["dotnet", "QuickBuy.Api.Usuarios.dll"]