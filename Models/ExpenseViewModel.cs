namespace WebApplication1.Models
{
    public class ExpenseViewModel
    {
        public Expense NewExpense { get; set; } = new Expense();  // Used for AddExpense form
        public List<Expense> Expenses { get; set; } = new List<Expense>();  // Used for CreateEditExpense list
    }

}
