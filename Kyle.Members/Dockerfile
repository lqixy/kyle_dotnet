FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

#FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
#WORKDIR /src
#COPY ["Kyle.Members/Kyle.Members.csproj", "Kyle.Members/"]
#COPY ["Kyle.Common/Kyle.Common.csproj", "Kyle.Common/"]
#COPY ["Kyle.Extensions/Kyle.Extensions.csproj", "Kyle.Extensions/"]
#COPY ["Kyle.DependencyAutofac/Kyle.DependencyAutofac.csproj", "Kyle.DependencyAutofac/"]
#COPY ["Kyle.LoggerSerilog/Kyle.LoggerSerilog.csproj", "Kyle.LoggerSerilog/"]
#COPY ["Kyle.Members.Application/Kyle.Members.Application.csproj", "Kyle.Members.Application/"]
#COPY ["Kyle.Encrypt.Application.Constructs/Kyle.Encrypt.Application.Constructs.csproj", "Kyle.Encrypt.Application.Constructs/"]
#COPY ["Kyle.Members.Application.Constructs/Kyle.Members.Application.Constructs.csproj", "Kyle.Members.Application.Constructs/"]
#COPY ["Kyle.Infrastructure.Mapper/Kyle.Infrastructure.Mapper.csproj", "Kyle.Infrastructure.Mapper/"]
#COPY ["Kyle.Scores.Domain/Kyle.Scores.Domain.csproj", "Kyle.Scores.Domain/"]
#COPY ["Kyle.Members.Domain/Kyle.Members.Domain.csproj", "Kyle.Members.Domain/"]
#COPY ["Kyle.EntityFrameworkExtensions/Kyle.EntityFrameworkExtensions.csproj", "Kyle.EntityFrameworkExtensions/"]
#COPY ["Kyle.Infrastructure.Mediators/Kyle.Infrastructure.Mediators.csproj", "Kyle.Infrastructure.Mediators/"]
#COPY ["Kyle.Infrastructure.CAP/Kyle.Infrastructure.CAP.csproj", "Kyle.Infrastructure.CAP/"]
#COPY ["Kyle.Infrastructure.Events/Kyle.Infrastructure.Events.csproj", "Kyle.Infrastructure.Events/"]
#COPY ["Kyle.Identity.Application/Kyle.IdentityClient.csproj", "Kyle.Identity.Application/"]
#COPY ["Kyle.Identity.Application.Constructs/Kyle.IdentityClient.Constructs.csproj", "Kyle.Identity.Application.Constructs/"]
#COPY ["Kyle.Encrypt.Application/Kyle.Encrypt.Application.csproj", "Kyle.Encrypt.Application/"]
#COPY ["Kyle.Infrastructure.Secrets/Kyle.Infrastructure.Secrets.csproj", "Kyle.Infrastructure.Secrets/"]
#COPY ["Kyle.Members.EntityFramework/Kyle.Members.EntityFramework.csproj", "Kyle.Members.EntityFramework/"]
#COPY ["Kyle.Mall.Context/Kyle.Mall.Context.csproj", "Kyle.Mall.Context/"]
#COPY ["Kyle.Infrastructure.ConsulFramework/Kyle.Infrastructure.ConsulFramework.csproj", "Kyle.Infrastructure.ConsulFramework/"]
#RUN dotnet restore "Kyle.Members/Kyle.Members.csproj"
COPY . .
#WORKDIR "/src/Kyle.Members"
#RUN dotnet build "Kyle.Members.csproj" -c Release -o /app/build
#
#FROM build AS publish
#RUN dotnet publish "Kyle.Members.csproj" -c Release -o /app/publish
#
#FROM base AS final
#WORKDIR /app
#COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Kyle.Members.dll"]
