CREATE TABLE TabLivro (
    codigo VARCHAR(20) PRIMARY KEY,
    titulo VARCHAR(50),
    autor VARCHAR(50),
    editora VARCHAR(50),
    ano VARCHAR(7)
);

INSERT INTO TabLivro(codigo, titulo, autor, editora, ano) VALUES (1, 'teste', 'teste', 'teste', '1999');
INSERT INTO TabLivro(codigo, titulo, autor, editora, ano) VALUES (2, 'App Desktop', 'Asenjo', 'Unisanta', '2024');
INSERT INTO TabLivro(codigo, titulo, autor, editora, ano) VALUES (3, 'Framework', 'Branquinho', 'Unisanta', '2022');
INSERT INTO TabLivro(codigo, titulo, autor, editora, ano) VALUES (2, 'Banco de Dados', 'Leandro', 'Unisanta', '2021');

SELECT * FROM TabLivro WHERE codigo = :codigo; //GET livro

DROP TABLE TabLivro; //delete table
DELETE FROM TabLivro WHERE codigo = 1; //delete livro

UPDATE TabLivro SET titulo = 'teste', autor = 'teste', editora = 'teste', ano = '2000' WHERE codigo = '1'; //update livro

SELECT * FROM TabLivro; //GET table
