namespace CopyCost.TS.WPF.Core.DTOs;

public class PaymentDto
{
    public int PaymentId { get; set; }
    public decimal Amount { get; set; }
    public DateTime Date { get; set; }
    public int CustomerId { get; set; }
    public string CustomerName { get; set; }
    public int CategoryId { get; set; }
    public string CategoryName { get; set; }
}