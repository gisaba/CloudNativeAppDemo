
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base

ENV ASPNETCORE_URLS http://*:8080
ENV ASPNETCORE_ENVIRONMENT="Development"
EXPOSE 8080

ENV LD_LIBRARY_PATH="/app/clidriver/lib" 
ENV ASPNETCORE_ENVIRONMENT="Test"
RUN sed -i 's/SECLEVEL=2/SECLEVEL=1/g' /etc/ssl/openssl.cnf

WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
COPY . /src
WORKDIR /src
COPY ["TodoApi/TodoApi.csproj", "TodoApi/"]
RUN dotnet restore "TodoApi/TodoApi.csproj"
COPY . .

WORKDIR "/src/TodoApi"
RUN dotnet build "TodoApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TodoApi.csproj" -c Release -o /app/publish 
#/p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

RUN addgroup --group appgroup --gid 2000

RUN adduser --disabled-password --home /app --gecos '' \
    --uid 1000 \
    --gid 2000 \
    "appuser"

RUN chown -R appuser:appgroup  /app /tmp

USER appuser:appgroup

ENTRYPOINT ["dotnet", "TodoApi.dll"]
