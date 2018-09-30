FROM microsoft/dotnet:2.1.3-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80

FROM build-threax AS build
WORKDIR /src
COPY Threax.Static/Threax.Static.csproj Threax.Static/
RUN dotnet restore Threax.Static/Threax.Static.csproj
COPY . .
WORKDIR /src/Threax.Static
RUN dotnet build Threax.Static.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish Threax.Static.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Threax.Static.dll"]
