# Etapa 1: Base com runtime do .NET
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app

# Copia apenas os arquivos publicados do build
COPY ./out ./

# Expõe as portas padrão do ASP.NET Core
EXPOSE 80
EXPOSE 443

# Comando de inicialização
ENTRYPOINT ["dotnet", "WebAPI.dll"]