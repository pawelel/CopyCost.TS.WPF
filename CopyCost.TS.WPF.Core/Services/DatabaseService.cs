using CopyCost.TS.WPF.Core.Contracts.Services;
using CopyCost.TS.WPF.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace CopyCost.TS.WPF.Core.Services;

public class DatabaseService : IDatabaseService
{
    private readonly ApplicationDbContext _dbContext;

    public DatabaseService(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IEnumerable<Payment>> GetPaymentsAsync()
    {
        return await _dbContext.Payments
            .Include(p => p.Customer)
            .Include(p => p.Category).AsNoTracking()
            .ToListAsync();
    }

    public async Task<IEnumerable<Payment>> GetPaymentsByCustomerAsync(int customerId)
    {
        return await _dbContext.Payments
            .Include(p => p.Customer)
            .Include(p => p.Category).AsNoTracking()
            .Where(p => p.CustomerId == customerId)
            .ToListAsync();
    }

    public async Task<IEnumerable<Payment>> GetPaymentsByCategoryAsync(int categoryId)
    {
        return await _dbContext.Payments
            .Include(p => p.Customer)
            .Include(p => p.Category).AsNoTracking()
            .Where(p => p.CategoryId == categoryId)
            .ToListAsync();
    }

    public async Task<IEnumerable<Payment>> GetPaymentsByDateAsync(DateTime date)
    {
        return await _dbContext.Payments
            .Include(p => p.Customer)
            .Include(p => p.Category).AsNoTracking()
            .Where(p => p.Date == date)
            .ToListAsync();
    }

    public async Task<Payment> GetPaymentByIdAsync(int paymentId)
    {
        return await _dbContext.Payments
            .Include(p => p.Customer)
            .Include(p => p.Category).AsNoTracking()
            .FirstOrDefaultAsync(p => p.PaymentId == paymentId);
    }

    public async Task<IEnumerable<Customer>> GetCustomersAsync()
    {
        return await _dbContext.Customers.AsNoTracking().ToListAsync();
    }

    public async Task<IEnumerable<Customer>> GetCustomersByCategoryAsync(int categoryId)
    {
        return await _dbContext.Customers
            .Include(c => c.Payments)
            .Where(c => c.Payments.Any(p => p.CategoryId == categoryId))
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<Customer> GetCustomerByIdAsync(int customerId)
    {
        return await _dbContext.Customers
            .FirstOrDefaultAsync(c => c.CustomerId == customerId);
    }

    public async Task<IEnumerable<Category>> GetCategoriesAsync()
    {
        return await _dbContext.Categories.AsNoTracking().ToListAsync();
    }

    public async Task<Category> GetCategoryByIdAsync(int categoryId)
    {
        return await _dbContext.Categories
            .FirstOrDefaultAsync(c => c.CategoryId == categoryId);
    }

    public async Task<bool> AddPaymentAsync(Payment payment)
    {
        _dbContext.Payments.Add(payment);
        return await _dbContext.SaveChangesAsync() > 0;
    }

    public async Task<bool> UpdatePaymentAsync(Payment payment)
    {
        _dbContext.Payments.Update(payment);
        return await _dbContext.SaveChangesAsync() > 0;
    }

    public async Task<bool> DeletePaymentAsync(int paymentId)
    {
        var payment = await GetPaymentByIdAsync(paymentId);
        if (payment == null) return false;
        _dbContext.Payments.Remove(payment);
        return await _dbContext.SaveChangesAsync() > 0;
    }

    public async Task<bool> AddCustomerAsync(Customer customer)
    {
        _dbContext.Customers.Add(customer);
        return await _dbContext.SaveChangesAsync() > 0;
    }

    public async Task<bool> UpdateCustomerAsync(Customer customer)
    {
        _dbContext.Customers.Update(customer);
        return await _dbContext.SaveChangesAsync() > 0;
    }

    public async Task<bool> DeleteCustomerAsync(int customerId)
    {
        var customer = await GetCustomerByIdAsync(customerId);
        if (customer == null) return false;
        _dbContext.Customers.Remove(customer);
        return await _dbContext.SaveChangesAsync() > 0;
    }

    public async Task<bool> AddCategoryAsync(Category category)
    {
        _dbContext.Categories.Add(category);
        return await _dbContext.SaveChangesAsync() > 0;
    }

    public async Task<bool> UpdateCategoryAsync(Category category)
    {
        _dbContext.Categories.Update(category);
        return await _dbContext.SaveChangesAsync() > 0;
    }

    public async Task<bool> DeleteCategoryAsync(int categoryId)
    {
        var category = await GetCategoryByIdAsync(categoryId);
        if (category == null) return false;
        _dbContext.Categories.Remove(category);
        return await _dbContext.SaveChangesAsync() > 0;
    }
}