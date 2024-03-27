using SingletonDesignPattern;

Thread thread1 = new Thread(() =>
{
    TestSingleton("Thread1");
});

Thread thread2 = new Thread(() =>
{
    TestSingleton("Thread2");
});

thread1.Start();
thread2.Start();

thread1.Join();
thread2.Join();

static void TestSingleton(string value)
{
    Singleton singleton = Singleton.Instance(value);
    Console.WriteLine(singleton.Value);
}