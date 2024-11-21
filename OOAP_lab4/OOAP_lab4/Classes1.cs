using System;

// Інтерфейс абстракції будильника
public interface AlarmC
{
    void Start(); // Запуск будильника
    void Stop();  // Зупинка будильника
    void ToWake(); // Метод для будження
}

// Інтерфейс реалізації будильника
public interface AlarmCImpl
{
    void Ring();   // Дзвінок будильника
    void Notify(); // Повідомлення будильника
}

// Реалізація класичного будильника
public class OldAlarm : AlarmCImpl
{
    public void Ring()
    {
        Console.WriteLine("Old alarm ringing...");
    }

    public void Notify()
    {
        Console.WriteLine("Old alarm notification: Time to wake up!");
    }
}

// Реалізація сучасного будильника
public class ModernAlarm : AlarmCImpl
{
    public void Ring()
    {
        Console.WriteLine("Modern alarm buzzing...");
    }

    public void Notify()
    {
        Console.WriteLine("Modern alarm notification: Wake up! It's time.");
    }
}

// Реалізація абстракції будильника
public class AlarmClock : AlarmC
{
    private AlarmCImpl _alarmImpl;

    // Конструктор приймає реалізацію будильника
    public AlarmClock(AlarmCImpl alarmImpl)
    {
        _alarmImpl = alarmImpl;
    }

    public void Start()
    {
        Console.WriteLine("Alarm started.");
        ToWake();
    }

    public void Stop()
    {
        Console.WriteLine("Alarm stopped.");
    }

    public void ToWake()
    {
        _alarmImpl.Ring();
        _alarmImpl.Notify();
    }
}

