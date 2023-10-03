FROM mcr.microsoft.com/dotnet/core/aspnet:3.0-stretch-slim@sha256:3e789ab1ababf846fbfb07521f7b3e8fe351d1e2b63d0192624b150e0acce25d AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch@sha256:db9b38d066fdbdd5ac5ce862076c27e4ae17f2b57cbacd03bdc3b24e06696ae8 AS build-env
WORKDIR /app
COPY ListeningPostApiServer.csproj ./
RUN dotnet restore
COPY . ./
RUN dotnet publish -c Release -o out

FROM base AS final
WORKDIR /app
COPY --from=build-env /app/out .
ENTRYPOINT ["dotnet", "ListeningPostApiServer.dll"]
