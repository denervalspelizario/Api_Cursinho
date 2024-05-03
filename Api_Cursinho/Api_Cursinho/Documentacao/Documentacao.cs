/*
   PASSO A PASSO CRIACAO E DESENVOLVIMENTO API CURSINHO
 
   [1] Criei o banco de dados direto no postgres e as tabelas
 
   [2] Criacao na pasta Models os models que vão linkar com as tabelas criadas la no postgres

   [3] Criar os Repository também na pasta Models que são interfaces onde estarão os metodos usados 
       nas requisições de cada tabela 
       Ex Administradores(model) IAdministradoresRepository(interface)

   [4] Criar pasta Infraestrutura crie a classe ConnectionContext que tera as infos do banco de dados
       e na mesma pasta infraestrutura crie a classe Repository que fara linkara o 
       contexto do banco e os metodos para fazer as requisições de uma tabela especifica
       Neste caso estou fazendo o AdministradoresRepository
 
 */