#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["src/Studentes.Evaluation.Api/Studentes.Evaluation.Api.csproj", "src/Studentes.Evaluation.Api/"]
RUN dotnet restore "src/Studentes.Evaluation.Api/Studentes.Evaluation.Api.csproj"
COPY . .
WORKDIR "/src/src/Studentes.Evaluation.Api"
RUN dotnet build "Studentes.Evaluation.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Studentes.Evaluation.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Studentes.Evaluation.Api.dll"]