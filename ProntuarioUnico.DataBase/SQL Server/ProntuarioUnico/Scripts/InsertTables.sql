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

INSERT INTO [dbo].[PESSOA_FISICA]
           ([NM_PESSOA_FISICA]
           ,[DT_NASCIMENTO]
           ,[DS_TELEFONE]
           ,[CD_TIPO_DOCUMENTO]
           ,[VL_TIPO_DOCUMENTO]
           ,[IE_ATIVO]
           ,[DT_ATUALIZACAO])
     VALUES
           ('André Matias'
           ,'1998-12-25'
           ,'1155322139'
           ,2
           ,'12345695246'
           ,1
           ,GETDATE())
GO

INSERT INTO [dbo].[PESSOA_FISICA]
           ([NM_PESSOA_FISICA]
           ,[DT_NASCIMENTO]
           ,[DS_TELEFONE]
           ,[CD_TIPO_DOCUMENTO]
           ,[VL_TIPO_DOCUMENTO]
           ,[IE_ATIVO]
           ,[DT_ATUALIZACAO])
     VALUES
           ('Robson Mauricio'
           ,'1990-02-13'
           ,'1142316548'
           ,2
           ,'45698725482'
           ,1
           ,GETDATE())
GO

INSERT INTO [dbo].[MEDICO]
           ([CRM_MEDICO]
           ,[CD_PESSOA_FISICA]
           ,[IE_ATIVO]
           ,[DT_ATUALIZACAO])
     VALUES
           (52715573
           ,3
           ,1
           ,GETDATE())
GO

INSERT INTO [dbo].[ATENDIMENTO_PACIENTE]
           ([CD_PESSOA_FISICA]
           ,[CRM_MEDICO]
           ,[ID_TIPO_ATENDIMENTO]
           ,[ID_ESPECIALIDADE]
           ,[DT_ATENDIMENTO]
           ,[DS_OBSERVACAO])
     VALUES
           (2
           ,52715573
           ,1
           ,3
           ,GETDATE()
           ,'Casos de dores abdominais.')
GO

INSERT INTO [dbo].[ATENDIMENTO_PACIENTE]
           ([CD_PESSOA_FISICA]
           ,[CRM_MEDICO]
           ,[ID_TIPO_ATENDIMENTO]
           ,[ID_ESPECIALIDADE]
           ,[DT_ATENDIMENTO]
           ,[DS_OBSERVACAO])
     VALUES
           (2
           ,52715573
           ,2
           ,3
           ,GETDATE()
           ,'Consulta para verificar dores abdominais.')
GO