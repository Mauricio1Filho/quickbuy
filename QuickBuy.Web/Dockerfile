FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /build

COPY . ./
RUN dotnet restore
RUN dotnet publish  -c RELEASE --self-contained  -r linux-x64 -o src/out 

# build runtime image
FROM mcr.microsoft.com/dotnet/core/runtime:3.1
RUN sed -i 's/CipherString = DEFAULT@SECLEVEL=2/CipherString = DEFAULT@SECLEVEL=1/' /etc/ssl/openssl.cnf
WORKDIR /build
COPY --from=build /build/src/out ./

EXPOSE 80	

ENTRYPOINT ["dotnet", "QuickBuy.Web.dll"]





