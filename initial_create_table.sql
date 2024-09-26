-- Requitos
-- 1. Criar o Banco "VendasDB"
-- 2. Rodar todos o script abaixo


IF OBJECT_ID(N'dbo.ItensVenda', N'U') IS NOT NULL BEGIN DROP TABLE ItensVenda; END
IF OBJECT_ID(N'dbo.Produtos', N'U') IS NOT NULL BEGIN DROP TABLE Produtos; END
IF OBJECT_ID(N'dbo.Vendas', N'U') IS NOT NULL BEGIN DROP TABLE Vendas; END

CREATE TABLE Produtos (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Descricao NVARCHAR(255) NOT NULL,
    Quantidade INT NOT NULL,
    PrecoUnitario DECIMAL(18, 2) NOT NULL
);

CREATE TABLE Vendas (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    NumeroVenda NVARCHAR(100) NOT NULL,
    DataVenda DATETIME2 NOT NULL,
    ClienteId INT NOT NULL,
    NomeCliente NVARCHAR(100) NOT NULL,
	IsCancelado BIT NOT NULL
);

CREATE TABLE ItensVenda (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    VendaId INT NOT NULL,
    ProdutoId INT NOT NULL,
    Quantidade DECIMAL(18, 2) NOT NULL,
    PrecoUnitario DECIMAL(18, 2) NOT NULL,
    Desconto DECIMAL(18, 2) NOT NULL,
    FOREIGN KEY (VendaId) REFERENCES Vendas(Id) ON DELETE CASCADE,
    FOREIGN KEY (ProdutoId) REFERENCES Produtos(Id) ON DELETE CASCADE
);

-- Inserção dos Produtos

INSERT INTO Produtos (Descricao, Quantidade, PrecoUnitario) VALUES 
('Fone de Ouvido Bluetooth', 50, 199.99),
('Carregador Portátil 10000mAh', 30, 149.90),
('Mouse Ergonômico Sem Fio', 20, 89.99),
('Teclado Mecânico RGB', 15, 299.99),
('Câmera de Segurança Wi-Fi', 10, 349.90),
('Smartwatch Fitness', 25, 399.99),
('Cabo USB-C 2 metros', 100, 29.99),
('Adaptador HDMI para USB-C', 40, 59.90),
('Monitor LED Full HD 24"', 8, 849.90),
('Webcam Full HD 1080p', 20, 199.90),
('SSD Externo 1TB', 15, 499.99),
('Hub USB 3.0 com 4 Portas', 50, 99.90),
('Carregador Rápido USB-C 20W', 60, 69.90),
('Smart Speaker com Assistente Virtual', 30, 229.99),
('Power Bank Solar', 25, 159.99),
('Drone com Câmera HD', 5, 1299.99),
('Ring Light com Tripé', 40, 149.90),
('Headset Gamer com Microfone', 35, 279.90),
('Leitor de Cartão de Memória', 50, 49.99),
('Caixa de Som Bluetooth', 20, 199.99);
