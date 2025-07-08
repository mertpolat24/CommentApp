# 1. Build aþamasý
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

COPY . .

# CommentApp-Web klasörüne geç
WORKDIR /src

# Proje dosyasýnýn olduðu yere girip publish et
RUN dotnet publish "CommentApp-Web/CommentApp-Web.csproj" -c Release -o /app/publish


# 2. Runtime aþamasý
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
COPY --from=build /app/publish .

# Render'ýn dinleyeceði port
ENV ASPNETCORE_URLS=http://+:$PORT

ENTRYPOINT ["dotnet", "CommentApp-Web.dll"]
