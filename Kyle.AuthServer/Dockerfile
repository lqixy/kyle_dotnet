FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

#FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
#WORKDIR /src
#COPY ["Kyle.AuthServer/Kyle.AuthServer.csproj", "Kyle.AuthServer/"]
#COPY ["Kyle.Infrastructure.ConsulFramework/Kyle.Infrastructure.ConsulFramework.csproj", "Kyle.Infrastructure.ConsulFramework/"]
#COPY ["Kyle.Extensions/Kyle.Extensions.csproj", "Kyle.Extensions/"]
#COPY ["Kyle.Members.Application/Kyle.Members.Application.csproj", "Kyle.Members.Application/"]
#COPY ["Kyle.Encrypt.Application.Constructs/Kyle.Encrypt.Application.Constructs.csproj", "Kyle.Encrypt.Application.Constructs/"]
#COPY ["Kyle.Members.Application.Constructs/Kyle.Members.Application.Constructs.csproj", "Kyle.Members.Application.Constructs/"]
#COPY ["Kyle.Members.Domain/Kyle.Members.Domain.csproj", "Kyle.Members.Domain/"]
#COPY ["Kyle.EntityFrameworkExtensions/Kyle.EntityFrameworkExtensions.csproj", "Kyle.EntityFrameworkExtensions/"]
#COPY ["Kyle.Infrastructure.Mediators/Kyle.Infrastructure.Mediators.csproj", "Kyle.Infrastructure.Mediators/"]
#COPY ["Kyle.Infrastructure.CAP/Kyle.Infrastructure.CAP.csproj", "Kyle.Infrastructure.CAP/"]
#COPY ["Kyle.Infrastructure.Events/Kyle.Infrastructure.Events.csproj", "Kyle.Infrastructure.Events/"]
#COPY ["Kyle.Identity.Application/Kyle.IdentityClient.csproj", "Kyle.Identity.Application/"]
#COPY ["Kyle.Identity.Application.Constructs/Kyle.IdentityClient.Constructs.csproj", "Kyle.Identity.Application.Constructs/"]
#COPY ["Kyle.Members.EntityFramework/Kyle.Members.EntityFramework.csproj", "Kyle.Members.EntityFramework/"]
#COPY ["Kyle.Encrypt.Application/Kyle.Encrypt.Application.csproj", "Kyle.Encrypt.Application/"]
#COPY ["Kyle.Infrastructure.Secrets/Kyle.Infrastructure.Secrets.csproj", "Kyle.Infrastructure.Secrets/"]
#RUN dotnet restore "Kyle.AuthServer/Kyle.AuthServer.csproj"
COPY . .
#WORKDIR "/src/Kyle.AuthServer"
#RUN dotnet build "Kyle.AuthServer.csproj" -c Release -o /app/build
#
#FROM build AS publish
#RUN dotnet publish "Kyle.AuthServer.csproj" -c Release -o /app/publish
#
#FROM base AS final
#WORKDIR /app
#COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Kyle.AuthServer.dll"]
