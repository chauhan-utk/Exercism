using System;

public class BankAccount
{
    private readonly object balanceLock = new object();
    private decimal balance;
    private int isOpened;
    public void Open()
    {
        if (this.isOpened == 0)
        {
            this.isOpened = 1; // open the account
        }
        else
        {
            throw new InvalidOperationException();
        }
    }

    public void Close()
    {
        if (this.isOpened == 1)
        {
            this.isOpened = 2; // close the account
        }
        else
        {
            throw new InvalidOperationException();
        }
    }

    public decimal Balance
    {
        get
        {
            if (this.isOpened == 1)
            {
                return this.balance;
            }
            else
            {
                throw new InvalidOperationException();
            }
        }
    }

    public void UpdateBalance(decimal change)
    {
        lock (balanceLock)
        {
            if (this.isOpened == 1)
            {
                this.balance = decimal.Add(this.balance, change);
            }
        }
    }
}
