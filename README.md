# Banco de dados (SQL Server)

- Executar o comando  `docker-compose up -d`
- Para alterar e recriar o container `docker-compose up --build`
- Para remover o container `docker-compose down`

- Conexão
    - User = SA
    - Password = Teste123!
    - Database = AgendaMedica
    - Server = localhost

- Connection String
```
"ConnectionStrings": {
  "DefaultConnection": "Server=localhost;   Database=AgendaMedica;User Id=SA;Password=Teste123!;TrustServerCertificate=True"
}
```


# Estrutura do projeto
```
hackaton
│
├── hackaton.Domain
│   ├── Entities
│   ├── ValueObjects
│   └── Repositories (Interfaces)
│
├── hackaton.Application
│   ├── Services
│   ├── DTOs
│   └── Commands/Queries
│
├── hackaton.Infrastructure
│   ├── Data
│   ├── Repositories
│   └── Configurations
│
├── hackaton.API
│   ├── Controllers
│   ├── Models
│   └── Program.cs
│
└── hackaton.sln
```

# Execução em Modo Release
No modo release, além de subir o banco de dados, o docker-compose-release.yml está sendo usado para recuperar e executar a imagem do projeto WebAPI que foi publicada no GitHub Packages.

```$ docker-compose -p hackaton-release -f .\docker-compose-release.yml up -d ```

# Envio de Emails
- Para enviar emails é necessário configurar o arquivo `appsettings.json` do projeto WebAPI com as credenciais do email que será utilizado para enviar os emails.
- Foi criada uma conta no Serviço Mailtrap.io para testes, as credenciais já estão configuradas no arquivo `appsettings.json` no repositório.