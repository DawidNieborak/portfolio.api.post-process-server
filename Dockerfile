﻿FROM mcr.microsoft.com/dotnet/aspnet:5.0
WORKDIR /app

COPY . .
CMD ASPNETCORE_URLS=http://*:$PORT dotnet portfolio.api.core.dll