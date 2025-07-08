# Build aþamasý
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src

# Proje dosyalarýný kopyala
COPY . .

# Projeyi publish et
RUN dotnet publish "CommentApp-Web.csproj" -c Release -o /app/publish

# Runtime aþamasý
FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS final
WORKDIR /app
COPY --from=build /app/publish .

# PORT ortam deðiþkenini kullanarak dinle
ENV ASPNETCORE_URLS=http://+:$PORT

# Uygulama baþlatma komutu
ENTRYPOINT ["dotnet", "CommentApp-Web.dll"]
