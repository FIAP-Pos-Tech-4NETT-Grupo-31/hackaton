-- Criação do banco de dados AgendaMedica
CREATE DATABASE AgendaMedica;
GO

-- Seleciona o banco de dados AgendaMedica para uso
USE AgendaMedica;
GO

-- Criação da tabela Medico
CREATE TABLE [dbo].[Medico] (
    [Id]           INT            IDENTITY (1, 1) NOT NULL,
    [Nome]         NVARCHAR (100) NOT NULL,
    [Especialidade] NVARCHAR (100) NOT NULL,
    [CRM]          NVARCHAR (20)  NOT NULL,
    [Telefone]     NVARCHAR (20)  NOT NULL,
    [Email]        NVARCHAR (200) NOT NULL,
    [DataCriacao]  DATETIME       NOT NULL DEFAULT GETDATE(),
    CONSTRAINT [PK_Medico] PRIMARY KEY CLUSTERED ([Id] ASC)
);
GO

EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Identificador �nico do m�dico', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Medico', @level2type = N'COLUMN', @level2name = N'Id';
GO

EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Nome completo do m�dico', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Medico', @level2type = N'COLUMN', @level2name = N'Nome';
GO

EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Especialidade m�dica', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Medico', @level2type = N'COLUMN', @level2name = N'Especialidade';
GO

EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Registro CRM do m�dico', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Medico', @level2type = N'COLUMN', @level2name = N'CRM';
GO

-- Criação da tabela Paciente
CREATE TABLE [dbo].[Paciente] (
    [Id]           INT            IDENTITY (1, 1) NOT NULL,
    [Nome]         NVARCHAR (100) NOT NULL,
    [CPF]          CHAR (11)      NOT NULL,
    [DataNascimento] DATE          NOT NULL,
    [Telefone]     NVARCHAR (20)  NOT NULL,
    [Email]        NVARCHAR (200) NOT NULL,
    [DataCriacao]  DATETIME       NOT NULL DEFAULT GETDATE(),
    CONSTRAINT [PK_Paciente] PRIMARY KEY CLUSTERED ([Id] ASC)
);
GO

EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Identificador �nico do paciente', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Paciente', @level2type = N'COLUMN', @level2name = N'Id';
GO

EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'CPF do paciente', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Paciente', @level2type = N'COLUMN', @level2name = N'CPF';
GO

-- Criação da tabela Agenda
CREATE TABLE [dbo].[Agenda] (
    [Id]            INT            IDENTITY (1, 1) NOT NULL,
    [IdMedico]      INT            NOT NULL,
    [IdPaciente]    INT            NOT NULL,
    [DataConsulta]  DATETIME       NOT NULL,
    [Descricao]     NVARCHAR (500) NULL,
    [Status]        NVARCHAR (50)  NOT NULL,
    CONSTRAINT [PK_Agenda] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Agenda_Medico] FOREIGN KEY ([IdMedico]) REFERENCES [dbo].[Medico] ([Id]),
    CONSTRAINT [FK_Agenda_Paciente] FOREIGN KEY ([IdPaciente]) REFERENCES [dbo].[Paciente] ([Id])
);
GO

EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Data e hor�rio da consulta', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Agenda', @level2type = N'COLUMN', @level2name = N'DataConsulta';
GO

-- Medicos
INSERT INTO [dbo].[Medico] ([Nome], [Especialidade], [CRM], [Telefone], [Email]) 
VALUES 
(N'João Silva', N'Cardiologista', N'12345', N'(11) 98765-4321', N'joao@exemplo.com');

INSERT INTO [dbo].[Medico] ([Nome], [Especialidade], [CRM], [Telefone], [Email]) 
VALUES 
(N'Carlos Souza', N'Ortopedista', N'54321', N'(21) 99876-1234', N'carlos@exemplo.com');

INSERT INTO [dbo].[Medico] ([Nome], [Especialidade], [CRM], [Telefone], [Email]) 
VALUES 
(N'Fernanda Lima', N'Ginecologista', N'67890', N'(31) 99567-4321', N'fernanda@exemplo.com');

INSERT INTO [dbo].[Medico] ([Nome], [Especialidade], [CRM], [Telefone], [Email]) 
VALUES 
(N'Roberto Costa', N'Pediatra', N'23456', N'(61) 99123-4567', N'roberto@exemplo.com');

-- Pacientes
INSERT INTO [dbo].[Paciente] ([Nome], [CPF], [DataNascimento], [Telefone], [Email]) 
VALUES 
(N'Maria Oliveira', '12345678901', '1985-02-14', N'(11) 99876-5432', N'maria@exemplo.com');

INSERT INTO [dbo].[Paciente] ([Nome], [CPF], [DataNascimento], [Telefone], [Email]) 
VALUES 
(N'Lucas Pereira', '98765432100', '1992-11-20', N'(21) 98765-8765', N'lucas@exemplo.com');

INSERT INTO [dbo].[Paciente] ([Nome], [CPF], [DataNascimento], [Telefone], [Email]) 
VALUES 
(N'Ana Martins', '45678912300', '1980-06-10', N'(41) 98123-4567', N'ana@exemplo.com');

INSERT INTO [dbo].[Paciente] ([Nome], [CPF], [DataNascimento], [Telefone], [Email]) 
VALUES 
(N'Ricardo Almeida', '32165498700', '1978-01-15', N'(51) 93456-7890', N'ricardo@exemplo.com');

GO