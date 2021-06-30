--DDl
Create Database Sp_MedicalGroup
Go

Use Sp_MedicalGroup;
Go

--Criando Tabelas

Create Table Clinica (
	IdClinica INT PRIMARY KEY IDENTITY,
	nomeClinica Varchar(200) UNIQUE NOT NULL,
	cnpj Char(60) UNIQUE NOT NULL,
	razaoSocial VARCHAR(100) not null,
	horarioAbre Time,
	horarioFecha Time,
);
Go

Create Table TiposUsuarios (
	IdTipoUsuario INT PRIMARY KEY IDENTITY,
	tituloTipoUsuario VARCHAR(100) UNIQUE NOT NULL,
);
Go

Create Table Especialidades (
	IdEspecialidade INT PRIMARY KEY IDENTITY,
	tituloEspecialidade VARCHAR(100) UNIQUE NOT NULL,
);
Go

Create Table Situacao (
	IdSituacao INT PRIMARY KEY IDENTITY,
	descricaoSituacao VARCHAR(100) UNIQUE NOT NULL
);
Go

Create Table Usuarios (
	IdUsuario INT PRIMARY KEY IDENTITY,
	IdTipoUsuario INT FOREIGN KEY REFERENCES TiposUsuarios(IdTipoUsuario),
	email VarCHAR(100) UNIQUE NOT NULL,
	Senha VARCHAR(50) NOT NULL
);
Go


Create Table Pacientes (
	IdPaciente INT PRIMARY KEY IDENTITY,
	IdUsuario INT FOREIGN KEY References Usuarios(IdUsuario),
	nomePaciente VARCHAR(100) NOT NULL,
	dataNascimento DATE Not NULL,
	Telefone VARCHAR(40) NOT NULL,
	rg CHAR(30) UNIQUE NOT NULL,
	cpf CHAR(50) UNIQUE NOT NULL,
	endereco VARCHAR(200)
);
Go

Create Table Medicos (
	IdMedico INT PRIMARY KEY IDENTITY,
	IdClinica INT FOREIGN KEY REFERENCES Clinica (IdClinica),
	IdEspecialidade INT FOREIGN KEY REFERENCES Especialidades(IdEspecialidade),
	IdUsuario INT FOREIGN KEY REFERENCES Usuarios(IdUsuario),
	nomeMedico VARCHAR(100) NOT NULL,
	crm VARCHAR(40) UNIQUE NOT NULL
);
Go

Create Table Consultas (
	IdConsulta INT PRIMARY KEY IDENTITY,
	IdMedico INT FOREIGN KEY REFERENCES Medicos(IdMedico),
	IdPaciente INT FOREIGN KEY REFERENCES Pacientes(IdPaciente),
	IdSituacao INT FOREIGN KEY REFERENCES Situacao(IdSituacao),
	dataConsulta Date NOT NULL,
	descricao TEXT NOT NULL
);
Go