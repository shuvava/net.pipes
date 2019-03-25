FROM microsoft/dotnet:2.2-aspnetcore-runtime-stretch-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM microsoft/dotnet:2.2-sdk-stretch AS build
WORKDIR /src
COPY ["src/WebApp.Stream.Service/WebApp.Stream.Service.csproj", "src/WebApp.Stream.Service/"]
RUN dotnet restore "src/WebApp.Stream.Service/WebApp.Stream.Service.csproj"
COPY . .
WORKDIR "/src/src/WebApp.Stream.Service"
RUN dotnet build "WebApp.Stream.Service.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "WebApp.Stream.Service.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "WebApp.Stream.Service.dll"]