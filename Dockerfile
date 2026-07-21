FROM node:20-alpine AS client-build
WORKDIR /source/src/PadelTrialSchedule.ClientApp
COPY src/PadelTrialSchedule.ClientApp/package.json src/PadelTrialSchedule.ClientApp/package-lock.json ./
RUN npm ci
COPY src/PadelTrialSchedule.ClientApp/ ./
RUN npm run build

FROM mcr.microsoft.com/dotnet/sdk:10.0-alpine AS dotnet-build
WORKDIR /source
COPY Directory.Build.props Directory.Packages.props global.json ./
COPY src/PadelTrialSchedule.Domain/PadelTrialSchedule.Domain.csproj src/PadelTrialSchedule.Domain/
COPY src/PadelTrialSchedule.Application/PadelTrialSchedule.Application.csproj src/PadelTrialSchedule.Application/
COPY src/PadelTrialSchedule.Infrastructure/PadelTrialSchedule.Infrastructure.csproj src/PadelTrialSchedule.Infrastructure/
COPY src/PadelTrialSchedule.Api/PadelTrialSchedule.Api.csproj src/PadelTrialSchedule.Api/
RUN dotnet restore src/PadelTrialSchedule.Api/PadelTrialSchedule.Api.csproj
COPY src/ ./src/
RUN dotnet publish src/PadelTrialSchedule.Api/PadelTrialSchedule.Api.csproj -c Release --no-restore -o /app/publish
COPY --from=client-build /source/src/PadelTrialSchedule.ClientApp/dist /app/publish/wwwroot

FROM mcr.microsoft.com/dotnet/aspnet:10.0-alpine AS runtime
WORKDIR /app
RUN apk add --no-cache krb5-libs \
    && addgroup -S padel \
    && adduser -S padel -G padel
COPY --from=dotnet-build --chown=padel:padel /app/publish .
USER padel
ENV ASPNETCORE_HTTP_PORTS=8080 \
    DOTNET_EnableDiagnostics=0
EXPOSE 8080
ENTRYPOINT ["dotnet", "PadelTrialSchedule.Api.dll"]
