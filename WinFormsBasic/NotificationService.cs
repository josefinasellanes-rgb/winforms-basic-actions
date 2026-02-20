using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace WinFormsBasic;

public delegate void NotificationHandler(string message);

public class NotificationService
{
    public event NotificationHandler Notify;

    private HashSet<string> emails = new();
    private HashSet<string> phones = new();

    public bool AddEmail(string email)
    {
        if (!Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            return false;

        return emails.Add(email);
    }

    public bool AddPhone(string phone)
    {
        if (!Regex.IsMatch(phone, @"^\d{3}-\d{3}-\d{4}$"))
            return false;

        return phones.Add(phone);
    }

    public void RemoveEmail(string email) => emails.Remove(email);
    public void RemovePhone(string phone) => phones.Remove(phone);

    public void Publish(string message)
    {
        Notify?.Invoke(message);
    }

    public bool HasSubscribers()
    {
        return emails.Count > 0 || phones.Count > 0;
    }
}