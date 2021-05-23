#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY Api.Product/Api.Product.csproj Api.Product/
COPY Commons.Product/Commons.Product.csproj Commons.Product/
COPY Config.Product/Config.Product.csproj Config.Product/
COPY Domain.Product/Domain.Product.csproj Domain.Product/
COPY Repository.Product/Repository.Product.csproj Repository.Product/
RUN dotnet restore "Api.Product/Api.Product.csproj"
COPY . .
WORKDIR "/src/Api.Product"
RUN dotnet build "Api.Product.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Api.Product.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Api.Product.dll"]
