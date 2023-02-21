using CopyCost.TS.WPF.Core.Models;

namespace CopyCost.TS.WPF.Core.Contracts.Services;

public interface IDatabaseService
{
    //payments queries
    Task<IEnumerable<Payment>> GetPaymentsAsync();
    Task<IEnumerable<Payment>> GetPaymentsByCustomerAsync(int customerId);
    Task<IEnumerable<Payment>> GetPaymentsByCategoryAsync(int categoryId);
    Task<IEnumerable<Payment>> GetPaymentsByDateAsync(DateTime date);
    Task<Payment> GetPaymentByIdAsync(int paymentId);

    //customers queries
    Task<IEnumerable<Customer>> GetCustomersAsync();
    Task<IEnumerable<Customer>> GetCustomersByCategoryAsync(int categoryId);
    Task<Customer> GetCustomerByIdAsync(int customerId);

    //categories queries
    Task<IEnumerable<Category>> GetCategoriesAsync();
    Task<Category> GetCategoryByIdAsync(int categoryId);


    //payments commands
    Task<bool> AddPaymentAsync(Payment payment);
    Task<bool> UpdatePaymentAsync(Payment payment);
    Task<bool> DeletePaymentAsync(int paymentId);

    //customers commands
    Task<bool> AddCustomerAsync(Customer customer);
    Task<bool> UpdateCustomerAsync(Customer customer);
    Task<bool> DeleteCustomerAsync(int customerId);

    //categories commands
    Task<bool> AddCategoryAsync(Category category);
    Task<bool> UpdateCategoryAsync(Category category);
    Task<bool> DeleteCategoryAsync(int categoryId);
}