/****** Obtener la lista de precios de todos los productos ******/
SELECT [Name], [Price] FROM [dbo].[Products]

/****** Obtener la lista de productos cuya existencia en el inventario haya llegado al mínimo
permitido (5 unidades)  ******/
SELECT * FROM [dbo].[Products] WHERE Stock <= 5

/******  Obtener una lista de clientes no mayores de 35 años que hayan realizado compras entre el 
1 de febrero de 2000 y el 25 de mayo de 2000   ******/
SELECT * FROM [dbo].[Clients],  [dbo].[Shoppings]
WHERE  DATEDIFF(YEAR, [BirthDay], GETDATE()) < 35 
AND [dbo].[Clients] .[Id] = [dbo].[Shoppings].[ClientId]
AND [dbo].[Shoppings].[Date] BETWEEN '20000201' AND '20000525'

/****** Obtener el valor total vendido por cada producto en el año 2000 ******/SELECT SUM([t].[Quantity] * [t].[Price0]) AS Total, [t].[Name] 
FROM [Shoppings] AS [s]
LEFT JOIN (
    SELECT [s0].[ProductId], [s0].[Quantity], [s0].[ShoppingId],  [p].[Name], [p].[Price] AS [Price0]
    FROM [ShoppingsDetails] AS [s0]
    INNER JOIN [Products] AS [p] ON [s0].[ProductId] = [p].[Id]
) AS [t] ON [s].[Id] = [t].[ShoppingId]
WHERE ([s].[Date] > '2000-01-01 00:00:00') AND ([s].[Date] < '2000-12-31 23:59:59')
GROUP BY [t].[Name]


 



