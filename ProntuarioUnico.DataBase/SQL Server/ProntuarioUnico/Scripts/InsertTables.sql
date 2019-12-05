USE [ProntuarioUnico]
GO

INSERT INTO dbo.TIPO_DOCUMENTO
           (DS_TIPO_DOCUMENTO)
     VALUES
           ('Carteira de Identidade - RG'),
		   ('Cadastro de Pessoa Física - CPF'),
		   ('Carteira Nacional de Habilitação - CNH'),
		   ('Passaporte'),
		   ('Carteira de Registro Nacional Migratório - CRNM')
GO

INSERT INTO dbo.TIPO_ATENDIMENTO 
			(DS_TIPO_ATENDIMENTO)
	VALUES 
			('Consulta'), 
			('Exame')


INSERT INTO dbo.ESPECIALIDADE_ATENDIMENTO 
			(DS_ESPECIALIDADE)
     VALUES
           ('Dermatologia'),
		   ('Ortopedia'),
		   ('Psiquiatria'),
		   ('Oftalmologia'),
		   ('Cardiologia'),
		   ('Urologia')