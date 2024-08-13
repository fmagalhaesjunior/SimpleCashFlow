CREATE TABLE Transactions (
    Id uuid PRIMARY KEY,
    Amount DECIMAL(10, 2) NOT NULL,
    Type INT NOT NULL,
	Description VARCHAR(255),
    TransactionDate TIMESTAMP DEFAULT CURRENT_TIMESTAMP
);

CREATE TABLE DailySummary (
	Id uuid PRIMARY KEY,
    Date DATE NOT NULL,
    TotalCredit DECIMAL(10, 2),
    TotalDebit DECIMAL(10, 2),
    Balance DECIMAL(10, 2)
);
