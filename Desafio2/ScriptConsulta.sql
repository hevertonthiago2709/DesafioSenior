SELECT
    CA.numero AS 'Numero do processo',
    P.nome AS 'Nome Fornecedor',
    CA.DataVencimento AS 'Data Vencimento',
    NULL AS 'Data Pagamento',
    CA.Valor - ISNULL(CA.Acrescimo, 0) + ISNULL(CA.Desconto, 0) AS 'Valor Liquido',
	    'Conta a Pagar' AS 'Identificador'
FROM
    PESSOAS P
    INNER JOIN CONTASAPAGAR CA ON P.codigo = CA.codigofornecedor

UNION

SELECT
    CP.numero AS 'Numero do processo',
    P.nome AS 'Nome Fornecedor',
    CP.DataVencimento AS 'Data Vencimento',
    CP.DataPagamento AS 'Data Pagamento',
    CP.Valor - ISNULL(CP.Acrescimo, 0) - ISNULL(CP.Desconto, 0) AS 'Valor Liquido',
	'Contas Pagas' AS 'Identificador'
FROM
    PESSOAS P
    INNER JOIN CONTASPAGAS CP ON P.codigo = CP.codigofornecedor;
