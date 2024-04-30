/*
 -- Tabela Administradores
CREATE TABLE Administradores (
    id SERIAL PRIMARY KEY,
    nome VARCHAR(100),
    email VARCHAR(100),
    senha VARCHAR(100) -- Armazenar a senha de forma segura é crucial, considere técnicas de hash e salting
);



-- Tabela Alunos
CREATE TABLE Alunos (
    id SERIAL PRIMARY KEY,
    nome VARCHAR(100),
    email VARCHAR(100),
    data_de_nascimento DATE,
    telefone VARCHAR(20),
    curso_desejado VARCHAR(100),
    data_de_matricula DATE
);

-- Tabela Professores
CREATE TABLE Professores (
    id SERIAL PRIMARY KEY,
    nome VARCHAR(100),
    email VARCHAR(100),
    telefone VARCHAR(20),
    especialidade VARCHAR(100)
);

-- Tabela Disciplinas
CREATE TABLE Disciplinas (
    id SERIAL PRIMARY KEY,
    nome VARCHAR(100),
    carga_horaria INTEGER,
    professor_id INTEGER REFERENCES Professores(id)
);

-- Tabela Turmas
CREATE TABLE Turmas (
    id SERIAL PRIMARY KEY,
    disciplina_id INTEGER REFERENCES Disciplinas(id),
    horario VARCHAR(50),
    sala VARCHAR(50)
);

-- Tabela Matrículas
CREATE TABLE Matriculas (
    id SERIAL PRIMARY KEY,
    aluno_id INTEGER REFERENCES Alunos(id),
    turma_id INTEGER REFERENCES Turmas(id),
    data_de_matricula DATE
);
 
 
 
 
 */