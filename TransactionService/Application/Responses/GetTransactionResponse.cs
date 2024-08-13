﻿namespace Application.Responses
{
    public record GetTransactionResponse
    {
        public Guid Id { get; init; }
        public DateTime Date { get; init; }
        public decimal Amount { get; init; }
        public string Type { get; init; }
        public string Description { get; init; }
    }
}
