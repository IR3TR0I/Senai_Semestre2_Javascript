--DQL

USE SP_MedicalGroups;
GO

SELECT * FROM tipoUsuarios;

SELECT * FROM usuarios

SELECT * FROM prontuarios;

SELECT * FROM medicos;

SELECT * FROM especialidades;

SELECT * FROM clinicas;

SELECT * FROM Situa��es;

SELECT * FROM consultas;

--FUN��ES

SELECT tituloTipoUsuario AS TipoUsuario, email AS Email FROM tipoUsuarios
	INNER JOIN usuarios
	ON tipoUsuarios.idTipoUsuario = usuarios.idTipoUsuario;

	SELECT nomeProntuario AS Paciente, nomeMedico AS M�dico, titulosEspecialidades AS Especialidade, dataConsulta AS DiaAgendamento, DataConsulta AS HoraAgendamento, tituloSitua��o AS Situa��o FROM consultas
	INNER JOIN prontuarios
	ON consultas.idProntuario = prontuarios.idProntuario
	INNER JOIN medicos
	ON consultas.idMedico = medicos.idMedico
	INNER JOIN especialidades
	ON especialidades.idEspecialidade = medicos.IdEspecialidades
	INNER JOIN Situa��es
	ON consultas.IdSitua��o = Situa��es.IdSitua��o;

	SELECT nomeFantasia, razaoSocial, cnpj, endere�o, HorarioFuncionamento, HorarioFechamento FROM clinicas;

	SELECT nomeMedico AS M�dico, nomeProntuario AS Prontu�rio,Relatorio AS Relatorio, dataConsulta AS DataAgendamento, DataConsulta AS HoraAgendamento, tituloSitua��o AS Agendamento FROM medicos
	INNER JOIN consultas
	ON medicos.idMedico = consultas.idMedico
	INNER JOIN prontuarios
	ON consultas.idProntuario = prontuarios.idProntuario
	INNER JOIN Situa��es
	ON consultas.IdSitua��o = Situa��es.IdSitua��o
	WHERE medicos.idMedico = 2; 

	SELECT nomeProntuario AS Prontu�rio, nomeMedico AS M�dico, Relatorio AS Relatorio, dataConsulta AS DataAgendamento, DataConsulta AS HoraAgendamento, tituloSitua��o AS Agendamento FROM medicos
	INNER JOIN consultas
	ON medicos.idMedico = consultas.idMedico
	INNER JOIN prontuarios
	ON consultas.idProntuario = prontuarios.idProntuario
	INNER JOIN Situa��es
	ON consultas.IdSitua��o = Situa��es.IdSitua��o
	WHERE prontuarios.idProntuario = 7;

	--Login
	SELECT tituloTipoUsuario AS TipoUsuario, email AS Emails, senha AS Senhas FROM usuarios
	INNER JOIN tipoUsuarios
	ON usuarios.idTipoUsuario = tipoUsuarios.idTipoUsuario
	WHERE email = 'adm@adm.com' AND senha = 'adm123';

	--capacidades

	SELECT COUNT (usuarios.idUsuario) AS QtdUsuarios FROM usuarios;

	SELECT nomeProntuario AS Nomes, CONVERT (VARCHAR, dataNascimento, 101) AS DataNascimento FROM prontuarios;

	SELECT nomeProntuario AS Nomes, DATEDIFF(HOUR, dataNascimento,GETDATE())/8766 AS Idades FROM prontuarios;


	SELECT prontuarios.nomeProntuario, prontuarios.dataNascimento,
	CASE 
	WHEN DATEPART(MONTH, prontuarios.dataNascimento) <= DATEPART(MONTH, GETDATE()) 
	AND DATEPART(DAY, prontuarios.dataNascimento) <= DATEPART(DAY, GETDATE())
	THEN (DATEDIFF(YEAR, prontuarios.dataNascimento,GETDATE()))
	ELSE (DATEDIFF(YEAR, prontuarios.dataNascimento,GETDATE())) - 1 
	END AS IdadeAtual
	FROM prontuarios
	WHERE prontuarios.idProntuario = 7


	SELECT prontuarios.nomeProntuario, prontuarios.dataNascimento,
	DATEDIFF(YEAR, prontuarios.dataNascimento,GETDATE()) AS IdadeAtual
	FROM prontuarios;

	CREATE FUNCTION QntdMedicos(@idEspecialidade VARCHAR(200))
		AS 
		BEGIN 
			DECLARE @qntd AS INT 
			SET @qntd = 
			(
			SELECT COUNT(nomeMedico) FROM medicos 
			INNER JOIN especialidades 
			ON medicos.IdEspecialidades = especialidades.idEspecialidade
			WHERE especialidades.titulosEspecialidades = IdEspecialidade 
			)
			RETURN @qntd 
		END
		GO

		SELECT qntd = dbo.QntdMedicos('Psiquiatria');

		SELECT dbo.QntdMedicos('Psiquiatria') AS QuantidadeMedicos;

		--STORED PROCEDURE

			CREATE PROCEDURE CalcularIdadeTodos
		AS
		SELECT prontuarios.nomeProntuario, prontuarios.dataNascimento,
		DATEDIFF(YEAR, prontuarios.dataNascimento,GETDATE()) AS IdadeAtual
		FROM prontuarios;
		GO

		EXECUTE CalcularIdadeTodos;

		CREATE PROCEDURE CalcularIdadeEspecifica(@nomeProntuario VARCHAR(100))
		AS
		SELECT prontuarios.nomeProntuario, prontuarios.dataNascimento,
		DATEDIFF(YEAR, prontuarios.dataNascimento,GETDATE()) AS IdadeAtual
		FROM prontuarios
		WHERE prontuarios.nomeProntuario = @nomeProntuario;
		GO

		EXECUTE CalcularIdadeEspecifica @nomeProntuario = 'Mariana';