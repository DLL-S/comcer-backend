#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["DLLS.Comcer.API/DLLS.Comcer.API.csproj", "DLLS.Comcer.API/"]
RUN dotnet restore "DLLS.Comcer.API/DLLS.Comcer.API.csproj"
COPY . .
WORKDIR "/src/DLLS.Comcer.API"
RUN dotnet build "DLLS.Comcer.API.csproj" -c Release -o /app/build

WORKDIR /src
COPY ["DLLS.Comcer.Dominio/DLLS.Comcer.Dominio.csproj", "DLLS.Comcer.Dominio/"]
RUN dotnet restore "DLLS.Comcer.Dominio/DLLS.Comcer.Dominio.csproj"
COPY . .
WORKDIR "/src/DLLS.Comcer.Dominio"
RUN dotnet build "DLLS.Comcer.Dominio.csproj" -c Release -o /app/build

WORKDIR /src
COPY ["DLLS.Comcer.Infraestrutura/DLLS.Comcer.Infraestrutura.csproj", "DLLS.Comcer.Infraestrutura/"]
RUN dotnet restore "DLLS.Comcer.Infraestrutura/DLLS.Comcer.Infraestrutura.csproj"
COPY . .
WORKDIR "/src/DLLS.Comcer.Infraestrutura"
RUN dotnet build "DLLS.Comcer.Infraestrutura.csproj" -c Release -o /app/build

WORKDIR /src
COPY ["DLLS.Comcer.Interfaces/DLLS.Comcer.Interfaces.csproj", "DLLS.Comcer.Interfaces/"]
RUN dotnet restore "DLLS.Comcer.Interfaces/DLLS.Comcer.Interfaces.csproj"
COPY . .
WORKDIR "/src/DLLS.Comcer.Interfaces"
RUN dotnet build "DLLS.Comcer.Interfaces.csproj" -c Release -o /app/build

WORKDIR /src
COPY ["DLLS.Comcer.Negocio/DLLS.Comcer.Negocio.csproj", "DLLS.Comcer.Negocio/"]
RUN dotnet restore "DLLS.Comcer.Negocio/DLLS.Comcer.Negocio.csproj"
COPY . .
WORKDIR "/src/DLLS.Comcer.Negocio"
RUN dotnet build "DLLS.Comcer.Negocio.csproj" -c Release -o /app/build


WORKDIR /src
COPY ["DLLS.Comcer.Startup/DLLS.Comcer.Startup.csproj", "DLLS.Comcer.Startup/"]
RUN dotnet restore "DLLS.Comcer.Startup/DLLS.Comcer.Startup.csproj"
COPY . .
WORKDIR "/src/DLLS.Comcer.Startup"
RUN dotnet build "DLLS.Comcer.Startup.csproj" -c Release -o /app/build


WORKDIR /src
COPY ["DLLS.Comcer.Utilitarios/DLLS.Comcer.Utilitarios.csproj", "DLLS.Comcer.Utilitarios/"]
RUN dotnet restore "DLLS.Comcer.Utilitarios/DLLS.Comcer.Utilitarios.csproj"
COPY . .
WORKDIR "/src/DLLS.Comcer.Utilitarios"
RUN dotnet build "DLLS.Comcer.Utilitarios.csproj" -c Release -o /app/build


FROM build AS publish
RUN dotnet publish "DLLS.Comcer.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DLLS.Comcer.API.dll"]