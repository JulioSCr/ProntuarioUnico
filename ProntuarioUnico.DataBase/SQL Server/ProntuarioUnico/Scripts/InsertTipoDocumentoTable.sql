USE [ProntuarioUnico]
GO

INSERT INTO [dbo].[TIPO_DOCUMENTO]
           ([DS_TIPO_DOCUMENTO])
     VALUES
           ('Carteira de Identidade - RG'),
		   ('Cadastro de Pessoa F�sica - CPF'),
		   ('Carteira Nacional de Habilita��o - CNH'),
		   ('Passaporte'),
		   ('Carteira de Registro Nacional Migrat�rio - CRNM')
GO

INSERT INTO TIPO_ATENDIMENTO (DS_TIPO_ATENDIMENTO)
VALUES ('Consulta'), ('Exame')