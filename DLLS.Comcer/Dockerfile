#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["DLLS.Comcer.sln", "./"]
COPY ["DLLS.Comcer.API/DLLS.Comcer.API.csproj", "DLLS.Comcer.API/"]
COPY ["DLLS.Comcer.Startup/DLLS.Comcer.Startup.csproj", "DLLS.Comcer.Startup/"]
COPY ["DLLS.Comcer.Negocio/DLLS.Comcer.Negocio.csproj", "DLLS.Comcer.Negocio/"]
COPY ["DLLS.Comcer.Dominio/DLLS.Comcer.Dominio.csproj", "DLLS.Comcer.Dominio/"]
COPY ["DLLS.Comcer.Utilitarios/DLLS.Comcer.Utilitarios.csproj", "DLLS.Comcer.Utilitarios/"]
COPY ["DLLS.Comcer.Interfaces/DLLS.Comcer.Interfaces.csproj", "DLLS.Comcer.Interfaces/"]
COPY ["DLLS.Comcer.Infraestrutura/DLLS.Comcer.Infraestrutura.csproj", "DLLS.Comcer.Infraestrutura/"]
RUN dotnet restore
COPY . .

WORKDIR "/src/DLLS.Comcer.Utilitarios"
RUN dotnet build -c Release -o /app/build

WORKDIR "/src/DLLS.Comcer.Interfaces"
RUN dotnet build -c Release -o /app/build

WORKDIR "/src/DLLS.Comcer.Startup"
RUN dotnet build -c Release -o /app/build

WORKDIR "/src/DLLS.Comcer.Dominio"
RUN dotnet build -c Release -o /app/build

WORKDIR "/src/DLLS.Comcer.Infraestrutura"
RUN dotnet build -c Release -o /app/build

WORKDIR "/src/DLLS.Comcer.Negocio"
RUN dotnet build -c Release -o /app/build

WORKDIR "/src/DLLS.Comcer.API"
RUN dotnet build -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "DLLS.Comcer.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
CMD ASPNETCORE_URLS="http://*:$PORT" dotnet DLLS.Comcer.API.dll
ENTRYPOINT ["dotnet", "DLLS.Comcer.API.dll"]
