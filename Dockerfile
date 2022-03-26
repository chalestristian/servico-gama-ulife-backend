#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
RUN apt-get update && apt-get install -y apt-utils libgdiplus libc6-dev
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["servico-gama-ulife/servico-gama-ulife.csproj", "servico-gama-ulife/"]
RUN dotnet restore "servico-gama-ulife/servico-gama-ulife.csproj"
COPY . .
WORKDIR "/src/servico-gama-ulife"
RUN dotnet build "servico-gama-ulife.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "servico-gama-ulife.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

RUN useradd -m myappuser
USER myappuser

CMD ASPNETCORE_URLS="http://*:$PORT" dotnet servico-gama-ulife.dll