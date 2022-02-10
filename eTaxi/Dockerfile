FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS base
ENV TZ=Europe/Berlin
RUN ln -snf /usr/share/zoneinfo/$TZ /etc/localtime && echo $TZ > /etc/timezone
WORKDIR /app
EXPOSE 61875
EXPOSE 61874
EXPOSE 80
EXPOSE 443
EXPOSE 3000
EXPOSE 5000
EXPOSE 5001
RUN mkdir Resources
RUN mkdir Images
FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["eTaxi/eTaxi.csproj", "eTaxi/"]
COPY ["Model/Model.csproj", "Model/"]
COPY ["Domain/Domain.csproj", "Domain/"]
COPY ["Application/Application.csproj", "Application/"]
COPY ["Persistence/Persistence.csproj", "Persistence/"]
COPY ["Infrastructure/Infrastructure.csproj", "Infrastructure/"]
RUN dotnet restore "eTaxi/eTaxi.csproj"
COPY . .
WORKDIR "/src/eTaxi"
RUN dotnet build "eTaxi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "eTaxi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "./eTaxi.dll"]