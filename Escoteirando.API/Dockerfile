FROM node:alpine as frontend

RUN yarn global add @quasar/cli

WORKDIR /app

COPY frontend/quasar.conf.js /app/
COPY frontend/package.json /app/

RUN yarn install

COPY frontend/ /app
ENV DIST_DIR=/dist
RUN quasar build

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Escoteirando.API/Escoteirando.API.csproj", "Escoteirando.API/"]
RUN dotnet restore "Escoteirando.API/Escoteirando.API.csproj"
COPY . .
WORKDIR "/src/Escoteirando.API"
#COPY --from=frontend /dist ./wwwroot
RUN dotnet build "Escoteirando.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Escoteirando.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Escoteirando.API.dll"]
