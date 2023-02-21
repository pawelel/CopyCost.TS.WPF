namespace CopyCost.TS.WPF.Core.DTOs;

public class AddPaymentDto
{
    public decimal Amount { get; set; }
    public DateTime Date { get; set; }
    public int CustomerId { get; set; }
    public int CategoryId { get; set; }
}