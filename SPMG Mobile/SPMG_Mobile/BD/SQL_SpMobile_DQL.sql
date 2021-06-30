--DQL
Use Sp_MedicalGroup;
Go

Select * From Clinica

SELECT * FROM TiposUsuarios;

SELECT * FROM Usuarios;

SELECT * FROM Pacientes;

SELECT * FROM Especialidades;

SELECT * FROM Medicos;

SELECT * FROM Situacao;

SELECT * FROM Consultas;

-- mostra todos os tipos de usu�rios na tabela de usu�rios
SELECT idUsuario,
	   tituloTipoUsuario [Tipo de Usu�rio],
	   email
FROM Usuarios
INNER JOIN TiposUsuarios
ON TiposUsuarios.idTipoUsuario = Usuarios.idTipoUsuario

-- exibe os dados dos m�dicos mostrando qual cl�nica em que trabalha cada m�dico e
-- a especialidade de cada m�dico
SELECT idMedico,
	   nomeMedico [M�dico],
	   tituloEspecialidade Especialidade,
	   nomeClinica [Cl�nica],
	   crm CRM
FROM Medicos M
INNER JOIN Especialidades E
ON M.idEspecialidade = E.idEspecialidade
INNER JOIN Clinica C
ON M.idClinica = C.idClinica;

-- mostra os dados das consultas j� agendadas
-- o m�dico poder� incluir a descri��o da consulta que estar� vinculada ao paciente
SELECT nomePaciente Paciente,
	   nomeMedico M�dico,
	   descricaoSituacao [Situa��o],
	   dataConsulta [Data da Consulta],
	   descricao [Descri��o]
FROM Consultas C
INNER JOIN Pacientes P
ON C.idPaciente = P.idPaciente
INNER JOIN Medicos M
ON C.idMedico = M.idMedico
INNER JOIN Situacao S
ON C.idSituacao = S.idSituacao
WHERE S.idSituacao = 1;

-- m�dico pode ver as consultas (agendamentos) que s�o relacionadas a ele
SELECT nomePaciente Paciente,
	   nomeMedico M�dico,
	   descricaoSituacao Situa��o,
	   dataConsulta [Data da Consulta],
	   descricao [Descri��o]
FROM Consultas C
INNER JOIN Pacientes P
ON C.idPaciente = P.idPaciente
INNER JOIN Medicos M
ON C.idMedico = M.idMedico
INNER JOIN Situacao S
ON C.idSituacao = S.idSituacao
WHERE C.idMedico = 3;

-- o paciente visualizara as suas pr�prias consultas
SELECT nomePaciente Paciente,
	   nomeMedico M�dico,
	   descricaoSituacao Situa��o,
	   dataConsulta [Data da Consulta],
	   descricao [Descri��o]
FROM Consultas C
INNER JOIN Pacientes P
ON C.idPaciente = P.idPaciente
INNER JOIN Medicos M
ON C.idMedico = M.idMedico
INNER JOIN Situacao S
ON C.idSituacao = S.idSituacao
WHERE P.idPaciente = 7;