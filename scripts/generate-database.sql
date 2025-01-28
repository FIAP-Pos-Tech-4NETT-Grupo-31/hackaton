-- Criação de banco de dados
CREATE DATABASE HealthAndMed;
GO

-- Seleciona o banco criado
USE HealthAndMed;
GO

-- Criação de tabelas
CREATE TABLE Paciente (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Nome NVARCHAR(50) NOT NULL,
    Email NVARCHAR(100) NOT NULL,
    CPF NVARCHAR(11) NOT NULL,
    Senha NVARCHAR(200) NOT NULL
);
GO

-- Inserção de dados iniciais
INSERT INTO Paciente (Nome, Email, CPF, Senha)
VALUES 
('Alice', 'alice@example.com', '11235283062', 'alice123'),
('Bob', 'bob@example.com', '11963593006', 'bob123'),
('Jayme', 'jayme@example.com', '61024690032', 'jayme123'),
('Charles', 'charles@example.com', '20686182065', 'charles123')
GO
