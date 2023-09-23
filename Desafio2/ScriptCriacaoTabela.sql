-- Tabela PESSOAS
CREATE TABLE PESSOAS (
    codigo BIGINT PRIMARY KEY,
    nome VARCHAR(110),
    cpfcnpj VARCHAR(14)
);

-- Tabela CONTASAPAGAR
CREATE TABLE CONTASAPAGAR (
    numero BIGINT PRIMARY KEY,
    codigofornecedor BIGINT,
    DataVencimento DATE,
    DataProrrogacao DATE,
    Valor NUMERIC(18,6),
    Acrescimo NUMERIC(18,6),
    Desconto NUMERIC(18,6),
    FOREIGN KEY (codigofornecedor) REFERENCES PESSOAS(codigo)
);

-- Tabela CONTASPAGAS
CREATE TABLE CONTASPAGAS (
    numero BIGINT PRIMARY KEY,
    codigofornecedor BIGINT,
    DataVencimento DATE,
    DataPagamento DATE,
    Valor NUMERIC(18,6),
    Acrescimo NUMERIC(18,6),
    Desconto NUMERIC(18,6),
    FOREIGN KEY (codigofornecedor) REFERENCES PESSOAS(codigo)
);
