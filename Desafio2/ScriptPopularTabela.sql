-- Inserir dados na tabela PESSOAS
INSERT INTO PESSOAS (codigo, nome, cpfcnpj) VALUES
    (1, 'Fornecedor 1', '12345678901'),
    (2, 'Fornecedor 2', '98765432101'),
    (3, 'Fornecedor 3', '78901234501');

-- Inserir dados na tabela CONTASAPAGAR
INSERT INTO CONTASAPAGAR (numero, codigofornecedor, DataVencimento, DataProrrogacao, Valor, Acrescimo, Desconto) VALUES
    (11, 1, '2023-10-15', NULL, 1000.00, 50.00, 0.00),
    (22, 2, '2023-10-20', NULL, 750.00, 0.00, 25.00),
    (33, 3, '2023-10-25', NULL, 1200.00, 100.00, 50.00);

-- Inserir dados na tabela CONTASARECEBER
INSERT INTO CONTASPAGAS (numero, codigofornecedor, DataVencimento, DataPagamento, Valor, Acrescimo, Desconto) VALUES
    (1, 1, '2023-09-30', '2023-10-05', 800.00, 0.00, 0.00),
    (2, 2, '2023-09-28', '2023-10-02', 1200.00, 100.00, 0.00),
    (3, 3, '2023-10-01', NULL, 1500.00, 0.00, 75.00);
