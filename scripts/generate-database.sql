IF NOT EXISTS (SELECT * FROM sys.databases WHERE name = 'AgendaMedica')
BEGIN
    CREATE DATABASE AgendaMedica;
END
GO

USE AgendaMedica;
GO

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'dbo.Medico') AND type in (N'U'))
BEGIN
    -- Criação da tabela Medico
    CREATE TABLE [dbo].[Medico] (
        [Id]           INT            IDENTITY (1, 1) NOT NULL,
        [Nome]         NVARCHAR (100) NOT NULL,
        [Especialidade] NVARCHAR (100) NOT NULL,
        [CRM]          NVARCHAR (20)  NOT NULL,
        [Telefone]     NVARCHAR (20)  NOT NULL,
        [Email]        NVARCHAR (200) NOT NULL,
        [DataCriacao]  DATETIME       NOT NULL DEFAULT GETDATE(),
        [Senha]        NVARCHAR(200)  NOT NULL,
        CONSTRAINT [PK_Medico] PRIMARY KEY CLUSTERED ([Id] ASC)
    );
END
GO

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'dbo.Paciente') AND type in (N'U'))
BEGIN
    CREATE TABLE [dbo].[Paciente] (
        [Id]           INT            IDENTITY (1, 1) NOT NULL,
        [Nome]         NVARCHAR (100) NOT NULL,
        [CPF]          CHAR (11)      NOT NULL,
        [DataNascimento] DATE          NOT NULL,
        [Telefone]     NVARCHAR (20)  NOT NULL,
        [Email]        NVARCHAR (200) NOT NULL,
        [DataCriacao]  DATETIME       NOT NULL DEFAULT GETDATE(),
        [Senha]        NVARCHAR(200)  NOT NULL,
        CONSTRAINT [PK_Paciente] PRIMARY KEY CLUSTERED ([Id] ASC)
    );
END
GO

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'dbo.Agenda') AND type in (N'U'))
BEGIN
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
END
GO

IF NOT EXISTS (SELECT * FROM [dbo].[Medico] WHERE CRM = '12345')
BEGIN
    INSERT INTO [dbo].[Medico] ([Nome], [Especialidade], [CRM], [Telefone], [Email], [Senha]) 
    VALUES (N'João Silva', N'Cardiologista', N'12345', N'(11) 98765-4321', N'joao@exemplo.com', 'am9hbzEyMw=='); -- joao123
END

IF NOT EXISTS (SELECT * FROM [dbo].[Medico] WHERE CRM = '54321')
BEGIN
    INSERT INTO [dbo].[Medico] ([Nome], [Especialidade], [CRM], [Telefone], [Email], [Senha]) 
    VALUES (N'Carlos Souza', N'Ortopedista', N'54321', N'(21) 99876-1234', N'carlos@exemplo.com', 'Y2FybG9zMTIz'); -- carlos123
END

IF NOT EXISTS (SELECT * FROM [dbo].[Medico] WHERE CRM = '67890')
BEGIN
    INSERT INTO [dbo].[Medico] ([Nome], [Especialidade], [CRM], [Telefone], [Email], [Senha]) 
    VALUES (N'Fernanda Lima', N'Ginecologista', N'67890', N'(31) 99567-4321', N'fernanda@exemplo.com', 'ZmVybmFuZGExMjM='); -- fernanda123
END

IF NOT EXISTS (SELECT * FROM [dbo].[Medico] WHERE CRM = '23456')
BEGIN
    INSERT INTO [dbo].[Medico] ([Nome], [Especialidade], [CRM], [Telefone], [Email], [Senha]) 
    VALUES (N'Roberto Costa', N'Pediatra', N'23456', N'(61) 99123-4567', N'roberto@exemplo.com', 'cm9iZXJ0bzEyMw=='); -- roberto123
END

IF NOT EXISTS (SELECT * FROM [dbo].[Paciente] WHERE CPF = '12345678901')
BEGIN
    INSERT INTO [dbo].[Paciente] ([Nome], [CPF], [DataNascimento], [Telefone], [Email], [Senha]) 
    VALUES (N'Maria Oliveira', '12345678901', '1985-02-14', N'(11) 99876-5432', N'maria@exemplo.com', 'bWFyaWExMjM='); -- maria123
END

IF NOT EXISTS (SELECT * FROM [dbo].[Paciente] WHERE CPF = '98765432100')
BEGIN
    INSERT INTO [dbo].[Paciente] ([Nome], [CPF], [DataNascimento], [Telefone], [Email], [Senha]) 
    VALUES (N'Lucas Pereira', '98765432100', '1992-11-20', N'(21) 98765-8765', N'lucas@exemplo.com', 'bHVjYXMxMjM='); -- lucas123
END

IF NOT EXISTS (SELECT * FROM [dbo].[Paciente] WHERE CPF = '45678912300')
BEGIN
    INSERT INTO [dbo].[Paciente] ([Nome], [CPF], [DataNascimento], [Telefone], [Email], [Senha]) 
    VALUES (N'Ana Martins', '45678912300', '1980-06-10', N'(41) 98123-4567', N'ana@exemplo.com', 'YW5hMTIz'); -- ana123
END

IF NOT EXISTS (SELECT * FROM [dbo].[Paciente] WHERE CPF = '32165498700')
BEGIN
    INSERT INTO [dbo].[Paciente] ([Nome], [CPF], [DataNascimento], [Telefone], [Email], [Senha]) 
    VALUES (N'Ricardo Almeida', '32165498700', '1978-01-15', N'(51) 93456-7890', N'ricardo@exemplo.com', 'cmljYXJkbzEyMw=='); -- ricardo123
END
GO
