FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim@sha256:ae9a94a778b4c4656f036e1dd858d6c972f6ad4423bdf9c5022e16f28fee5cf9 AS base
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
