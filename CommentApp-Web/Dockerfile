# 1. Build a�amas�
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

COPY . .

# CommentApp-Web klas�r�ne ge�
WORKDIR /src

# Proje dosyas�n�n oldu�u yere girip publish et
RUN dotnet publish "CommentApp-Web/CommentApp-Web.csproj" -c Release -o /app/publish


# 2. Runtime a�amas�
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
COPY --from=build /app/publish .

# Render'�n dinleyece�i port
ENV ASPNETCORE_URLS=http://+:$PORT

ENTRYPOINT ["dotnet", "CommentApp-Web.dll"]
