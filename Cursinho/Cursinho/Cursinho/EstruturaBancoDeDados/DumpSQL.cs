/*
 
 COMANDOS DE MODELAGEM DO BANCO DE DADOS DO PROJETO

* Criação do banco: 
  CREATE DATABASE Curso;

======================================================== 
 
* Criação da tabela administradores:   
  CREATE TABLE administradores (
    id SERIAL PRIMARY KEY,
    nome VARCHAR(100) NOT NULL,
    email VARCHAR(100) NOT NULL,
    senha VARCHAR(100) NOT NULL,
    cargo VARCHAR(100)NOT NULL,
    status BOOLEAN NOT NULL DEFAULT TRUE,
    data_cadastro DATE NOT NULL CURRENT_DATE
  );
 
 
 
 
 
 
 
 
 
 
 */