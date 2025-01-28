# Banco de dados (SQL Server)

- Executar o comando  `docker-compose up -d`
- Para alterar e recriar o container `docker-compose up --build`
- Para remover o container `docker-compose down`

- Conexão
    - User = SA
    - Password = Grupo#31
    - Database = HealthAndMed
    - Server = localhost

- Connection String
```
"ConnectionStrings": {
  "DefaultConnection": "Server=localhost;   Database=HealthAndMed;User Id=SA;Password=Grupo#31;TrustServerCertificate=True"
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