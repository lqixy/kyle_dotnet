FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

#FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
#WORKDIR /src
#COPY ["Kyle.Weather/Kyle.Weather.csproj", "Kyle.Weather/"]
#COPY ["Kyle.Infrastructure.IdentityServer/Kyle.Infrastructure.IdentityServer.csproj", "Kyle.Infrastructure.IdentityServer/"]
#COPY ["Kyle.LoggerSerilog/Kyle.LoggerSerilog.csproj", "Kyle.LoggerSerilog/"]
#COPY ["Kyle.Infrastructure.ConsulFramework/Kyle.Infrastructure.ConsulFramework.csproj", "Kyle.Infrastructure.ConsulFramework/"]
#COPY ["Kyle.DependencyAutofac/Kyle.DependencyAutofac.csproj", "Kyle.DependencyAutofac/"]
#COPY ["Kyle.Extensions/Kyle.Extensions.csproj", "Kyle.Extensions/"]
#COPY ["Kyle.Infrastructure.RedisExtensions/Kyle.Infrastructure.RedisExtensions.csproj", "Kyle.Infrastructure.RedisExtensions/"]
#COPY ["Kyle.Weather.ApiClients.Repository/Kyle.Weather.ApiClients.Repository.csproj", "Kyle.Weather.ApiClients.Repository/"]
#COPY ["Kyle.Weather.ApiClients/Kyle.Weather.ApiClients.csproj", "Kyle.Weather.ApiClients/"]
#COPY ["Kyle.ApiClients.Domain/Kyle.ApiClients.Domain.csproj", "Kyle.ApiClients.Domain/"]
#COPY ["Kyle.Weather.Domain.Shared/Kyle.Weather.Domain.Shared.csproj", "Kyle.Weather.Domain.Shared/"]
#COPY ["Kyle.Weather.Application/Kyle.Weather.Application.csproj", "Kyle.Weather.Application/"]
#COPY ["Kyle.Weather.Application.Constructs/Kyle.Weather.Application.Constructs.csproj", "Kyle.Weather.Application.Constructs/"]
#COPY ["Kyle.ApiClients.Repositories/Kyle.ApiClients.Repositories.csproj", "Kyle.ApiClients.Repositories/"]
#RUN dotnet restore "Kyle.Weather/Kyle.Weather.csproj"
COPY . .
#WORKDIR "/src/Kyle.Weather"
#RUN dotnet build "Kyle.Weather.csproj" -c Release -o /app/build
#
#FROM build AS publish
#RUN dotnet publish "Kyle.Weather.csproj" -c Release -o /app/publish

#FROM base AS final
#WORKDIR /app
#COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Kyle.Weather.dll"]
