FROM mcr.microsoft.com/dotnet/aspnet:5.0

COPY web /app
WORKDIR /app
ENV ASPNETCORE_URLS=http://*:5000
CMD dotnet Web.dll