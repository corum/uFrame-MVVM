using System;
using System.Collections;
using UniRx;

/// <summary>
/// A command with an argument of type T.
/// Not usually bound to directly but used to forward a command to a parent viewmodel
/// </summary>
/// <typeparam name="T">The argument parameter.</typeparam>
public class CommandWith<T> : ICommandWith<T>
{
    public event CommandEvent OnCommandExecuted;

    public event CommandEvent OnCommandExecuting;


    public void Execute(object parameter)
    {
        Parameter = parameter;
    }

    public bool CanExecute(object parameter)
    {
        throw new NotImplementedException();
    }

    public object Sender { get; set; }

    public object Parameter { get; set; }

    protected Action<T> Delegate { get; set; }

    public CommandWith(Action<T> @delegate)
    {
        Delegate = @delegate;
    }

    public CommandWith(T parameter, Action<T> @delegate)
    {
        Parameter = parameter;
        Delegate = @delegate;
    }

    //public static implicit operator CommandWith<T>(Action<T> e)
    //{
    //    return new CommandWith<T>(e);
    //}

    public virtual void Execute()
    {
        OnOnCommandExecuting();
        if (Delegate != null)
            Delegate((T)Parameter);

        OnOnCommandComplete();
    }

    protected virtual void OnOnCommandComplete()
    {
        CommandEvent handler = OnCommandExecuted;
        if (handler != null) handler();
    }

    protected virtual void OnOnCommandExecuting()
    {
        CommandEvent handler = OnCommandExecuting;
        if (handler != null) handler();
    }
    public void OnCompleted()
    {

    }

    public void OnError(Exception error)
    {
        throw error;
    }

    public void OnNext(Unit value)
    {
        Execute();
    }

    public IDisposable Subscribe(IObserver<Unit> observer)
    {
        CommandEvent handler = () => observer.OnNext(Unit.Default);
        this.OnCommandExecuted += handler;

        return Disposable.Create(() => OnCommandExecuted -= handler);
    }
}

public class CommandWithSender<TSender> : ICommandWith<TSender>
{
    public event CommandEvent OnCommandExecuted;

    public event CommandEvent OnCommandExecuting;

    public object Sender { get; set; }
    public object Parameter { get; set; }


    protected Action<TSender> Delegate { get; set; }

    public CommandWithSender(Action<TSender> @delegate)
    {
        Delegate = @delegate;
    }

    public CommandWithSender(TSender sender, Action<TSender> @delegate,ICommand oldCommand = null)
    {
        Sender = sender;
        Delegate = @delegate;
    }

    public virtual void Execute()
    {
        OnOnCommandExecuting();
        if (Delegate != null)
            Delegate((TSender)Sender);

        OnOnCommandComplete();
    }

    public void Execute(object parameter)
    {
        Parameter = parameter;
        Execute();
    }

    public bool CanExecute(object parameter)
    {
        throw new NotImplementedException();
    }

    protected virtual void OnOnCommandComplete()
    {
        CommandEvent handler = OnCommandExecuted;
        if (handler != null) handler();
    }

    protected virtual void OnOnCommandExecuting()
    {
        CommandEvent handler = OnCommandExecuting;
        if (handler != null) handler();
    }

    public void OnCompleted()
    {

    }

    public void OnError(Exception error)
    {
        throw error;
    }

    public void OnNext(Unit value)
    {
        Execute();
    }

    public IDisposable Subscribe(IObserver<Unit> observer)
    {
        CommandEvent handler = () => observer.OnNext(Unit.Default);
        this.OnCommandExecuted += handler;

        return Disposable.Create(() => OnCommandExecuted -= handler);
    }
}


public class CommandWithSenderAndArgument<TSender,TArgument> : ICommandWith<TArgument>
{
    public event CommandEvent OnCommandExecuted;

    public event CommandEvent OnCommandExecuting;

    public object Sender { get; set; }
    public object Parameter { get; set; }


    protected Action<TSender,TArgument> Delegate { get; set; }

    public CommandWithSenderAndArgument(Action<TSender,TArgument> @delegate)
    {
        Delegate = @delegate;
    }

    public CommandWithSenderAndArgument(TSender sender, Action<TSender, TArgument> @delegate)
    {
        Sender = sender;
        Delegate = @delegate;
    }

    public virtual void Execute()
    {
        OnOnCommandExecuting();
        if (Delegate != null)
            Delegate((TSender)Sender,(TArgument)Parameter);

        OnOnCommandComplete();
    }

    public void Execute(object parameter)
    {
        Parameter = parameter;
        Execute();
    }

    public bool CanExecute(object parameter)
    {
        return true;
    }

    protected virtual void OnOnCommandComplete()
    {
        CommandEvent handler = OnCommandExecuted;
        if (handler != null) handler();
    }

    protected virtual void OnOnCommandExecuting()
    {
        CommandEvent handler = OnCommandExecuting;
        if (handler != null) handler();
    }

    public void OnCompleted()
    {

    }

    public void OnError(Exception error)
    {
        throw error;
    }

    public void OnNext(Unit value)
    {
        Execute();
    }

    public IDisposable Subscribe(IObserver<Unit> observer)
    {
        CommandEvent handler = () => observer.OnNext(Unit.Default);
        this.OnCommandExecuted += handler;

        return Disposable.Create(() => OnCommandExecuted -= handler);
    }
}