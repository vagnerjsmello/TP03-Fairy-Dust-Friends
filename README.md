# TP03 - Fairy Dust Friends ASP.NET

Testes de Proficiência 03 para a disciplina:  Serviços e Microsoft Azure - .NET. Instituto Infnet

### As Tarefas:
- Criar um projeto do tipo ASP.NET Web Application (.NET Framework).
- Criar um projeto do tipo ASP.NET Web API que fornece operações de criação, leitura, atualização e deleção de amigos. 
- Cada amigo deve possuir nome, sobrenome, e-mail, telefone e data de aniversário.
- Essas operações devem ser persistidas em um banco de dados SQL do Azure, onde deve ser criada uma tabela para armazenar os dados de amigos. 
- As operações devem ser implementadas como procedimentos armazenados e devem ser invocados a partir do código em C# na API web.


## ASP.NET Web Api:

#### [Criar banco de dados SQL no Azure](https://docs.microsoft.com/pt-br/azure/sql-database/sql-database-get-started-portal)

#### Rodar script de criação da da tabela FRIENDS e Procedures abaixo:

```sh
CREATE TABLE FRIENDS (
    Id 	UNIQUEIDENTIFIER PRIMARY KEY,
    FirstName VARCHAR(128) NOT NULL,          
    LastName VARCHAR(128) NOT NULL,
    Email VARCHAR(128) NOT NULL,           
    Phone VARCHAR(14) NOT NULL,        
    Birthday DATE NOT NULL
);
GO

CREATE PROCEDURE CreateFriend
	@Id UNIQUEIDENTIFIER,
	@FirstName VARCHAR(128),
	@LastName VARCHAR(128),
	@Email VARCHAR(128),
	@Phone VARCHAR(14), 
	@Birthday DATE
AS
	INSERT INTO FRIENDS (Id,FirstName,LastName,Email,Phone,Birthday)	
	VALUES (@Id,@FirstName,@LastName,@Email,@Phone,@Birthday);
GO


CREATE PROCEDURE ReadFriend
	@Id UNIQUEIDENTIFIER
AS
	SELECT * FROM FRIENDS
	WHERE Id = @Id;
GO

CREATE PROCEDURE UpdateFriend
	@Id UNIQUEIDENTIFIER,
	@FirstName VARCHAR(128),
	@LastName  VARCHAR(128),
	@Email VARCHAR(128),
	@Phone VARCHAR(14), 
	@Birthday DATE
AS
	UPDATE FRIENDS
	SET FirstName = @FirstName,
	LastName = @LastName,
	Email = @Email,
	Phone = @Phone,
	Birthday = @Birthday
	WHERE Id = @Id;
GO

CREATE PROCEDURE DeleteFriend
	@Id UNIQUEIDENTIFIER
AS
	DELETE FROM FRIENDS
	WHERE Id = @Id;
GO;

CREATE PROCEDURE ReadAllFriend
AS
	SELECT * FROM FRIENDS
GO
```

#### Após criar seu banco de dados SQL e rodar o script, substituir {Your Azure Database Connection String} pela sua string de conexão no arquivo web.config

```sh
<!-- Azure Database Connection String -->
<add name="AzureDatabaseConnectionString" connectionString="{Your Azure Database Connection String}" providerName="System.Data.SqlClient" />
```

## ASP.NET Web App:

#### Substituir {Your Api Azure here} pelo seu endereço Web Api Azure no arquivo web.config

```sh
<!-- URI Api Azure. Exemple: https://webapifriends.azurewebsites.net -->
<add key="AzureUriApi" value="{Your Api Azure here}"/>   
```
