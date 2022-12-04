using static System.Console;
int x = 0;
//object locker = new();
//AutoResetEvent waitHandler = new AutoResetEvent(true);//объект-сигнал
Mutex mutexObj = new ();
for(int i=1;i<6;i++)
{
    Thread myThread = new(Print);
    myThread.Name = $"Поток {i}";
    myThread.Start();
}
/*//void Print()
//{
//    lock (locker)
//    {
//        x = 1;
//        for (int i = 1; i < 6; i++)
//        {
//            WriteLine($"{Thread.CurrentThread.Name}:{x}");
//            x++;
//            Thread.Sleep(100);
//        }
//    }
//}
//void Print()
//{
//    bool acquiredLock = false;
//    try
//    {
//        Monitor.Enter(locker, ref acquiredLock);
//        x = 1;
//        for (int i = 1; i < 6; i++)
//        {
//            WriteLine($"{Thread.CurrentThread.Name}:{x}");
//            x++;
//            Thread.Sleep(100);
//        }
//    }
//    finally
//    {
//        if (acquiredLock) Monitor.Exit(locker);
//    }
////}
//void Print()
//{
//    waitHandler.WaitOne();
//    x = 1;
//    for (int i = 1; i < 6; i++)
//    {
//        WriteLine($"{Thread.CurrentThread.Name}:{x}");
//        x++;
//        Thread.Sleep(100);
//    }
//    waitHandler.Set();//сигнализируем, что waitHandler в сигнальном состоянии
//}*/
void Print()
{
    mutexObj.WaitOne(); //пристанавливаем поток до получения мьютекса
    x = 1;
    for (int i = 1; i < 6; i++)
    {
        WriteLine($"{Thread.CurrentThread.Name}:{x}");
        x++;
        Thread.Sleep(100);
    }
    mutexObj.ReleaseMutex(); //освобождаем мьютекс
}
