use LeituraArquivoTexto

CREATE TABLE TB_CLIENTES
(
	CLIENTE_ID INT PRIMARY KEY IDENTITY(1,1),
	NOME VARCHAR(30),
	ENDERECO VARCHAR(50),
	TELEFONE VARCHAR(15)
)

--C:\Users\thiag\source\repos\ConsoleApp.LeituraArquivoTexto\ConsoleApp.LeituraArquivoTexto\Arquivos\arquivo.txt