#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["DLLS.Comcer.APIa/DLLS.Comcer.APIa.csproj", "DLLS.Comcer.APIa/"]
RUN dotnet restore "DLLS.Comcer.APIa/DLLS.Comcer.APIa.csproj"
COPY . .
WORKDIR "/src/DLLS.Comcer.APIa"
RUN dotnet build "DLLS.Comcer.APIa.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "DLLS.Comcer.APIa.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DLLS.Comcer.APIa.dll"]