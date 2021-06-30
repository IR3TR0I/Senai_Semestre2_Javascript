--DML

Use Sp_MedicalGroup;
Go

Insert INTO Clinica(nomeClinica,cnpj,razaoSocial,horarioAbre,horarioFecha)
VALUES ('Clínica Dobrevick', '82.683.004/0001-86','SP Medical Group','08:00','19:00'),
		('Clínica Zaneti', '49.449.056/0001-17','SP Medical Group','07:00','20:00');
Go

Insert INTO TiposUsuarios(tituloTipoUsuario)
Values ('Admin'),
		('Médico'),
		('Paciente');
Go

Insert Into Especialidades(tituloEspecialidade)
Values ('Acupuntura'),
	   ('Anestesiologia'),
	   ('Angiologia'),
	   ('Cardiologia'),
	   ('Cirurgia Cardiovascular'),
	   ('Cirurgia da Mão'),
	   ('Cirurgia do Aparelho Digestivo'),
	   ('Cirurgia Geral'),
	   ('Cirurgia Pediátrica'),
	   ('Cirurgia Plástica'),
	   ('Cirurgia Torácica'),
	   ('Cirurgia Vascular'),
	   ('Dermatologia'),
	   ('Radioterapia'),
	   ('Urologia'),
	   ('Pediatria'),
	   ('Psiquiatria');
Go

Insert Into Situacao(descricaoSituacao)
Values ('Agendada'),
	   ('Realizada'),
	   ('Cancelada');
Go

Insert Into Usuarios(IdTipoUsuario,email,Senha)
Values (1, 'saulo@email.com', '46765'),
	   (2, 'paulo@gmail.com', '63694'),
	   (2, 'possarleguol.com', '49985'),
	   (2, 'strada@bol.com', '88963'),
	   (3, 'marini@gmail.com', '47848'),
	   (3, 'luana@gmail.com', '84385'),
	   (3, 'duda@gmail.com', '39737'),
	   (3, 'alan@gmail.com', '47877'),
	   (3, 'samuel@gmail.com', '45679'),
	   (3, 'apolinario@gmail.com.br', '85676'),
	   (3, 'bruno@gmail.com.br', '37676');
Go

Insert Into Pacientes(IdPaciente,nomePaciente,dataNascimento,Telefone,rg,cpf,endereco)
VALUES (5, 'Felipe', '1989/04/10', '(11) 952293024', '10.966.003-1', '137.609.210-78',
	   'Rua Catão, 1292 - São Paulo, SP'),
	   
	   (6, 'Lígia', '1984/04/21', '(11) 958967148', '28.852.394-5', '272.145.460-94',
	   'Rua Mamão, 13 - São Paulo, SP'),
	   
	   (7, 'Alexandre', '1995/05/03', '(11) 968743991', '39.722.788-7', '362.429.020-79',
	   'Rua Laranja, 67 - São Paulo, SP'),
	   
	   (8, 'Fernando', '1998/07/29', '(11) 946430571', '14.063.669-9', '803.507.610-86',
	   'Rua Pêssego, 900 - São Paulo, SP'),
	   
	   (9, 'Henrique', '2002/06/22', '(11) 984128782', '19.034.884-7', '291.103.270-53',
	   'Rua Limão, 17 - São Paulo, SP'),
	   
	   (10, 'João', '1992/11/01', '(11) 982495141', '34.956.993-9', '488.508.790-24',
	   'Rua Melancia, 69 - São Paulo, SP'),
	   
	   (11, 'Bruno', '2000/10/09', '(11) 998263442', '15.401.369-9', '244.725.910-73',
	   'Rua Morango, 77 - São Paulo, SP');
Go

Insert into Medicos(IdClinica,IdEspecialidade,IdUsuario,nomeMedico,crm)
Values (2,13,2, 'Ricardo Lemos', '7886-4/SP'),
		(1,16,5, 'Roberto Possarle','9743-9/SP'),
		(2,8,9, 'Helena Strada','8833-5/SP');
Go

Insert Into Consultas(IdMedico,IdPaciente,IdSituacao,dataConsulta,descricao)
Values (1,1,2, '2021/10/22', 'Aplicar anestesia'),
		(1,2,1, '2021/10/22', 'Ver Braço'),
		(3,7,2, '2021/10/22', 'Remédio'),
		(3,6,2, '2021/10/22', 'Consulta'),
		(3,4,1, '2021/10/22', 'Atendimento'),
		(2,5,1, '2021/10/22', 'Cirurgia'),
		(2,8,3, '2021/10/22', 'Consulta');
