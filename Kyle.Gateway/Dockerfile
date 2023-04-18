FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

#FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
#WORKDIR /src
#COPY ["Kyle.Gateway/Kyle.Gateway.csproj", "Kyle.Gateway/"]
#RUN dotnet restore "Kyle.Gateway/Kyle.Gateway.csproj"
COPY . .
#WORKDIR "/src/Kyle.Gateway"
#RUN dotnet build "Kyle.Gateway.csproj" -c Release -o /app/build
#
#FROM build AS publish
#RUN dotnet publish "Kyle.Gateway.csproj" -c Release -o /app/publish
#
#FROM base AS final
#WORKDIR /app
#COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Kyle.Gateway.dll"]
