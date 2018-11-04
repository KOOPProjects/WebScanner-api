FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 52329
EXPOSE 44376

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY ["WebScanner-api/WebScanner-api.csproj", "WebScanner-api/"]
RUN dotnet restore "WebScanner-api/WebScanner-api.csproj"
COPY . .
WORKDIR "/src/WebScanner-api"
RUN dotnet build "WebScanner-api.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "WebScanner-api.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "WebScanner-api.dll"]