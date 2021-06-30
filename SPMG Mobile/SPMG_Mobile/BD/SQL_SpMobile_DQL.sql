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

-- mostra todos os tipos de usuários na tabela de usuários
SELECT idUsuario,
	   tituloTipoUsuario [Tipo de Usuário],
	   email
FROM Usuarios
INNER JOIN TiposUsuarios
ON TiposUsuarios.idTipoUsuario = Usuarios.idTipoUsuario

-- exibe os dados dos médicos mostrando qual clínica em que trabalha cada médico e
-- a especialidade de cada médico
SELECT idMedico,
	   nomeMedico [Médico],
	   tituloEspecialidade Especialidade,
	   nomeClinica [Clínica],
	   crm CRM
FROM Medicos M
INNER JOIN Especialidades E
ON M.idEspecialidade = E.idEspecialidade
INNER JOIN Clinica C
ON M.idClinica = C.idClinica;

-- mostra os dados das consultas já agendadas
-- o médico poderá incluir a descrição da consulta que estará vinculada ao paciente
SELECT nomePaciente Paciente,
	   nomeMedico Médico,
	   descricaoSituacao [Situação],
	   dataConsulta [Data da Consulta],
	   descricao [Descrição]
FROM Consultas C
INNER JOIN Pacientes P
ON C.idPaciente = P.idPaciente
INNER JOIN Medicos M
ON C.idMedico = M.idMedico
INNER JOIN Situacao S
ON C.idSituacao = S.idSituacao
WHERE S.idSituacao = 1;

-- médico pode ver as consultas (agendamentos) que são relacionadas a ele
SELECT nomePaciente Paciente,
	   nomeMedico Médico,
	   descricaoSituacao Situação,
	   dataConsulta [Data da Consulta],
	   descricao [Descrição]
FROM Consultas C
INNER JOIN Pacientes P
ON C.idPaciente = P.idPaciente
INNER JOIN Medicos M
ON C.idMedico = M.idMedico
INNER JOIN Situacao S
ON C.idSituacao = S.idSituacao
WHERE C.idMedico = 3;

-- o paciente visualizara as suas próprias consultas
SELECT nomePaciente Paciente,
	   nomeMedico Médico,
	   descricaoSituacao Situação,
	   dataConsulta [Data da Consulta],
	   descricao [Descrição]
FROM Consultas C
INNER JOIN Pacientes P
ON C.idPaciente = P.idPaciente
INNER JOIN Medicos M
ON C.idMedico = M.idMedico
INNER JOIN Situacao S
ON C.idSituacao = S.idSituacao
WHERE P.idPaciente = 7;